using HotelReservationSystem.Common.Enums;
using HotelReservationSystem.Common.views;
using HotelReservationSystem.Data.Repositories;
using HotelReservationSystem.Features.RoomManagement.Facilities.Queries;
using HotelReservationSystem.Models.RoomManagement;
using MediatR;

namespace HotelReservationSystem.Features.RoomManagement.Rooms.Commands
{
    public record AddRoomCommand(string RoomNumber, string Description, bool IsAvailable, int RoomTypeID, int CreatedBy, List<int> customFacilities) : IRequest<RequestResult<bool>>;

    public class AddRoomCommandHandler : IRequestHandler<AddRoomCommand, RequestResult<bool>>
    {
        readonly IRepository<Room> _repository;
        readonly IMediator _mediator;
        public AddRoomCommandHandler(IRepository<Room> repository,
            IMediator mediator)
        {
            _repository = repository;
            _mediator = mediator;
        }

        public async Task<RequestResult<bool>> Handle(AddRoomCommand request, CancellationToken cancellationToken)
        {
            var response = await ValidateRequest(request);

            if (!response.isSuccess)
                return response;

            _repository.Add(new Room
            {
                RoomNumber = request.RoomNumber,
                Description = request.Description,
                IsAvailable = request.IsAvailable,
                RTypeID = request.RoomTypeID,
                CreatedBy = request.CreatedBy,
                RoomFacilities = request.customFacilities
                    .Select(facilityId => new RoomFacility { FacilityID = facilityId })
                    .ToList()
            });
            _repository.SaveChanges();
            return response;
        }

        private async Task<RequestResult<bool>> ValidateRequest(AddRoomCommand request)
        {
            if (string.IsNullOrEmpty(request.RoomNumber))
            {
                return RequestResult<bool>.Failed<bool>(ErrorCode.FieldIsEmpty);
            }

            var roomtypeExists = await _mediator.Send(new IsRoomExistsQuery(request.RoomNumber));

            if (roomtypeExists)
            {
                return RequestResult<bool>.Failed<bool>(ErrorCode.ItemAlreadyExists);
            }

            return RequestResult<bool>.Success(true);
        }
    }
}
