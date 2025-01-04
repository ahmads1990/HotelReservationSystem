using HotelReservationSystem.Data.Repositories;
using HotelReservationSystem.Features.RoomManagement.Facilities.Queries;
using HotelReservationSystem.Models.Enums;
using HotelReservationSystem.Models.RoomManagement;
using HotelReservationSystem.ViewModels.Responses;
using MediatR;

namespace HotelReservationSystem.Features.RoomManagement.Rooms.Commands
{
    public record AddRoomCommand(string RoomNumber, string Description, bool IsAvailable, int RoomTypeID, int CreatedBy, List<int> customFacilities) : IRequest<ResponseViewModel<bool>>;

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
                RoomNumber = request.RoomNumber,
                Description = request.Description,
                IsAvailable = request.IsAvailable,
                RoomTypeID = request.RoomTypeID,
                CreatedBy = request.CreatedBy,
                RoomFacilities = request.customFacilities
                    .Select(facilityId => new RoomFacility { FacilityID = facilityId })
                    .ToList()
            });
            _repository.SaveChanges();
            return response;
        }

        private async Task<ResponseViewModel<bool>> ValidateRequest(AddRoomCommand request)
        {
            if (string.IsNullOrEmpty(request.RoomNumber))
            {
                return new FailureResponseViewModel<bool>(ErrorCode.FieldIsEmpty, "Name is required");
            }

            var roomtypeExists = await _mediator.Send(new IsRoomExistsQuery(request.RoomNumber));

            if (roomtypeExists)
            {
                return new FailureResponseViewModel<bool>(ErrorCode.ItemAlreadyExists);
            }

            return new SuccessResponseViewModel<bool>(true);
        }
    }
}
