using FOOD_APP_JSB_2.AutoMapper;
using FOOD_APP_JSB_2.Data.Repositories;
using FOOD_APP_JSB_2.ViewModels.Users;
using HotelReservationSystem.Models.UserManagement.Users;
using MediatR;

namespace FOOD_APP_JSB_2.CQRS.Users.Queries;

public record GetUserByIDQuery (int ID) : IRequest<UserViewModel>;

public class GetUserByIDQueryHandler : IRequestHandler<GetUserByIDQuery, UserViewModel>
{
    IRepository<User> _repository;
    IMediator _mediator;
    public GetUserByIDQueryHandler(IMediator mediator, IRepository<User> repository)
    {
        _repository = repository;
        _mediator = mediator;
    }

    public async Task<UserViewModel> Handle(GetUserByIDQuery request, CancellationToken cancellationToken)
    {
        // var exams = _mediator.Send(new GetExamsByInstructorIDQuery(request.ID));

        var result= (await _repository.GetByIDAsync(request.ID))
            .Map<UserViewModel>();
        return result;
    }
}