using ROQ.Common.Interface;
using ROQ.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ROQ.Repository.Interfaces
{
    public interface IUsersRepository : IRepository<Users>
    {
        List<Users> GetUserByID(long UserId);
        Users GetUserByUserName(string UserName);
        //  List<Users> GetUsersByRoleID(string RoleID);
    }
}
