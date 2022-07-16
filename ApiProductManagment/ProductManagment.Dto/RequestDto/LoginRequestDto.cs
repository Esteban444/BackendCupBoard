using System.ComponentModel.DataAnnotations;

namespace ProductManagment.Dto.RequestDto
{
    public class LoginRequestDto
    {
        [Required(ErrorMessage = "The email field cannot be empty.")]
        public string? Email { get; set; }
        [Required(ErrorMessage = "The password field cannot be empty.")]
        public string? Password { get; set; }
    }
}
