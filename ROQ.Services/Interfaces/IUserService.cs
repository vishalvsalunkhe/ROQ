using ROQ.Common.Interface;
using ROQ.Data.Entities;
using ROQ.Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using static ROQ.Common.Helper.ADHelper;

namespace ROQ.Services.Interfaces
{
    public interface IUserService : IService<Users>
    {
        // UsersViewModel AuthenticateLogin(string Username, string Password, ADDomain domain);
        List<Users> GetUserByID(long UserId);
        //IEnumerable<Users> GetAllPrograms(int NoOfRecords, string ProgramFor, Boolean RefreshContext = false);
        //IEnumerable<ProgramActivitiesViewModel> GetProgramActivities(long ProgramID, string ProgramFor, Boolean RefreshContext = false);
        long InsertUpdate(UsersVM usersVM);
        //long InsertUpdateActivities(ProgramActivitiesViewModel ProgramActivitiesViewModel);
        //long DeleteProgram(long id);
        //ProgramViewModel GetProgramWithActivities(long programID, Boolean RefreshContext = false);
        //void DeleteProgramActivity(long id);
    }
}
