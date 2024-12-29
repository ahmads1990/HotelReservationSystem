﻿using HotelReservationSystem.Data.Repositories;
using HotelReservationSystem.Features.RoomManagement.RoomTypes.Commands;
using HotelReservationSystem.Features.RoomManagement.RoomTypes.Queries;
using HotelReservationSystem.Models.Enums;
using HotelReservationSystem.Models.RoomManagement;
using HotelReservationSystem.ViewModels.Responses;
using MediatR;

namespace HotelReservationSystem.Features.RoomManagement.RoomTypes.Commands;

public record UpdateRoomTypeCommand(int id, string name, double price) : IRequest<ResponseViewModel<bool>>;

public class UpdateRoomTypeCommandHandler : IRequestHandler<UpdateRoomTypeCommand, ResponseViewModel<bool>>
{
    readonly IRepository<Models.RoomManagement.RType> _repository;
    readonly IMediator _mediator;

    public UpdateRoomTypeCommandHandler(IRepository<Models.RoomManagement.RType> repository,
        IMediator mediator)
    {
        _repository = repository;
        _mediator = mediator;
    }
    public async Task<ResponseViewModel<bool>> Handle(UpdateRoomTypeCommand request, CancellationToken cancellationToken)
    {
        var response = await ValidateRequest(request);

        if (!response.IsSuccess)
            return response;

        var updatedRoom = new Models.RoomManagement.RType
        {
            ID = request.id,
            Name = request.name,
            Price = request.price,
        };

        _repository.SaveInclude(updatedRoom, nameof(Type.Name), nameof(Type.Price));
        _repository.SaveChanges();

        return response;
    }

    private async Task<ResponseViewModel<bool>> ValidateRequest(UpdateRoomTypeCommand request)
    {
        if (string.IsNullOrEmpty(request.name))
        {
            return new FaluireResponseViewModel<bool>(ErrorCode.FieldIsEmpty, "Name is required");
        }

        if (request.price <= 0)
        {
            return new FaluireResponseViewModel<bool>(ErrorCode.InvalidInput, "Price must be greater than Zero");
        }

        // find room by id
        //var roomtypeExists = await _mediator.Send(new IsRoomTypeExistsQuery(request.name));

        //if (roomtypeExists)
        //{
        //    return new FaluireResponseViewModel<bool>(ErrorCode.ItemAlreadyExists);
        //}

        return new SuccessResponseViewModel<bool>(true);
    }
}