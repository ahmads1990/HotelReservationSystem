using HotelReservationSystem.Common.Enums;
using HotelReservationSystem.Common.views;
using HotelReservationSystem.Data.Repositories;
using HotelReservationSystem.Features.RoomManagement.Facilities.Queries;
using HotelReservationSystem.Models.RoomManagement;
using MediatR;

namespace HotelReservationSystem.Features.RoomManagement.Facilities.AddFacility.Commands
{
    public record AddFacilityCommand(string name, double price, string description) : IRequest<RequestResult<bool>>;

    public class AddRoomFacilityCommandHandler : IRequestHandler<AddFacilityCommand, RequestResult<bool>>
    {
        readonly IRepository<Facility> _repository;
        readonly IMediator _mediator;

        public AddRoomFacilityCommandHandler(IRepository<Facility> repository,
            IMediator mediator)
        {
            _repository = repository;
            _mediator = mediator;
        }

        public async Task<RequestResult<bool>> Handle(AddFacilityCommand request, CancellationToken cancellationToken)
        {
            var response = await ValidateRequest(request);

            if (!response.isSuccess)
                return response;

           await _repository.AddAsync(new Facility
            {
                Name = request.name,
                Price = request.price,
                Description = request.description,
            });

            await _repository.SaveChangesAsync();
            return response;
        }

        private async Task<RequestResult<bool>> ValidateRequest(AddFacilityCommand request)
        {
            if (string.IsNullOrEmpty(request.name))
            {
                return RequestResult<bool>.Failed<bool>(ErrorCode.FieldIsEmpty);
            }

            if (request.price <= 0)
            {
                return RequestResult<bool>.Failed<bool>(ErrorCode.InvalidInput);
            }

            var roomtypeExists = await _mediator.Send(new IsRoomExistsQuery(request.name));

            if (roomtypeExists)
            {
                return RequestResult<bool>.Failed<bool>(ErrorCode.ItemAlreadyExists);
            }

            return RequestResult<bool>.Success(true);
        }
    }
}
