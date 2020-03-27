﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ReportingAssistant.ViewModel
{
    internal class EditTaskViewModel
    {
        [Required]
        public int TaskID { get; set; }

        [Required]
        public string Screen { get; set; }

        [Required]
        public string TaskDescription { get; set; }

        [Required]
        public int AdminID { get; set; }

        [Required]
        public int UserID { get; set; }

        [Required]
        public DateTime DateOfTask { get; set; }

        [Required]
        public string Attachments { get; set; }

        [Required]
        public int ProjectID { get; set; }

        public virtual List<ProjectViewModel> Projects { get; set; }

        public virtual List<UserViewModel> Users { get; set; }
    }
}