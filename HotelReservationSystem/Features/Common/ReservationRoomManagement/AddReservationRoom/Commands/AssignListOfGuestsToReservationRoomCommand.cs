using HotelReservationSystem.Common.views;
using HotelReservationSystem.Data.Repositories;
using HotelReservationSystem.Models.GuestManagement;
using HotelReservationSystem.Models.ReservationManagement;
using MediatR;

namespace HotelReservationSystem.Features.Common.ReservationRoomManagement.AddReservationRoom.Commands;

public record AssignListOfGuestsToReservationRoomCommand(List<string> NIDs) : IRequest<RequestResult<bool>>;

public class AssignListOfGuestsToReservationRoomCommandHandler : IRequestHandler<AssignListOfGuestsToReservationRoomCommand, RequestResult<bool>>
{
    private readonly IRepository<ReservationRoom> _repository;
    private readonly IMediator _mediator;
    public AssignListOfGuestsToReservationRoomCommandHandler(IRepository<Guest> repository, IMediator mediator)
    {
        _repository = repository;
        _mediator = mediator;
    }
    
    public async Task<RequestResult<bool>> Handle(AssignListOfGuestsToReservationRoomCommand request, CancellationToken cancellationToken)
    {