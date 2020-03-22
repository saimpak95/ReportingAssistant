using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReportingAssistant.DomainModel
{
    public class TasksDone
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TaskDoneID { get; set; }

        public string Screen { get; set; }
        public string TaskDoneDescription { get; set; }
        public int UserID { get; set; }
        public DateTime DateOfTaskDone { get; set; }
        public string Attachments { get; set; }
        public int TaskID { get; set; }

        [ForeignKey("UserID")]
        public virtual Users Users { get; set; }

        [ForeignKey("TaskID")]
        public virtual Tasks Tasks { get; set; }
    }
}