﻿using System;
using System.ComponentModel.DataAnnotations;

namespace ReportingAssistant.ViewModel
{
    public class EditTaskDoneViewModel
    {
        [Required]
        public int TaskDoneID { get; set; }

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