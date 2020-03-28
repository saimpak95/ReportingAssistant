using ReportingAssistant.DomainModel;
using System.Collections.Generic;
using System.Linq;

namespace ReportingAssistant.Repository
{
    public interface IUsersRepository
    {
        void InserUser(Users users);

        void UpdateUserDetails(Users users);

        void UpdateUserPassword(Users users);

        void DeleteUser(int UserID);

        List<Users> GetUsers();

        Users GetUsersByEmailAndPassword(string Email, string Password);

        Users GetUsersByEmail(string Email);

        Users GetUsersByUserID(int UserID);

        int GetLatestUserID();
    }

    public class UsersRepository : IUsersRepository
    {
        private ReportingAssistantDBContext db;

        public UsersRepository()
        {
            db = new ReportingAssistantDBContext();
        }

        public void DeleteUser(int UserID)
        {
            Users user = db.users.Where(temp => temp.UserID == UserID).FirstOrDefault();
            if (user != null)
            {
                db.users.Remove(user);
                db.SaveChanges();
            }
        }

        public int GetLatestUserID()
        {
            int LastestID = db.users.Select(temp => temp.UserID).Max();
            return LastestID;
        }

        public List<Users> GetUsers()
        {
            List<Users> users = db.users.Where(temp => temp.Role == "User").ToList();
            return users;
        }

        public Users GetUsersByEmail(string Email)
        {
            Users user = db.users.Where(temp => temp.Email == Email).FirstOrDefault();
            return user;
        }

        public Users GetUsersByEmailAndPassword(string Email, string Password)
        {
            Users user = db.users.Where(temp => temp.Email == Email && temp.PasswordHash == Password).FirstOrDefault();
            return user;
        }

        public Users GetUsersByUserID(int UserID)
        {
            Users user = db.users.Where(temp => temp.UserID == UserID).FirstOrDefault();
            return user;
        }

        public void InserUser(Users users)
        {
            db.users.Add(users);
            db.SaveChanges();
        }

        public void UpdateUserDetails(Users users)
        {
            Users ExistingAccount = db.users.Where(temp => temp.UserID == users.UserID).FirstOrDefault();
            if (ExistingAccount != null)
            {
                ExistingAccount.UserName = users.UserName;
                ExistingAccount.Gender = users.UserName;
                ExistingAccount.Phone = users.Phone;
                db.SaveChanges();
            }
        }

        public void UpdateUserPassword(Users users)
        {
            Users ExistingAccount = db.users.Where(temp => temp.UserID == users.UserID).FirstOrDefault();
            if (ExistingAccount != null)
            {
                ExistingAccount.PasswordHash = users.PasswordHash;
                db.SaveChanges();
            }
        }
    }
}