using HotelReservationSystem.Data.Enums;
using HotelReservationSystem.Data.Repositories;
using MediatR;

namespace HotelReservationSystem.Features.UserManagement.UserFeatures.Commands;

public record AddUserFeatureCommand(int userID, Feature feature) : IRequest<bool>;

public class AddUserFeatureCommandHandler : IRequestHandler<AddUserFeatureCommand, bool>
{
    IRepository<Models.UserManagement.UserFeature> _repository;
    public AddUserFeatureCommandHandler(IRepository<Models.UserManagement.UserFeature> repository)
    {
        _repository = repository;
    }

    public Task<bool> Handle(AddUserFeatureCommand request, CancellationToken cancellationToken)
    {
        _repository.Add(new Models.UserManagement.UserFeature { Feature = request.feature });
        _repository.SaveChanges();

        return Task.FromResult(true);
    }
}