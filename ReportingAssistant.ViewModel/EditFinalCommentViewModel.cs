using System;
using System.ComponentModel.DataAnnotations;

namespace ReportingAssistant.ViewModel
{
    public class EditFinalCommentViewModel
    {
        [Required]
        public int FinalCommentID { get; set; }

        [Required]
        public string Screen { get; set; }

        [Required]
        public string FinalCommentDescription { get; set; }

        [Required]
        public int UserID { get; set; }

        [Required]
        public DateTime DateOfFinalComment { get; set; }

        [Required]
        public string Attachments { get; set; }

        [Required]
        public int ProjectID { get; set; }
    }
}