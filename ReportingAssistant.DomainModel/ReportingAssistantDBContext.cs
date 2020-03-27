using System.Data.Entity;

namespace ReportingAssistant.DomainModel
{
    public class ReportingAssistantDBContext : DbContext
    {       
        public DbSet<Users> users { get; set; }
        public DbSet<Categories> categories { get; set; }
        public DbSet<Projects> projects { get; set; }
        public DbSet<Tasks> tasks { get; set; }
        public DbSet<TasksDone> tasksDones { get; set; }
        public DbSet<FinalComments> finalComments { get; set; }
    }
}