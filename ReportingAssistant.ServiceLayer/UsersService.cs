using AutoMapper;
using ReportingAssistant.DomainModel;
using ReportingAssistant.Repository;
using ReportingAssistant.ViewModel;
using System.Collections.Generic;

namespace ReportingAssistant.ServiceLayer
{
    public interface IUsersService
    {
        int InserUser(RegisterViewModel uvm);

        void UpdateUserDetails(EditUserProfileViewModel uvm);

        void UpdateUserPassword(EditUserPasswordViewModel uvm);

        void DeleteUser(int UserID);

        List<UserViewModel> GetUsers();

        UserViewModel GetUsersByEmailAndPassword(string Email, string Password);

        UserViewModel GetUsersByEmail(string Email);

        UserViewModel GetUsersByUserID(int UserID);
    }

    public class UsersService : IUsersService
    {
        private IUsersRepository ur;

        public UsersService()
        {
            ur = new UsersRepository();
        }

        public void DeleteUser(int UserID)
        {
            ur.DeleteUser(UserID);
        }

        public List<UserViewModel> GetUsers()
        {
            List<Users> users = ur.GetUsers();
            var Config = new MapperConfiguration(cfg => { cfg.CreateMap<Users, UserViewModel>(); });
            IMapper mapper = Config.CreateMapper();
            List<UserViewModel> uvm = mapper.Map<List<Users>, List<UserViewModel>>(users);
            return uvm;
        }

        public UserViewModel GetUsersByEmail(string Email)
        {
            Users user = ur.GetUsersByEmail(Email);
            UserViewModel uvm = null;
            if (user != null)
            {
                var Config = new MapperConfiguration(cfg => { cfg.CreateMap<Users, UserViewModel>(); });
                IMapper mapper = Config.CreateMapper();
                uvm = mapper.Map<Users, UserViewModel>(user);
                return uvm;
            }
            else
             return uvm;
        }

        public UserViewModel GetUsersByEmailAndPassword(string Email, string Password)
        {
            Users users = ur.GetUsersByEmailAndPassword(Email, SHA256Converter.GenerateHash(Password));
            UserViewModel uvm = null;
            if (users != null)
            {
                var Config = new MapperConfiguration(cfg => { cfg.CreateMap<Users, UserViewModel>(); });
                IMapper mapper = Config.CreateMapper();
                uvm = mapper.Map<Users, UserViewModel>(users);
                return uvm;
            }
            else
                return uvm;
        }

        public UserViewModel GetUsersByUserID(int UserID)
        {
            Users user = ur.GetUsersByUserID(UserID);
            var Config = new MapperConfiguration(cfg => { cfg.CreateMap<Users, UserViewModel>(); });
            IMapper mapper = Config.CreateMapper();
            UserViewModel uvm = mapper.Map<Users, UserViewModel>(user);
            return uvm;
        }

        public int InserUser(RegisterViewModel uvm)
        {
            var Config = new MapperConfiguration(cfg => { cfg.CreateMap<RegisterViewModel, Users>(); });
            IMapper mapper = Config.CreateMapper();
            Users users = mapper.Map<RegisterViewModel, Users>(uvm);
            users.PasswordHash = SHA256Converter.GenerateHash(uvm.Password);
            ur.InserUser(users);
            int LatestUserID = ur.GetLatestUserID();
            return LatestUserID;
        }

        public void UpdateUserDetails(EditUserProfileViewModel uvm)
        {
            var Config = new MapperConfiguration(cfg => { cfg.CreateMap<EditUserProfileViewModel, Users>(); });
            IMapper mapper = Config.CreateMapper();
            Users users = mapper.Map<EditUserProfileViewModel, Users>(uvm);
            ur.UpdateUserDetails(users);
        }

        public void UpdateUserPassword(EditUserPasswordViewModel uvm)
        {
            var Config = new MapperConfiguration(cfg => { cfg.CreateMap<EditUserPasswordViewModel, Users>(); });
            IMapper mapper = Config.CreateMapper();
            Users users = mapper.Map<EditUserPasswordViewModel, Users>(uvm);
            ur.UpdateUserPassword(users);
        }
    }
}