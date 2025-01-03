using HotelReservationSystem.Data.Enums;
using System.Collections.Generic;

namespace HotelReservationSystem.Models.UserManagement
{
    public class RoleFeatures : BaseModel
    {
        public int ID { get; set; }
        public int RoleID { get; set; }
        public Role Role { get; set; }
        public Feature Feature { get; set; }
    }
}
