using ReportingAssistant.DomainModel;
using System.Collections.Generic;
using System.Linq;

namespace ReportingAssistant.Repository
{
    public interface IProjectRepository
    {
        void InsertProject(Projects projects);

        void UpdateProject(Projects projects);

        void DeleteProjects(int ProjectID);

        List<Projects> GetProject();

        Projects GetProjectByID(int ProjectID);
    }

    public class ProjectRepository : IProjectRepository
    {
        private ReportingAssistantDBContext db;

        public ProjectRepository()
        {
            db = new ReportingAssistantDBContext();
        }

        public void DeleteProjects(int ProjectID)
        {
            Projects project = db.projects.Where(temp => temp.ProjectID == ProjectID).FirstOrDefault();
            db.projects.Remove(project);
            db.SaveChanges();
        }

        public List<Projects> GetProject()
        {
            List<Projects> projects = db.projects.OrderByDescending(temp => temp.ProjectID).ToList();
            return projects;
        }

        public Projects GetProjectByID(int ProjectID)
        {
            Projects project = db.projects.Where(temp => temp.ProjectID == ProjectID).FirstOrDefault();
            return project;
        }

        public void InsertProject(Projects projects)
        {
            db.projects.Add(projects);
            db.SaveChanges();
        }

        public void UpdateProject(Projects projects)
        {
            Projects ExistingProject = db.projects.Where(temp => temp.ProjectID == projects.ProjectID && temp.AdminID == projects.AdminID).FirstOrDefault();
            ExistingProject.ProjectName = projects.ProjectName;
            ExistingProject.AvailabilityStatus = projects.AvailabilityStatus;
            ExistingProject.CategoryID = projects.CategoryID;
            ExistingProject.AdminID = projects.AdminID;
            ExistingProject.Attachments = projects.Attachments;
            db.SaveChanges();
        }
    }
}