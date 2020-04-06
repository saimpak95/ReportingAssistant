using System;
using System.ComponentModel.DataAnnotations;

namespace ReportingAssistant.ViewModel
{
    public class NewTaskViewModel
    {
        [Required]
        public string Screen { get; set; }

        [Required]
        public string TaskDescription { get; set; }

        public int AdminID { get; set; }

        [Required]
        public int UserID { get; set; }

        public DateTime DateOfTask { get; set; }

        [Required]
        public string Attachments { get; set; }

        [Required]
        public int ProjectID { get; set; }
    }
}