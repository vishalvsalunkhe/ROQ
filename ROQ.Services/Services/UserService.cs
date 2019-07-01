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
