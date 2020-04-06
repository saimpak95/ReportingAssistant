using AutoMapper;
using ReportingAssistant.DomainModel;
using ReportingAssistant.Repository;
using ReportingAssistant.ViewModel;
using System.Collections.Generic;

namespace ReportingAssistant.ServiceLayer
{
    public interface ITaskService
    {
        void InsertTask(NewTaskViewModel tvm);

        void UpdateTask(EditTaskViewModel tvm);

        void DeleteTask(int TaskID);

        List<TaskViewModel> GetTasks();

        TaskViewModel GetTasksByID(int TaskID);
    }

    public class TaskService : ITaskService
    {
        private ITaskrepository tr;

        public TaskService()
        {
            tr = new TaskRepository();
        }

        public void DeleteTask(int TaskID)
        {
            tr.DeleteTask(TaskID);
        }

        public List<TaskViewModel> GetTasks()
        {
            List<Tasks> tasks = tr.GetTasks();
            var Config = new MapperConfiguration(cfg => { cfg.CreateMap<Tasks, TaskViewModel>(); cfg.CreateMap<Users, UserViewModel>(); cfg.CreateMap<Projects, ProjectViewModel>(); cfg.CreateMap<Categories, CategoriesViewModel>(); });
            IMapper mapper = Config.CreateMapper();
            List<TaskViewModel> tvm = mapper.Map<List<Tasks>, List<TaskViewModel>>(tasks);
            return tvm;
        }

        public TaskViewModel GetTasksByID(int TaskID)
        {
            Tasks tasks = tr.GetTasksByID(TaskID);
            TaskViewModel tvm = null;
            if (tasks != null)
            {
                var Config = new MapperConfiguration(cfg => { cfg.CreateMap<Tasks, TaskViewModel>(); cfg.CreateMap<Users, UserViewModel>(); cfg.CreateMap<Projects, ProjectViewModel>(); cfg.CreateMap<Categories, CategoriesViewModel>(); });
                IMapper mapper = Config.CreateMapper();
                tvm = mapper.Map<Tasks, TaskViewModel>(tasks);
                return tvm;
            }
            else
                return tvm;
        }

        public void InsertTask(NewTaskViewModel tvm)
        {
            var Config = new MapperConfiguration(cfg => { cfg.CreateMap<NewTaskViewModel, Tasks>(); });
            IMapper mapper = Config.CreateMapper();
            Tasks tasks = mapper.Map<NewTaskViewModel, Tasks>(tvm);
            tr.InsertTask(tasks);
        }

        public void UpdateTask(EditTaskViewModel tvm)
        {
            var Config = new MapperConfiguration(cfg => { cfg.CreateMap<EditTaskViewModel, Tasks>(); });
            IMapper mapper = Config.CreateMapper();
            Tasks tasks = mapper.Map<EditTaskViewModel, Tasks>(tvm);
            tr.UpdateTask(tasks);
        }
    }
}