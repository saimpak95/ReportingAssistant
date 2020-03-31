using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReportingAssistant.DomainModel
{
    public class Projects
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProjectID { get; set; }

        public string ProjectName { get; set; }
        public DateTime DateOfStart { get; set; }
        public string AvailabilityStatus { get; set; }
        public int CategoryID { get; set; }
        public string Attachments { get; set; }

        public int AdminID { get; set; }

        [ForeignKey("CategoryID")]
        public virtual Categories Categories { get; set; }

        [ForeignKey("AdminID")]
        public virtual Users Users { get; set; }
    }
}