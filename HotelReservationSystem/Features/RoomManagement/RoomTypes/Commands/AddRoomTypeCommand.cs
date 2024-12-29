using HotelReservationSystem.Data.Repositories;
using HotelReservationSystem.Features.RoomManagement.RoomTypes.Queries;
using HotelReservationSystem.Models.Enums;
using HotelReservationSystem.Models.RoomManagement;
using HotelReservationSystem.ViewModels.Responses;
using MediatR;

namespace HotelReservationSystem.Features.RoomManagement.RoomTypes.Commands
{
    public record AddRoomTypeCommand(string name, double price) : IRequest<ResponseViewModel<bool>>;

    public class AddRoomTypeCommandHandler : IRequestHandler<AddRoomTypeCommand, ResponseViewModel<bool>>
    {
        readonly IRepository<Models.RoomManagement.RType> _repository;
        readonly IMediator _mediator;

        public AddRoomTypeCommandHandler(IRepository<Models.RoomManagement.RType> repository,
            IMediator mediator)
        {
            _repository = repository;
            _mediator = mediator;
        }

        public async Task<ResponseViewModel<bool>> Handle(AddRoomTypeCommand request, CancellationToken cancellationToken)
        {
            var response = await ValidateRequest(request);

            if (!response.IsSuccess)
                return response;

            _repository.Add(new Models.RoomManagement.RType
            {
                Name = request.name,
                Price = request.price,
            });

            return response;
        }

        private async Task<ResponseViewModel<bool>> ValidateRequest(AddRoomTypeCommand request)
        {
            if(string.IsNullOrEmpty(request.name))
            {
                return new FaluireResponseViewModel<bool>(ErrorCode.FieldIsEmpty, "Name is required");
            }

            if (request.price <= 0)
            {
                return new FaluireResponseViewModel<bool>(ErrorCode.InvalidInput, "Price must be greater than Zero");
            }

            var roomtypeExists = await _mediator.Send(new IsRoomTypeExistsQuery(request.name));
             
            if(roomtypeExists)
            {
                return new FaluireResponseViewModel<bool>(ErrorCode.ItemAlreadyExists);
            }

            return new SuccessResponseViewModel<bool>(true);
        }
    }
}
