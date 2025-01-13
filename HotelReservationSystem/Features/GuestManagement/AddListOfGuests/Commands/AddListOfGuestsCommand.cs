using HotelReservationSystem.Common;
using HotelReservationSystem.Common.views;
using HotelReservationSystem.Data.Repositories;
using HotelReservationSystem.DTOs;
using HotelReservationSystem.DTOs.Guests;
using HotelReservationSystem.Features.GuestManagement.AddListOfGuests;
using HotelReservationSystem.Features.GuestManagement.AddListOfGuests.Queries;
using HotelReservationSystem.Models.Enums;
using HotelReservationSystem.Models.GuestManagement;
using MediatR;

namespace HotelReservationSystem.Features.GuestManagement.AddListOfGuests.Commands;

public record AddListOfGuestsCommand(List<GuestCreateRequestViewModel> Guests) : IRequest<RequestResult<bool>>;

public class AddGuestsCommandHandler : IRequestHandler<AddListOfGuestsCommand, RequestResult<bool>>
{
    private readonly IRepository<Guest> _repository;
    private readonly IMediator _mediator;
    public AddGuestsCommandHandler(IRepository<Guest> repository, IMediator mediator)
    {
        _repository = repository;
        _mediator = mediator;
    }
    
    public async Task<RequestResult<bool>> Handle(AddListOfGuestsCommand request, CancellationToken cancellationToken)
    {
        if (request.Guests == null || !request.Guests.Any())
        {
            return RequestResult<bool>.Failed<bool>(ErrorCode.InvalidInput);
        }
        
        var incomingNIDs = request.Guests.Select(g => g.NID).ToList();
        var existingGuestNIDs = await _mediator.Send(new IsGuestExistQuery(incomingNIDs));
        
        
        var newGuests = request.Guests
            .Where(g => !existingGuestNIDs.data.Contains(g.NID))
            .Select(guest => new Guest
            {
                Name = guest.Name,
                NID = guest.NID,
                PhoneNumber = guest.PhoneNumber,
                Age = guest.Age,
            })
            .ToList();
        
        if (!newGuests.Any())
        {
            return RequestResult<bool>.Success(true);
        }
        
        await _repository.AddRangeAsync(newGuests);
        await _repository.SaveChangesAsync();

        return RequestResult<bool>.Success(true);
    }
}