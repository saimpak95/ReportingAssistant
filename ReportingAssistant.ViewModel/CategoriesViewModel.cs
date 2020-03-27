using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportingAssistant.ViewModel
{
    public class CategoriesViewModel
    {
        [Required]
        public int CategoryID { get; set; }

        [Required]
        public string CategoryName { get; set; }
    }
}
