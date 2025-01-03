using HotelReservationSystem.Models.UserManagement;

namespace HotelReservationSystem.Data.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        Task<(int, bool)> LogInUser(string email, string password);
    }
}
