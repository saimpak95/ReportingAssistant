using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReportingAssistant.DomainModel
{
    public class Users
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserID { get; set; }

        public string UserName { get; set; }
        public string PasswordHash { get; set; }
        public string Phone { get; set; }
        public string Gender { get; set; }
        public int IsAdmin { get; set; }
    }
}