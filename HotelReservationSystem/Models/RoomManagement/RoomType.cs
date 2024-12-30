﻿namespace HotelReservationSystem.Models.RoomManagement
{
    public class RoomType : BaseModel
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }

        public ICollection<RoomTypeFacilities> RTypeFacilities { get; set; }  = new List<RoomTypeFacilities>();
        
    }
}