using System;
using System.Collections.Generic;

namespace ReportingAssistant.ViewModel
{
    public class ProjectViewModel
    {
        public string ProjectName { get; set; }

        public DateTime DateOfStart { get; set; }

        public string AvailabilityStatus { get; set; }

        public int CategoryID { get; set; }

        public string Image { get; set; }

        public int AdminID { get; set; }

        public virtual List<CategoriesViewModel> Categories { get; set; }

        public virtual List<UserViewModel> Users { get; set; }
    }
}