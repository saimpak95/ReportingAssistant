using System;
using System.Collections.Generic;

namespace ReportingAssistant.ViewModel
{
    public class TaskDoneViewModel
    {
        public int TaskDoneID { get; set; }

        public string Screen { get; set; }
        public string TaskDoneDescription { get; set; }
        public int UserID { get; set; }
        public DateTime DateOfTaskDone { get; set; }
        public string Attachments { get; set; }
        public int TaskID { get; set; }

        public virtual List<UserViewModel> Users { get; set; }

        public virtual List<TaskViewModel> Tasks { get; set; }
    }
}