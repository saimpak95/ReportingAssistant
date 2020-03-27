using System.ComponentModel.DataAnnotations;

namespace ReportingAssistant.ViewModel
{
    public class EditUserPasswordViewModel
    {
        public int UserID { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}