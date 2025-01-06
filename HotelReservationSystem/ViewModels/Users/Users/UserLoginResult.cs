namespace HotelReservationSystem.ViewModels.Users
{
    public class UserLoginResult
    {
        public string Token { get; set; }
        public bool TwofactorAuthEnabled { get; set; }
    }
}
