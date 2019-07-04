using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ROQ.Admin.Helpers
{
    public static class CommonHelper
    {

        public static Dictionary<string, string> GetGenders()
        {
            Dictionary<string, string> genders = new Dictionary<string, string>
            {
                { "", "--Select--" },
                { "M", "Male" },
                { "F", "Female" }              
            };
            return genders;
        }
        public static Dictionary<string, string> Currencies()
        {
            Dictionary<string, string> currencies = new Dictionary<string, string>
            {
                { "", "--Select--" },
                { "$", "USD" },
                { "QAR", "QAR" }
            };
            return currencies;
        }
     
    }
}