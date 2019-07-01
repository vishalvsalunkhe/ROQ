using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace ROQ.Common.Helper
{
    public enum LogType
    {
        ERROR,
        INFO,
        DEBUG
    }
    public class Logging
    {
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public static void log(LogType type,string message="",object data = null,Exception ex=null)
        {
            string dataValues="";
            try
            {           
            if(data!=null)
             dataValues = string.Format(" Data : {0}", new JavaScriptSerializer().Serialize(data));
            }
            catch (Exception)
            {

            }

            message = string.Format("{0}{1}", message, dataValues);
            switch (type)
            {
                case LogType.DEBUG:
                    logger.Debug(message);
                    break;
                case LogType.INFO:
                    logger.Info(message);
                    break;
                case LogType.ERROR:
                    logger.Error(message,ex);
                    break;
                default:
                    logger.Info(message);
                    break;
            }
        }
    }
}