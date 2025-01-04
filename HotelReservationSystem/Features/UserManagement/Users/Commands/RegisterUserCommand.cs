using HotelReservationSystem.Data.Repositories;
using HotelReservationSystem.Models.UserManagement;
using MediatR;

namespace HotelReservationSystem.Features.UserManagement.Users.Commands;

public record RegisterUserCommand(string phoneNo, string name, string userName, string email, string password) : IRequest<bool>;

public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, bool>
{
    IRepository<User> _repository;
    public RegisterUserCommandHandler(IRepository<User> repository)
    {
        _repository = repository;
    }

    public Task<bool> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        _repository.Add(new User
        {
            PhoneNo = request.phoneNo,
            Name = request.name,
            UserName = request.userName,
            Email = request.email,
            Password = request.password
        });
        _repository.SaveChanges();

        return Task.FromResult(true);
    }
}