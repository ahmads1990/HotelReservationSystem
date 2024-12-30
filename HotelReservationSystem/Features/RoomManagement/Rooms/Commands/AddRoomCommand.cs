using HotelReservationSystem.Features.RoomManagement.Facilities.Queries;
using HotelReservationSystem.Data.Repositories;
using HotelReservationSystem.Models.Enums;
using HotelReservationSystem.Models.RoomManagement;
using MediatR;
using HotelReservationSystem.ViewModels.Responses;

namespace HotelReservationSystem.Features.RoomManagement.Rooms.Commands
{
    public record AddRoomCommand(string name, double price) : IRequest<ResponseViewModel<bool>>;

    public class AddRoomCommandHandler : IRequestHandler<AddRoomCommand, ResponseViewModel<bool>>
    {
        readonly IRepository<Facility> _repository;
        readonly IMediator _mediator;

        public AddRoomCommandHandler(IRepository<Facility> repository,
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

            _repository.Add(new Facility
            {
                Name = request.name,
                Price = request.price,
            });

            return response;
        }

        private async Task<ResponseViewModel<bool>> ValidateRequest(AddRoomCommand request)
        {
            if (string.IsNullOrEmpty(request.name))
            {
                return new FailureResponseViewModel<bool>(ErrorCode.FieldIsEmpty, "Name is required");
            }

            if (request.price <= 0)
            {
                return new FailureResponseViewModel<bool>(ErrorCode.InvalidInput, "Price must be greater than Zero");
            }

            var roomtypeExists = await _mediator.Send(new IsRoomExistsQuery(request.name));

            if (roomtypeExists)
            {
                return new FailureResponseViewModel<bool>(ErrorCode.ItemAlreadyExists);
            }

            return new SuccessResponseViewModel<bool>(true);
        }
    }
}
