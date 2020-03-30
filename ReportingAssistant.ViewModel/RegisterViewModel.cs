using System.ComponentModel.DataAnnotations;

namespace ReportingAssistant.ViewModel
{
    public class RegisterViewModel
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        [RegularExpression(@"(\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,6})")]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Role { get; set; }

        [Required]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }

        [Required]
        [MaxLength(11, ErrorMessage = "Maximum Length is 11")]
        [MinLength(11, ErrorMessage = "Minimum Length is 11")]
        public string Phone { get; set; }

        [Required]
        public string Gender { get; set; }
    }
}