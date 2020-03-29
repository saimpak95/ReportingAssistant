using AutoMapper;
using ReportingAssistant.DomainModel;
using ReportingAssistant.Repository;
using ReportingAssistant.ViewModel;
using System.Collections.Generic;

namespace ReportingAssistant.ServiceLayer
{
    public interface IProjectService
    {
        void InsertProject(NewProjectViewModel pvm);

        void UpdateProject(EditProjectDetailViewModel pvm);

        void DeleteProjects(int ProjectID);

        List<ProjectViewModel> GetProject();

        ProjectViewModel GetProjectByID(int ProjectID);
    }

    public class ProjectService : IProjectService
    {
        private IProjectRepository pr;

        public ProjectService()
        {
            pr = new ProjectRepository();
        }

        public void DeleteProjects(int ProjectID)
        {
            pr.DeleteProjects(ProjectID);
        }

        public List<ProjectViewModel> GetProject()
        {
            List<Projects> projects = pr.GetProject();
            List<ProjectViewModel> pvm = null;
            if (projects != null)
            {
                var Config = new MapperConfiguration(cfg => { cfg.CreateMap<Projects, ProjectViewModel>(); });
                IMapper mapper = Config.CreateMapper();
                pvm = mapper.Map<List<Projects>, List<ProjectViewModel>>(projects);
                return pvm;
            }
            else
                return pvm;
        }

        public ProjectViewModel GetProjectByID(int ProjectID)
        {
            Projects projects = pr.GetProjectByID(ProjectID);
            ProjectViewModel pvm = null;
            if (projects != null)
            {
                var Config = new MapperConfiguration(cfg => { cfg.CreateMap<Projects, ProjectViewModel>(); });
                IMapper mapper = Config.CreateMapper();
                pvm = mapper.Map<Projects, ProjectViewModel>(projects);
                return pvm;
            }
            else
                return pvm;
        }

        public void InsertProject(NewProjectViewModel pvm)
        {
            var Config = new MapperConfiguration(cfg => { cfg.CreateMap<NewProjectViewModel, Projects>(); });
            IMapper mapper = Config.CreateMapper();
            Projects projects = mapper.Map<NewProjectViewModel, Projects>(pvm);
            pr.InsertProject(projects);
        }

        public void UpdateProject(EditProjectDetailViewModel pvm)
        {
            var Config = new MapperConfiguration(cfg => { cfg.CreateMap<EditProjectDetailViewModel, Projects>(); });
            IMapper mapper = Config.CreateMapper();
            Projects projects = mapper.Map<EditProjectDetailViewModel, Projects>(pvm);
            pr.UpdateProject(projects);
        }
    }
}