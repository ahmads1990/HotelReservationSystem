using HotelReservationSystem.Models.UserManagement.Users;
using Microsoft.EntityFrameworkCore;

namespace FOOD_APP_JSB_2.Data.Repositories
{
    public class UserRepository : Repository<User> , IUserRepository
    {

        Context _context;

        public UserRepository(Context context) : base(context)
        {
            _context = context;
        }

        public async Task<(int, bool)> LogInUser(string email, string password)
        {
            var user = await _context.Users
            .AsNoTracking()
            .Where(u => u.Email == email && u.Password == password) 
            .Select(u => new { u.ID, u.TwoFactorAuthEnabled })
            .FirstOrDefaultAsync();

            if (user == null)
            {
                return (0, false);
            }

            return (user.ID, user.TwoFactorAuthEnabled);
        }
    }
}
