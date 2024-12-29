using HotelReservationSystem.Models;

namespace HotelReservationSystem.Models.UserManagement
{
    public class Role : BaseModel
    {
        public string RoleName { get; set; }

        public int UserID { get; set; }
        public User User { get; set; }

        public ICollection<RoleFeatures> RoleFeatures { get; set; }

    }
}
