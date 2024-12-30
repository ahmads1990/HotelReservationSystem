using HotelReservationSystem.AutoMapper;
using HotelReservationSystem.Data.Repositories;
using HotelReservationSystem.Features.RoomManagement.RoomTypes.Queries;
using HotelReservationSystem.Models.Enums;
using HotelReservationSystem.Models.RoomManagement;
using HotelReservationSystem.ViewModels.Responses;
using MediatR;

namespace HotelReservationSystem.Features.RoomManagement.RoomTypes.Commands;

public record UpdateRoomTypeCommand(int ID, string Name, double Price, string Description) : IRequest<ResponseViewModel<bool>>;

public class UpdateRoomTypeCommandHandler : IRequestHandler<UpdateRoomTypeCommand, ResponseViewModel<bool>>
{
    private readonly IRepository<RoomType> _repository;
    private readonly IMediator _mediator;

    public UpdateRoomTypeCommandHandler(IRepository<RoomType> repository,
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

        var updatedRoomType = request.Map<RoomType>();

        _repository.SaveInclude(updatedRoomType,
                nameof(RoomType.Name),
                         nameof(RoomType.Price),
                         nameof(RoomType.Description)
        );

        _repository.SaveChanges();

        return response;
    }

    private async Task<ResponseViewModel<bool>> ValidateRequest(UpdateRoomTypeCommand request)
    {
        if (string.IsNullOrEmpty(request.Name))
        {
            return new FaluireResponseViewModel<bool>(ErrorCode.FieldIsEmpty, "Name is required");
        }

        if (string.IsNullOrEmpty(request.Description))
        {
            return new FaluireResponseViewModel<bool>(ErrorCode.FieldIsEmpty, "Description is required");
        }

        if (request.Price <= 0)
        {
            return new FaluireResponseViewModel<bool>(ErrorCode.InvalidInput, "Price must be greater than Zero");
        }

       var roomtypeExists = await _mediator.Send(new IsRoomTypeExistsByIdNameQuery(request.ID, request.Name));

        if (roomtypeExists.Data)
        {
            return new FaluireResponseViewModel<bool>(ErrorCode.ItemAlreadyExists);
        }

        return new SuccessResponseViewModel<bool>(true);
    }
}