using HotelReservationSystem.AutoMapper;
using HotelReservationSystem.Data.Enums;
using MediatR;
using HotelReservationSystem.Data.Repositories;
using HotelReservationSystem.Models.UserManagement;

namespace HotelReservationSystem.Features.UserManagement.UserFeatures.Queries;

public record HasAccessQuery(int id, Feature featuer) : IRequest<bool>;

public class HasAccessQueryHandler : IRequestHandler<HasAccessQuery, bool>
{
    private readonly IRepository<UserFeature> _repository;
    IMediator _mediator;
    public HasAccessQueryHandler(IMediator mediator, IRepository<UserFeature> repository)
    {
        _repository = repository;
        _mediator = mediator;
    }

    public async Task<bool> Handle(HasAccessQuery request, CancellationToken cancellationToken)
    {
        var hasFeature = await _repository.AnyAsync(
             uf => uf.UserID == request.id && uf.Feature == request.featuer);

        return hasFeature;
    }


}