using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ReportingAssistant.ViewModel
{
    public class NewProjectViewModel
    {
        [Required]
        public string ProjectName { get; set; }

        [Required]
        public DateTime DateOfStart { get; set; }

        [Required]
        public string AvailabilityStatus { get; set; }

        [Required]
        public int CategoryID { get; set; }

        public string Attachments { get; set; }

        [Required]
        public int AdminID { get; set; }

        public virtual List<CategoriesViewModel> Categories { get; set; }

        public virtual List<UserViewModel> Users { get; set; }
    }
}