using HotelReservationSystem.AutoMapper;
using HotelReservationSystem.Features.RoomManagement.Facilities.Queries;
using HotelReservationSystem.Data.Repositories;
using HotelReservationSystem.Models.Enums;
using HotelReservationSystem.Models.RoomManagement;
using MediatR;
using HotelReservationSystem.ViewModels.Responses;

namespace HotelReservationSystem.Features.RoomManagement.Rooms.Commands
{
    public record AddRoomCommand(string roomNumber, string Description, bool isAvailable, int roomTypeID) : IRequest<ResponseViewModel<bool>>;

    public class AddRoomCommandHandler : IRequestHandler<AddRoomCommand, ResponseViewModel<bool>>
    {
        readonly IRepository<Room> _repository;
        readonly IMediator _mediator;
        public AddRoomCommandHandler(IRepository<Room> repository,
            IMediator mediator)
        {
            _repository = repository;
            _mediator = mediator;
        }

        public async Task<ResponseViewModel<bool>> Handle(AddRoomCommand request, CancellationToken cancellationToken)
        {
            var response = await ValidateRequest(request);

            if (!response.IsSuccess)
                return response;

            _repository.Add(new Room
            {
                RoomNumber = request.roomNumber,
                Description = request.Description,
                IsAvailable = request.isAvailable,
                RoomTypeID = request.roomTypeID
            });
            _repository.SaveChanges();
            return response;
        }

        private async Task<ResponseViewModel<bool>> ValidateRequest(AddRoomCommand request)
        {
            if (string.IsNullOrEmpty(request.roomNumber))
            {
                return new FailureResponseViewModel<bool>(ErrorCode.FieldIsEmpty, "Name is required");
            }
            
            var roomtypeExists = await _mediator.Send(new IsRoomExistsQuery(request.roomNumber));

            if (roomtypeExists)
            {
                return new FailureResponseViewModel<bool>(ErrorCode.ItemAlreadyExists);
            }

            return new SuccessResponseViewModel<bool>(true);
        }
    }
}
