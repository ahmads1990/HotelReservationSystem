using HotelReservationSystem.Data.Enums;
using System.Collections.Generic;

namespace HotelReservationSystem.Models.UserManagement
{
    public class UserFeature : BaseModel
    {
        public int UserID { get; set; }
        public User user { get; set; }
        public Feature Feature { get; set; }
    }
}
