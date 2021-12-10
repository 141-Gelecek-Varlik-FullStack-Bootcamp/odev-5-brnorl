namespace odev3.Models.User
{
    public class LoginUserModel : IUserModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}