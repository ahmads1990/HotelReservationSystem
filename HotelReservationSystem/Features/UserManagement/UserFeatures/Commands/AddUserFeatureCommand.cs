using System.Windows.Input;
using FOOD_APP_JSB_2.Data.Repositories;
using FOOD_APP_JSB_2.Models;
using MediatR;

namespace FOOD_APP_JSB_2.CQRS.UserFeatures.Commands;

public record AddUserFeatureCommand(string name) : IRequest<bool>;

public class AddUserFeatureCommandHandler : IRequestHandler<AddUserFeatureCommand, bool>
{
    IRepository<Recipe> _repository;
    public AddUserFeatureCommandHandler(IRepository<Recipe> repository)
    {
        _repository = repository;
    }

    public Task<bool> Handle(AddUserFeatureCommand request, CancellationToken cancellationToken)
    {
        _repository.Add(new Recipe { Name = request.name});
        _repository.SaveChanges();

        return Task.FromResult(true);
    }
}