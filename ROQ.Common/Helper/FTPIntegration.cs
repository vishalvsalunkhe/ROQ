using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ROQ.Common.Helper
{
    public static class FTPIntegration
    {
        public static string UploadFile(string FileBase64, string FileExtension, string FileNamePrefix = "")
        {
            string FileName = "";
            try
            {
                string FTPServerIP = ConfigurationManager.AppSettings["FTPUrl"];
                string UserID = ConfigurationManager.AppSettings["FTPUserName"];
                string Password = ConfigurationManager.AppSettings["FTPPassword"];

                string CurrYear = DateTime.Now.Year.ToString();
                string CurrMonth = DateTime.Now.Month.ToString();
                string TodayDay = DateTime.Now.Day.ToString();
                FileName = Guid.NewGuid().ToString() + "-" + CurrYear + CurrMonth + TodayDay + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() +
                    DateTime.Now.Second.ToString() + FileExtension;
                if (FileNamePrefix.Length > 0)
                    FileName = FileNamePrefix + FileName;

                string DynamicFolderPath = "";
                string FtpFileLocation = FTPServerIP + DynamicFolderPath + "/" + CurrYear + "/";
                DynamicFolderPath += "/" + CurrYear + "/";
                CheckFolderExist(FtpFileLocation, UserID, Password);

                FtpFileLocation = FtpFileLocation + FileName;

                // Get the object used to communicate with the server.  
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(FtpFileLocation);
                request.Method = WebRequestMethods.Ftp.UploadFile;

                // This example assumes the FTP site uses anonymous logon.  
                request.Credentials = new NetworkCredential(UserID, Password);

                // Copy the contents of the file to the request stream.  
                byte[] fileContents = Convert.FromBase64String(FileBase64);
                request.ContentLength = fileContents.Length;

                Stream requestStream = request.GetRequestStream();
                requestStream.Write(fileContents, 0, fileContents.Length);
                requestStream.Close();

                FtpWebResponse response = (FtpWebResponse)request.GetResponse();

                Console.WriteLine("Upload File Complete, status {0}", response.StatusDescription);

                response.Close();
                FileName = DynamicFolderPath + FileName;
            }
            catch (Exception ex)
            {
                var s = ex.Message;
                FileName = "";
            }
            return FileName;
        }

        private static void CheckFolderExist(string FtpFolderLocation, string UserName, string Password)
        {
            FtpWebRequest requestDirectory = (FtpWebRequest)WebRequest.Create(new Uri(FtpFolderLocation));
            requestDirectory.Credentials = new NetworkCredential(UserName, Password);
            requestDirectory.Method = WebRequestMethods.Ftp.ListDirectory;
            Boolean folderExist = false;
            try
            {
                using (requestDirectory.GetResponse())
                {
                    folderExist = true;
                }
            }
            catch (WebException)
            {
                folderExist = false;
            }

            if (folderExist == false)
            {
                FtpWebRequest requestMakeDirectory = (FtpWebRequest)WebRequest.Create(FtpFolderLocation);
                requestMakeDirectory.Credentials = new NetworkCredential(UserName, Password);
                requestMakeDirectory.Method = WebRequestMethods.Ftp.MakeDirectory;

                try
                {
                    using (requestMakeDirectory.GetResponse())
                    {
                        folderExist = true;
                    }
                }
                catch (WebException)
                {
                    folderExist = false;
                }
            }
        }

        public static string DownloadFile(string FilePath, string TempFolderPath)
        {
            string FileName = "";
            try
            {
                if (FilePath == null)
                    return "";
                else if (FilePath == "")
                    return "";

                string FTPServerIP = ConfigurationManager.AppSettings["FTPUrl"];
                string UserID = ConfigurationManager.AppSettings["FTPUserName"];
                string Password = ConfigurationManager.AppSettings["FTPPassword"];
                string FtpFileLocation = FTPServerIP + "/" + FilePath;

                //FileName = Guid.NewGuid().ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() +
                //    DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString();
                //FileName += new FileInfo(FilePath).Extension;
                FileName += new FileInfo(@FilePath).Name;
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(FtpFileLocation);
                request.Method = WebRequestMethods.Ftp.DownloadFile;
                request.Credentials = new NetworkCredential(UserID, Password);

                Stream reader = request.GetResponse().GetResponseStream();
                BinaryWriter fileStream = new BinaryWriter(File.Open(TempFolderPath + "/" + FileName, FileMode.Create));

                int bytesRead = 0;
                byte[] buffer = new byte[1024];
                while (true)
                {
                    bytesRead = reader.Read(buffer, 0, buffer.Length);

                    if (bytesRead == 0)
                        break;

                    fileStream.Write(buffer, 0, bytesRead);
                }

                fileStream.Close();
                reader.Close();
            }
            catch (Exception ex) { var s = ex.Message; }
            return FileName;
        }

        public static bool DeleteFile(string FilePath, string FileName)
        {
            string FTPServerIP = ConfigurationManager.AppSettings["FTPUrl"];
            string UserID = ConfigurationManager.AppSettings["FTPUserName"];
            string Password = ConfigurationManager.AppSettings["FTPPassword"];
            string FtpFileLocation = FTPServerIP + "/" + FilePath + "/" + FileName;

            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(FtpFileLocation);
            request.Method = WebRequestMethods.Ftp.DeleteFile;
            request.Credentials = new NetworkCredential(UserID, Password);
            Stream reader = request.GetResponse().GetResponseStream();

            return true;
        }
    }
}
