using System.ComponentModel.DataAnnotations;

namespace odev3.Models.User
{
    public class UpdateUserModel : IUserModel
    {
        [Required(ErrorMessage = "Name is Required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Surname is Required")]
        public string Surname { get; set; }
        [Required(ErrorMessage = "Email is Required")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is Required")]
        public string Password { get; set; }
    }
}