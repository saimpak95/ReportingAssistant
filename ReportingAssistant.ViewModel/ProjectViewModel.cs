using System;

namespace ReportingAssistant.ViewModel
{
    public class ProjectViewModel
    {
        public int ProjectID { get; set; }

        public string ProjectName { get; set; }

        public DateTime DateOfStart { get; set; }

        public string AvailabilityStatus { get; set; }

        public int CategoryID { get; set; }

        public string Attachments { get; set; }

        public int AdminID { get; set; }

        public virtual CategoriesViewModel Categories { get; set; }
        public virtual UserViewModel users { get; set; }
    }
}