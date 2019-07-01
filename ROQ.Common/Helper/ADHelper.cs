using System;
using System.Collections.Generic;
using System.Configuration;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ROQ.Common.Helper
{
    public class ADUser
    {
        public string NameAr { get; set; }
        public string NameEN { get; set; }
        public string QID { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public List<string> Groups { get; set; }

    }
    public class ADHelper
    {
        private string domain;
        private string defaultOU;
        private string defaultRootOU;
        private string userName;
        private string password;
        private string defaultPrincipalName;

        public ADHelper()
        {
            domain = ConfigurationManager.AppSettings["DomainSECEDU"];
            defaultOU = ConfigurationManager.AppSettings["DefaultOUSECEDU"];
            defaultRootOU = ConfigurationManager.AppSettings["DefaultRootOUSECEDU"];
            userName = ConfigurationManager.AppSettings["UserNameSECEDU"];
            password = ConfigurationManager.AppSettings["PasswordSECEDU"];
            defaultPrincipalName = ConfigurationManager.AppSettings["DefaultPrincipalNameSECEDU"];
        }
        public enum ADDomain
        {
            SECEDU,
            QSEC,
            Anonymous
        }
        public ADHelper(ADDomain userType)
        {
            switch (userType)
            {

                case ADDomain.SECEDU:
                    domain = ConfigurationManager.AppSettings["DomainSECEDU"];
                    defaultOU = ConfigurationManager.AppSettings["DefaultOUSECEDU"];
                    defaultRootOU = ConfigurationManager.AppSettings["DefaultRootOUSECEDU"];
                    userName = ConfigurationManager.AppSettings["UserNameSECEDU"];
                    password = ConfigurationManager.AppSettings["PasswordSECEDU"];
                    defaultPrincipalName = ConfigurationManager.AppSettings["DefaultPrincipalNameSECEDU"];

                    break;
                case ADDomain.QSEC:
                    domain = ConfigurationManager.AppSettings["DomainQSEC"];
                    defaultOU = ConfigurationManager.AppSettings["DefaultOUQSEC"];
                    defaultRootOU = ConfigurationManager.AppSettings["DefaultRootOUQSEC"];
                    userName = ConfigurationManager.AppSettings["UserNameQSEC"];
                    password = ConfigurationManager.AppSettings["PasswordQSEC"];
                    defaultPrincipalName = ConfigurationManager.AppSettings["DefaultPrincipalNameQSEC"];

                    break;
            }

        }
        /// <summary>
        /// Gets the base principal context
        /// </summary>
        /// <returns>Returns the PrincipalContext object</returns>
        private PrincipalContext GetPrincipalContext()
        {
            PrincipalContext oPrincipalContext =
                new PrincipalContext(ContextType.Domain, domain, defaultRootOU,
                ContextOptions.SimpleBind, userName, password);
            // oPrincipalContext.Dispose();
            return oPrincipalContext;
        }
        /// <summary>
        /// Gets the principal context on specified OU
        /// </summary>
        /// <param name="sOU">The OU you want your Principal Context to run on</param>
        /// <returns>Returns the PrincipalContext object</returns>
        private PrincipalContext GetPrincipalContext(string sOU)
        {
            PrincipalContext oPrincipalContext =
               new PrincipalContext(ContextType.Domain, domain, "OU=" + sOU + "," + defaultRootOU,
               ContextOptions.SimpleBind, userName, password);
            //oPrincipalContext.Dispose();
            return oPrincipalContext;
        }
        /// <summary>
        /// Validates the username and password of a given user
        /// </summary>
        /// <param name="sUserName">The username to validate</param>
        /// <param name="sPassword">The password of the username to validate</param>
        /// <returns>Returns True of user is valid</returns>
        public bool ValidateCredentials(string sUserName, string sPassword)
        {
            PrincipalContext oPrincipalContext = GetPrincipalContext();
            bool flag = oPrincipalContext.ValidateCredentials(sUserName, sPassword);
            oPrincipalContext.Dispose();
            return flag;
        }
        /// <summary>
        /// Checks if user exists on AD
        /// </summary>
        /// <param name="sUserName">The username to check</param>
        /// <returns>Returns true if username Exists</returns>
        public bool IsUserExisiting(string sUserName)
        {
            if (GetUserDetails(sUserName) == null)
                return false;
            else
                return true;
        }
        /// <summary>
        /// Gets a certain user on Active Directory by username or emailid
        /// </summary>
        /// <param name="sUserName">Get user details by username or emailID</param>
        /// <returns>Returns the UserPrincipal Object</returns>
        public ADUser GetUserDetails(string sUserName)
        {
            ADUser userDetail = null;
            if (!string.IsNullOrEmpty(sUserName))
            {
                PrincipalContext oPrincipalContext = GetPrincipalContext();

                UserPrincipal oUserPrincipal =
                   UserPrincipal.FindByIdentity(oPrincipalContext, sUserName);
                userDetail = ConvertToAdUser(oUserPrincipal);
                oPrincipalContext.Dispose();
            }
            return userDetail;
        }

        private ADUser ConvertToAdUser(UserPrincipal oUserPrincipal)
        {
            //using (PrincipalSearchResult<Principal> groups = oUserPrincipal.GetAuthorizationGroups())
            //{
            //    var s = groups.OfType<GroupPrincipal>().Any(g => g.Name.Equals(groupname, StringComparison.OrdinalIgnoreCase));
            //}

            return new ADUser
            {
                QID = oUserPrincipal?.EmployeeId,
                Email = oUserPrincipal?.EmailAddress,
                UserName = oUserPrincipal?.SamAccountName,
                NameAr = oUserPrincipal?.DisplayName,
                NameEN = oUserPrincipal?.GivenName,
                Groups = oUserPrincipal?.GetAuthorizationGroups().Select(g => g.Name).ToList()
            };
        }
        public ADUser FindNameByQID(string QID)
        {
            ADUser aDUser = new ADUser();
            try
            {


                DirectoryEntry entry = new DirectoryEntry("LDAP://" + domain + "/" + defaultRootOU, userName, password);

                DirectorySearcher search = new DirectorySearcher(entry);
                // search.Filter = "(&(objectCategory=person)(sAMAccountName=*)(mail=" + emailAddress + "))";
                search.Filter = string.Format("(employeeID={0})", QID);
                string[] properties = new string[] { "SAMAccountName" };
                //foreach (String property in properties)
                //    search.PropertiesToLoad.Add(property);
                //search.Filter = "(sAMAccountName=Uname)";
                SearchResult result = search.FindOne();
                StringBuilder str = new StringBuilder();
                ResultPropertyCollection prop = result.Properties;
                var coll = prop.PropertyNames;
              
                if (result != null)
                {
                    aDUser = new ADUser
                    {
                        QID = (string)result.Properties["EmployeeId"][0],//oUserPrincipal?.EmployeeId,
                        Email = (string)result.Properties["mail"][0],// oUserPrincipal?.,
                        UserName = (string)result.Properties["SAMAccountName"][0],
                        NameAr = (string)result.Properties["DisplayName"][0],//oUserPrincipal?.DisplayName,
                        NameEN = (string)result.Properties["GivenName"][0],// oUserPrincipal?.GivenName,
                                                                           //Groups = (string)result.Properties["EmailAddress"][0]// oUserPrincipal?.GetAuthorizationGroups().Select(g => g.Name).ToList()
                    };
                }
            }
            catch (Exception ex)
            {
                // throw;
            }
            return aDUser;
        }
    }

}
