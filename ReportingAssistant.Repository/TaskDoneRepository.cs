using ReportingAssistant.DomainModel;
using System.Collections.Generic;
using System.Linq;

namespace ReportingAssistant.Repository
{
    public interface ITaskDoneRepository {

        void InsertTaskDone(TasksDone Task);
        void UpdateTaskDone(TasksDone Task);
        void DeleteTaskDone(int TaskDoneID);
        List<TasksDone> GetTasksDones();
        TasksDone GetTasksDoneByID(int TasksDoneID);
    
    }
    public class TaskDoneRepository :ITaskDoneRepository
    {
        ReportingAssistantDBContext db;
        public TaskDoneRepository()
        {
            db = new ReportingAssistantDBContext();
        }

        public void DeleteTaskDone(int TaskDoneID)
        {
            TasksDone ExistingTaskDone = db.tasksDones.Where(temp => temp.TaskDoneID == TaskDoneID).FirstOrDefault();
            if (ExistingTaskDone != null) {
                db.tasksDones.Remove(ExistingTaskDone);
                db.SaveChanges();
            }
            
        }

        public TasksDone GetTasksDoneByID(int TasksDoneID)
        {
            TasksDone ExistingTaskDone = db.tasksDones.Where(temp => temp.TaskDoneID == TasksDoneID).FirstOrDefault();
            return ExistingTaskDone;

        }

        public List<TasksDone> GetTasksDones()
        {
            List<TasksDone> TasksDoneList = db.tasksDones.ToList();
            return TasksDoneList;
        }

        public void InsertTaskDone(TasksDone Task)
        {
            db.tasksDones.Add(Task);
            db.SaveChanges();
        }

        public void UpdateTaskDone(TasksDone Task)
        {
            TasksDone ExistingTaskDone = db.tasksDones.Where(temp => temp.TaskDoneID == Task.TaskDoneID).FirstOrDefault();
            if (ExistingTaskDone != null) {
                ExistingTaskDone.Screen = Task.Screen;
                ExistingTaskDone.TaskDoneDescription = Task.TaskDoneDescription;
                ExistingTaskDone.DateOfTaskDone = Task.DateOfTaskDone;
                ExistingTaskDone.Attachments = Task.Attachments;
                db.SaveChanges();
            }
          
        }
    }
}
