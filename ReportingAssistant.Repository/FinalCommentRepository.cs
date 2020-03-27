using ReportingAssistant.DomainModel;
using System.Collections.Generic;
using System.Linq;

namespace ReportingAssistant.Repository
{
    public interface IFinalCommentRepository
    {
        void InsertFinalComment(FinalComments Task);

        void UpdateFinalComment(FinalComments Task);

        void DeleteFinalComment(int FinalCommentID);

        List<FinalComments> GetFinalComment();

        FinalComments GetFinalCommentByID(int FinalCommentID);
    }

    public class FinalCommentRepository : IFinalCommentRepository
    {
        private ReportingAssistantDBContext db;

        public FinalCommentRepository()
        {
            db = new ReportingAssistantDBContext();
        }

        public void DeleteFinalComment(int FinalCommentID)
        {
            FinalComments ExistingFinalComment = db.finalComments.Where(temp => temp.FinalCommentID == FinalCommentID).FirstOrDefault();
            if (ExistingFinalComment != null)
            {
                db.finalComments.Remove(ExistingFinalComment);
                db.SaveChanges();
            }
        }

        public List<FinalComments> GetFinalComment()
        {
            List<FinalComments> ExistingFinalCommentList = db.finalComments.ToList();
            return ExistingFinalCommentList;
        }

        public FinalComments GetFinalCommentByID(int FinalCommentID)
        {
            FinalComments ExistingFinalComment = db.finalComments.Where(temp => temp.FinalCommentID == FinalCommentID).FirstOrDefault();
            return ExistingFinalComment;
        }

        public void InsertFinalComment(FinalComments Task)
        {
            db.finalComments.Add(Task);
            db.SaveChanges();
        }

        public void UpdateFinalComment(FinalComments Task)
        {
            FinalComments ExistingTaskDone = db.finalComments.Where(temp => temp.FinalCommentID == Task.FinalCommentID).FirstOrDefault();
            if (ExistingTaskDone != null)
            {
                ExistingTaskDone.Screen = Task.Screen;
                ExistingTaskDone.FinalCommentDescription = Task.FinalCommentDescription;
                ExistingTaskDone.DateOfFinalComment = Task.DateOfFinalComment;
                ExistingTaskDone.Attachments = Task.Attachments;
                db.SaveChanges();
            }
        }
    }
}