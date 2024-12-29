using System.Windows.Input;
using HotelReservationSystem.Data.Enums;
using HotelReservationSystem.Data.Repositories;
using HotelReservationSystem.Models.UserManagement;
using MediatR;

namespace HotelReservationSystem.CQRS.UserFeatures.Commands;

public record AddUserFeatureCommand(int userID, Feature feature) : IRequest<bool>;

public class AddUserFeatureCommandHandler : IRequestHandler<AddUserFeatureCommand, bool>
{
    IRepository<Models.UserManagement.UserFeatures> _repository;
    public AddUserFeatureCommandHandler(IRepository<Models.UserManagement.UserFeatures> repository)
    {
        _repository = repository;
    }

    public Task<bool> Handle(AddUserFeatureCommand request, CancellationToken cancellationToken)
    {
        _repository.Add(new Models.UserManagement.UserFeatures { Feature = request.feature});
        _repository.SaveChanges();

        return Task.FromResult(true);
    }
}