using AutoMapper;
using ReportingAssistant.DomainModel;
using ReportingAssistant.Repository;
using ReportingAssistant.ViewModel;
using System.Collections.Generic;

namespace ReportingAssistant.ServiceLayer
{
    public interface IFinalComment
    {
        void InsertFinalComment(NewFinalCommentViewModel fcvm);

        void UpdateFinalComment(EditFinalCommentViewModel fcvm);

        void DeleteFinalComment(int FinalCommentID);

        List<FinalCommentViewModel> GetFinalComment();

        FinalCommentViewModel GetFinalCommentByID(int FinalCommentID);
    }

    public class FinalCommentService : IFinalComment
    {
        private IFinalCommentRepository fr;

        public FinalCommentService()
        {
            fr = new FinalCommentRepository();
        }

        public void DeleteFinalComment(int FinalCommentID)
        {
            fr.DeleteFinalComment(FinalCommentID);
        }

        public List<FinalCommentViewModel> GetFinalComment()
        {
            List<FinalComments> finalComments = fr.GetFinalComment();
            var Config = new MapperConfiguration(cfg => { cfg.CreateMap<FinalComments, FinalCommentViewModel>(); cfg.CreateMap<Users, UserViewModel>(); cfg.CreateMap<Projects, ProjectViewModel>(); });
            IMapper mapper = Config.CreateMapper();
            List<FinalCommentViewModel> fcvm = mapper.Map<List<FinalComments>, List<FinalCommentViewModel>>(finalComments);
            return fcvm;
        }

        public FinalCommentViewModel GetFinalCommentByID(int FinalCommentID)
        {
            FinalComments finalComments = fr.GetFinalCommentByID(FinalCommentID);
            FinalCommentViewModel fcvm = null;
            if (finalComments != null)
            {
                var Config = new MapperConfiguration(cfg => { cfg.CreateMap<FinalComments, FinalCommentViewModel>(); cfg.CreateMap<Users, UserViewModel>(); cfg.CreateMap<Projects, ProjectViewModel>(); });
                IMapper mapper = Config.CreateMapper();
                fcvm = mapper.Map<FinalComments, FinalCommentViewModel>(finalComments);
                return fcvm;
            }
            else
                return fcvm;
        }

        public void InsertFinalComment(NewFinalCommentViewModel fcvm)
        {
            var Config = new MapperConfiguration(cfg => { cfg.CreateMap<NewFinalCommentViewModel, FinalComments>(); });
            IMapper mapper = Config.CreateMapper();
            FinalComments finalComments = mapper.Map<NewFinalCommentViewModel, FinalComments>(fcvm);
            fr.InsertFinalComment(finalComments);
        }

        public void UpdateFinalComment(EditFinalCommentViewModel fcvm)
        {
            var Config = new MapperConfiguration(cfg => { cfg.CreateMap<EditFinalCommentViewModel, FinalComments>(); });
            IMapper mapper = Config.CreateMapper();
            FinalComments finalComments = mapper.Map<EditFinalCommentViewModel, FinalComments>(fcvm);
            fr.UpdateFinalComment(finalComments);
        }
    }
}