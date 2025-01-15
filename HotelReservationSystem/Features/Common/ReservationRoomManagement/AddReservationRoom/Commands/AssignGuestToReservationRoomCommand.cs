using HotelReservationSystem.Common.Enums;
using HotelReservationSystem.Common.views;
using HotelReservationSystem.Data.Repositories;
using HotelReservationSystem.Models.GuestManagement;
using HotelReservationSystem.Models.ReservationManagement;
using MediatR;

namespace HotelReservationSystem.Features.Common.ReservationRoomManagement.AddReservationRoom.Commands;

public record AssignGuestToReservationRoomCommand(int guestID, int reservationroomID) : IRequest<RequestResult<bool>>;

public class
    AssignListOfGuestsToReservationRoomCommandHandler : IRequestHandler<AssignGuestToReservationRoomCommand,
    RequestResult<bool>>
{
    private readonly IRepository<ReservationRoomGuest> _repository;
    private readonly IMediator _mediator;

    public AssignListOfGuestsToReservationRoomCommandHandler(IRepository<ReservationRoomGuest> repository,
        IMediator mediator)
    {
        _repository = repository;
        _mediator = mediator;
    }

    public async Task<RequestResult<bool>> Handle(AssignGuestToReservationRoomCommand request,
        CancellationToken cancellationToken)
    {
        if (request.reservationroomID <= 0)
        {
            return RequestResult<bool>.Failed<bool>(ErrorCode.InvalidInput);
        }

        var reservationRoomGuests = new ReservationRoomGuest
            {
                ReservationRoomID = request.reservationroomID,
                GuestID = request.guestID
            };
        
        await _repository.AddAsync(reservationRoomGuests);
        await _repository.SaveChangesAsync();
        
        return RequestResult<bool>.Success(true);
    }
}