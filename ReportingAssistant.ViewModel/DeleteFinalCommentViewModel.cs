using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ReportingAssistant.ViewModel
{
    public class DeleteFinalCommentViewModel
    {
        [Required]
        public int FinalCommentID { get; set; }

        public string Screen { get; set; }
        public string FinalCommentDescription { get; set; }
        public int UserID { get; set; }
        public DateTime DateOfFinalComment { get; set; }
        public string Attachments { get; set; }
        public int ProjectID { get; set; }

        public virtual List<UserViewModel> Users { get; set; }

        public virtual List<ProjectViewModel> Projects { get; set; }
    }
}