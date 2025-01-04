using AutoMapper;
using HotelReservationSystem.Features.UserManagement.Users.Commands;
using HotelReservationSystem.Features.UserManagement.Users.Queries;
using HotelReservationSystem.Models.UserManagement;

namespace HotelReservationSystem.ViewModels.Users;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<User, UserViewModel>().ReverseMap();
        CreateMap<RegisterUserCommand, UserViewModel>().ReverseMap();
        CreateMap<RegisterUserCommand, RegisterViewModel>().ReverseMap();
        CreateMap<UserLogInQuery, LoginViewModel>().ReverseMap();
    }
}