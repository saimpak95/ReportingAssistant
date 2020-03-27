using System;
using System.Collections.Generic;

namespace ReportingAssistant.ViewModel
{
    public class TaskViewModel
    {
        public int TaskID { get; set; }

        public string Screen { get; set; }
        public string TaskDescription { get; set; }
        public int AdminID { get; set; }
        public int UserID { get; set; }
        public DateTime DateOfTask { get; set; }
        public string Attachments { get; set; }
        public int ProjectID { get; set; }

        public virtual List<ProjectViewModel> Projects { get; set; }

        public virtual List<UserViewModel> Users { get; set; }
    }
}