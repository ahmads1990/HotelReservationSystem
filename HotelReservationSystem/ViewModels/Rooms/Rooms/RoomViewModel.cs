﻿using HotelReservationSystem.ViewModels.RoomManagment.Facilities;

namespace HotelReservationSystem.ViewModels.RoomManagment.Rooms
{
    public class RoomViewModel
    {
        public int ID { get; set; }
        public string RoomTypeName { get; set; }
        public List<FacilityViewModel> Facilities { get; set; }
    }
}