using AutoMapper;
using FOOD_APP_JSB_2.CQRS.Users.Commands;
using FOOD_APP_JSB_2.CQRS.Users.Queries;
using FOOD_APP_JSB_2.Models;

namespace FOOD_APP_JSB_2.ViewModels.Users;

public class UserProfile: Profile
{
    public UserProfile()
    {
        CreateMap<User, UserViewModel>().ReverseMap();
        CreateMap<RegisterUserCommand, UserViewModel>().ReverseMap();
        CreateMap<RegisterUserCommand, RegisterViewModel>().ReverseMap();
        CreateMap<UserLogInQuery, LoginViewModel>().ReverseMap();
    }
}