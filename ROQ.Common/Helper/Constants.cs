using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ROQ.Common.Helper
{
    public class CommonConstants
    {
        public static string BuildMode
        {
            get { return ConfigurationManager.AppSettings["BuildMode"].ToString(); }
        }
      //  public static bool EnableSendingNotifications = Convert.ToBoolean(ConfigurationManager.AppSettings["EnableSendingNotifications"].ToString());

    }
    //public class RoleConstant
    //{
    //    private RoleConstant(string value) { Value = value; }

    //    public string Value { get; set; }
    //    public static RoleConstant Leader { get { return new RoleConstant("LDR"); } }
    //    public static RoleConstant ROQManager { get { return new RoleConstant("SAM"); } }
    //    public static RoleConstant ROQsSupervisor { get { return new RoleConstant("SAS"); } }
    //    public static RoleConstant SchoolManager { get { return new RoleConstant("SCM"); } }
    //    public static RoleConstant Student { get { return new RoleConstant("STD"); } }
    //    public static RoleConstant ADM { get { return new RoleConstant("ADM"); } }
    //}
}
