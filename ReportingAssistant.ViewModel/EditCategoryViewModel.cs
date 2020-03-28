using System.ComponentModel.DataAnnotations;

namespace ReportingAssistant.ViewModel
{
    public class EditCategoryViewModel
    {
        public int CategoryID { get; set; }

        [Required]
        public string CategoryName { get; set; }
    }
}