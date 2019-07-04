//using AutoMapper;
using ROQ.Common.Core;
using ROQ.Common.Helper;
using ROQ.Data.Entities;
using ROQ.Repository.Interfaces;
using ROQ.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ROQ.Common.Security;
using ROQ.Services.ViewModels;

namespace ROQ.Services.Services
{
    public class UserService : ServiceBase<Users>, IUserService
    {
        IUsersRepository _IUserRepository;

        public UserService(IUsersRepository userRepository) : base(userRepository)
        {
            _IUserRepository = userRepository;
        }

        public List<Users> GetUserByID(long UserId)
        {
            return _IUserRepository.GetUserByID(UserId);
        }

        public long InsertUpdate(UsersVM usersVM)
        {
            long Id = 0;
            try
            {
                Users users = new Users();
                //pageContentDetails = Mapper.Map<OtherPageContentDetailsViewModel, PageContentDetails>(pageContentDetailsVM);
                if (usersVM.ID > 0)
                    users = _IUserRepository.Get(usersVM.ID);
                users.BirthDate = usersVM.BirthDate;
                users.EmailID = usersVM.EmailID;
                users.EmpNo = usersVM.EmpNo;
                users.FullName = usersVM.FullName;
                users.Gender = usersVM.Gender;
                users.IsPasswordReset = usersVM.IsPasswordReset;
                users.MobileNo = usersVM.MobileNo;
                users.UserName = usersVM.UserName;
                users.Password = usersVM.Password;
                users.IsActive = usersVM.IsActive;
               
                if (usersVM.ID > 0)
                {
                    users.ModifiedBy = Convert.ToInt32(users.ModifiedBy);
                    users.ModifiedDate = DateTime.Now;
                    _IUserRepository.Edit(users);
                }
                else
                {
                    users.IsPasswordReset = false;
                    users.CreatedBy = Convert.ToInt32(usersVM.CreatedBy);
                    users.CreationDate = DateTime.Now;
                    _IUserRepository.Add(users);
                }
                _IUserRepository.Save();
                Id = users.ID;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;
        }

        //public UsersViewModel AuthenticateLogin(string Username, string Password, ADHelper.ADDomain domain)
        //{        
        //    long UserId = 0;
        //    UsersViewModel usersViewModel = new UsersViewModel(); ;

        //    Username = Username.Split('@')[0].ToString();
        //    ADHelper activeDirectoryHelper = new ADHelper(domain);
        //    Boolean UserAuthenticated = activeDirectoryHelper.ValidateCredentials(Username, Password);
        //    //todeo: change CommonConstants.BuildMode=="debug" for testing
        //    if (UserAuthenticated == true || CommonConstants.BuildMode == "debug")
        //    {
        //        Users users = new Users();
        //        users = _IUserRepository.GetUserByUserName(Username);
        //        if (users.ID > 0)
        //        {
        //            usersViewModel = new UsersViewModel();
        //            usersViewModel = Mapper.Map<Users, UsersViewModel>(users);
        //           // UserId = usersViewModel.ID;
        //        }             
        //    }
        //    return usersViewModel;
        //}

    }
}
