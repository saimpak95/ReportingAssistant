using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReportingAssistant.DomainModel
{
    public class FinalComments
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FinalCommentID { get; set; }

        public string Screen { get; set; }
        public string FinalCommentDescription { get; set; }
        public int UserID { get; set; }
        public DateTime DateOfFinalComment { get; set; }
        public string Attachments { get; set; }
        public int ProjectID { get; set; }

        [ForeignKey("UserID")]
        public virtual Users Users { get; set; }

        [ForeignKey("ProjectID")]
        public virtual Projects Projects { get; set; }
    }
}