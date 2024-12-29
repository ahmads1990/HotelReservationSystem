using HotelReservationSystem.AutoMapper;
using HotelReservationSystem.Data.Repositories;
using HotelReservationSystem.Models;
using HotelReservationSystem.ViewModels.Users;
using MediatR;

namespace HotelReservationSystem.CQRS.Users.Queries;

public record UserLogInQuery(string email, string password) : IRequest<(int, bool)>;

public class UserLogInQueryHandler : IRequestHandler<UserLogInQuery, (int, bool)>
{
    IUserRepository _repository;

    public UserLogInQueryHandler(IMediator mediator, IUserRepository repository)
    {
        _repository = repository;
    }

    public async Task<(int, bool)> Handle(UserLogInQuery request, CancellationToken cancellationToken)
    {
        var userData = await _repository.LogInUser(request.email, request.password);
        
        return userData;
    }
}