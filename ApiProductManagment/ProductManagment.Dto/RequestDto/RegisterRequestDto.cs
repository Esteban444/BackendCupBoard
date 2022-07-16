using System.ComponentModel.DataAnnotations;

namespace ProductManagment.Dto.RequestDto
{
    public class RegisterRequestDto
    {
        [Required(ErrorMessage = "The names field cannot be empty.")]
        public string? Names { get; set; }
        
        [Required(ErrorMessage = "The lastName field cannot be empty.")]
        public string? LastNames { get; set; }
        [Required(ErrorMessage = "The email field cannot be empty.")]
        public string? Email { get; set; }
        public string? UserName { get; set; }
        [Required(ErrorMessage = "The password field cannot be empty.")]
        public string? Password { get; set; }
        [Compare("Password", ErrorMessage = "Passwords do not match.")]
        public string? ConfirmPassword { get; set; }
    }
}
