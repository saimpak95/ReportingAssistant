using System.ComponentModel.DataAnnotations;

namespace ReportingAssistant.ViewModel
{
   public class LoginViewModel
    {

        [Required]
        [RegularExpression(@"(\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,6})")]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
