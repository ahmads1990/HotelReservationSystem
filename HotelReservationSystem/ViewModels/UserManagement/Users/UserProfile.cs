using AutoMapper;
using HotelReservationSystem.CQRS.Users.Commands;
using HotelReservationSystem.CQRS.Users.Queries;
using HotelReservationSystem.Models;
using HotelReservationSystem.Models.UserManagement;

namespace HotelReservationSystem.ViewModels.Users;

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