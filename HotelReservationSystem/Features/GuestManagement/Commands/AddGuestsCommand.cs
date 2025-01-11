using HotelReservationSystem.Data.Repositories;
using HotelReservationSystem.DTOs;
using HotelReservationSystem.DTOs.Guests;
using HotelReservationSystem.Models.Enums;
using HotelReservationSystem.Models.GuestManagement;
using MediatR;

namespace HotelReservationSystem.Features.GuestManagement.Commands;

public record AddGuestsCommand(List<GuestCreateDTO> Guests) : IRequest<ResponseDTO<bool>>;

public class AddGuestsCommandHandler : IRequestHandler<AddGuestsCommand, ResponseDTO<bool>>
{
    private readonly IRepository<Guest> _repository;
    
    public AddGuestsCommandHandler(IRepository<Guest> repository)
    {
        _repository = repository;
    }
    
    public async Task<ResponseDTO<bool>> Handle(AddGuestsCommand request, CancellationToken cancellationToken)
    {
        if (request.Guests == null || !request.Guests.Any())
        {
            return new FailureResponseDTO<bool>(ErrorCode.InvalidInput);
        }
        
        var guestEntities = request.Guests.Select(guest => new Guest
        {
            Name = guest.Name,
            NID = guest.NID,
            PhoneNumber = guest.PhoneNumber,
            Age = guest.Age
        }).ToList();

        foreach (var guest in guestEntities)
        {
            await _repository.AddAsync(guest);
        }

        _repository.SaveChanges();
        
        return new SuccessResponseDTO<bool>(true);
    }
}