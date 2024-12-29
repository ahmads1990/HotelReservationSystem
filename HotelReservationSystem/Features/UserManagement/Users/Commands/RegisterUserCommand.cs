using System.Windows.Input;
using FOOD_APP_JSB_2.Data.Repositories;
using HotelReservationSystem.Models.UserManagement.Users;
using MediatR;

namespace FOOD_APP_JSB_2.CQRS.Users.Commands;

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
        { PhoneNo= request.phoneNo,
          Name = request.name,
          UserName=request.userName,
          Email=request.email,
          Password=request.password
        });
        _repository.SaveChanges();

        return Task.FromResult(true);
    }
}