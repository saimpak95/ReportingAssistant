using AutoMapper;
using ReportingAssistant.DomainModel;
using ReportingAssistant.Repository;
using ReportingAssistant.ViewModel;
using System.Collections.Generic;

namespace ReportingAssistant.ServiceLayer
{
    public interface ITaskDoneService
    {
        void InsertTaskDone(NewTaskDoneViewModel tdvm);

        void UpdateTaskDone(EditTaskDoneViewModel tdvm);

        void DeleteTaskDone(int TaskDoneID);

        List<TaskDoneViewModel> GetTasksDones();

        TaskDoneViewModel GetTasksDoneByID(int TasksDoneID);
    }

    public class TaskDoneService : ITaskDoneService
    {
        private ITaskDoneRepository tdr;

        public TaskDoneService()
        {
            tdr = new TaskDoneRepository();
        }

        public void DeleteTaskDone(int TaskDoneID)
        {
            tdr.DeleteTaskDone(TaskDoneID);
        }

        public TaskDoneViewModel GetTasksDoneByID(int TasksDoneID)
        {
            TasksDone tasksDone = tdr.GetTasksDoneByID(TasksDoneID);
            TaskDoneViewModel tdvm = null;
            if (tasksDone != null)
            {
                var Config = new MapperConfiguration(cfg => { cfg.CreateMap<TasksDone, TaskDoneViewModel>(); cfg.CreateMap<Users, UserViewModel>(); cfg.CreateMap<Tasks, TaskViewModel>(); });
                IMapper mapper = Config.CreateMapper();
                tdvm = mapper.Map<TasksDone, TaskDoneViewModel>(tasksDone);
                return tdvm;
            }
            else
                return tdvm;
        }

        public List<TaskDoneViewModel> GetTasksDones()
        {
            List<TasksDone> tasksDone = tdr.GetTasksDones();

            var Config = new MapperConfiguration(cfg => { cfg.CreateMap<TasksDone, TaskDoneViewModel>(); cfg.CreateMap<Users, UserViewModel>(); cfg.CreateMap<Tasks, TaskViewModel>(); });
            IMapper mapper = Config.CreateMapper();
            List<TaskDoneViewModel> tdvm = mapper.Map<List<TasksDone>, List<TaskDoneViewModel>>(tasksDone);
            return tdvm;
        }

        public void InsertTaskDone(NewTaskDoneViewModel tdvm)
        {
            var Config = new MapperConfiguration(cfg => { cfg.CreateMap<NewTaskDoneViewModel, TasksDone>(); });
            IMapper mapper = Config.CreateMapper();
            TasksDone tasksDone = mapper.Map<NewTaskDoneViewModel, TasksDone>(tdvm);
            tdr.InsertTaskDone(tasksDone);
        }

        public void UpdateTaskDone(EditTaskDoneViewModel tdvm)
        {
            var Config = new MapperConfiguration(cfg => { cfg.CreateMap<EditTaskDoneViewModel, TasksDone>(); });
            IMapper mapper = Config.CreateMapper();
            TasksDone tasksDone = mapper.Map<EditTaskDoneViewModel, TasksDone>(tdvm);
            tdr.UpdateTaskDone(tasksDone);
        }
    }
}