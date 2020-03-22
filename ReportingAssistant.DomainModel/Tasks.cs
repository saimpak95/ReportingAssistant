using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReportingAssistant.DomainModel
{
    public class Tasks
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TaskID { get; set; }

        public string Screen { get; set; }
        public string TaskDescription { get; set; }
        public int AdminID { get; set; }
        public int UserID { get; set; }
        public DateTime DateOfTask { get; set; }
        public string Attachements { get; set; }

        [ForeignKey("Projects")]
        public virtual Projects Projects { get; set; }
       
        [ForeignKey("AdminID")]
        public virtual Users Users { get; set; }
    }
}