using System.ComponentModel.DataAnnotations;

namespace odev3.Models.User
{
    public class LoginUserModel : IUserModel
    {
        [Required(ErrorMessage = "Email is Required")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is Required")]
        public string Password { get; set; }
    }
}