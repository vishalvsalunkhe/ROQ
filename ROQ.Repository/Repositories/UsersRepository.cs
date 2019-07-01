using ROQ.Common;
using ROQ.Data;
using ROQ.Data.Entities;
using ROQ.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ROQ.Repository.Repositories
{
    public class UsersRepository : RepositoryBase<Users, ROQDBContext>, IUsersRepository
    {
        public UsersRepository(ROQDBContext context) : base(context)
        {

        }

        public List<Users> GetUserByID(long UserId)
        {
            var result = Context.Users.ToList();
            return result;
        }
        public Users GetUserByUserName(string UserName)
        {
            var result = Context.Users.FirstOrDefault(x => x.UserName == UserName);
            if (result == null)
                return new Users();

            return result;
        }
        //public List<PersonalDetails> GetUsersByRole(string RoleID)
        //{
        //    var result = Context.PersonalDetails
        //        .Include("Users")
        //        .Where(x => x.Users.Role_ID == RoleID && x.Users.IsActive == true);
        //    if (result == null)
        //        return new List<PersonalDetails>();

        //    return result.ToList();
        //}
    }
}
