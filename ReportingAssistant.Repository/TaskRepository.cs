using ReportingAssistant.DomainModel;
using System.Collections.Generic;
using System.Linq;


namespace ReportingAssistant.Repository
{
    public interface ITaskrepository
    {
        void InsertTask(Tasks task);
        void UpdateTask(Tasks tasks);
        void DeleteTask(int TaskID);
        List<Tasks> GetTasks();
        Tasks GetTasksByID(int TaskID);
    }
    public class TaskRepository : ITaskrepository
    {
        ReportingAssistantDBContext db;
        public TaskRepository()
        {
            db = new ReportingAssistantDBContext();
        }
        public void DeleteTask(int TaskID)
        {
            Tasks tasks = db.tasks.Where(temp => temp.TaskID == TaskID).FirstOrDefault();
            db.tasks.Remove(tasks);
            db.SaveChanges();
        }

        public List<Tasks> GetTasks()
        {
            List<Tasks> tasks = db.tasks.ToList();
            return tasks;
        }

        public Tasks GetTasksByID(int TaskID)
        {
            Tasks tasks = db.tasks.Where(temp => temp.TaskID == TaskID).FirstOrDefault();
            return tasks;
        }

        public void InsertTask(Tasks task)
        {
            db.tasks.Add(task);
            db.SaveChanges();
        }

        public void UpdateTask(Tasks tasks)
        {

            Tasks ExistngTask = db.tasks.Where(temp => temp.TaskID == tasks.TaskID).FirstOrDefault();
            if (ExistngTask != null) {
                ExistngTask.Screen = tasks.Screen;
                ExistngTask.TaskDescription = tasks.TaskDescription;
                ExistngTask.AdminID = tasks.AdminID;
                ExistngTask.UserID = tasks.UserID;
                ExistngTask.DateOfTask = tasks.DateOfTask;
                ExistngTask.Attachments = tasks.Attachments;
                ExistngTask.ProjectID = tasks.ProjectID;
                db.SaveChanges();

            }
          
        }
    }
}
