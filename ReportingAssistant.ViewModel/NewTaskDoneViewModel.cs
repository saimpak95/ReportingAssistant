using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ReportingAssistant.ViewModel
{
    public class NewTaskDoneViewModel
    {
        [Required]
        public string Screen { get; set; }

        [Required]
        public string TaskDoneDescription { get; set; }

        [Required]
        public int UserID { get; set; }

        [Required]
        public DateTime DateOfTaskDone { get; set; }

        [Required]
        public string Attachments { get; set; }

        [Required]
        public int TaskID { get; set; }

    }
}