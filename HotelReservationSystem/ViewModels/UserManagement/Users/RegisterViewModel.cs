﻿using System.ComponentModel.DataAnnotations;

namespace HotelReservationSystem.ViewModels.Users
{
    public class RegisterViewModel
    {
        public string PhoneNo { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = string.Empty;
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;
    }
}
