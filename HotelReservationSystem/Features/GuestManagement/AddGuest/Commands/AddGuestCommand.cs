using HotelReservationSystem.Common;
using HotelReservationSystem.Common.Enums;
using HotelReservationSystem.Common.views;
using HotelReservationSystem.Data.Repositories;

using HotelReservationSystem.Features.GuestManagement.AddGuest.Queries;
using HotelReservationSystem.Models.GuestManagement;
using MediatR;

namespace HotelReservationSystem.Features.GuestManagement.AddGuest.Commands;

public record AddGuestCommand(string name, string NID, string phoneNumber, int age) : IRequest<RequestResult<int>>;

public class AddGuestCommandHandler : IRequestHandler<AddGuestCommand, RequestResult<int>>
{
    private readonly IRepository<Guest> _repository;
    private readonly IMediator _mediator;
    public AddGuestCommandHandler(IRepository<Guest> repository, IMediator mediator)
    {
        _repository = repository;
        _mediator = mediator;
    }
    
    public async Task<RequestResult<int>> Handle(AddGuestCommand request, CancellationToken cancellationToken)
    {

        var existingGuestNIDs = await _mediator.Send(new IsGuestExistQuery(request.NID));
        if (existingGuestNIDs.data != null)
        {
            return RequestResult<bool>.Success(existingGuestNIDs.data);
        }
        
        var newGuest =  new Guest
            {
                Name = request.name,
                NID = request.NID,
                PhoneNumber = request.phoneNumber,
                Age = request.age,
            };
        
        await _repository.AddAsync(newGuest);
        await _repository.SaveChangesAsync();

        return RequestResult<bool>.Success(newGuest.ID);
    }
}