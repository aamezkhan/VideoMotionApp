using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using VideoMotionApp.DependencyService;
using VideoMotionApp.Droid.DependencyService;

[assembly: Xamarin.Forms.Dependency(typeof(FTP))]
namespace VideoMotionApp.Droid.DependencyService
{
    public class FTP : IFtpWebRequest
    {
        public FTP()
        {

        }

        public string uploadFile(string FtpUrl, string fileName,string filePath, string userName, string password, string UploadDirectory = "")
        {
            try
            {
                string pureFileName = new FileInfo(fileName).Name;
                string uploadUrl = String.Format("{0}{1}/{2}", FtpUrl, UploadDirectory, pureFileName);
                FtpWebRequest req = (FtpWebRequest)FtpWebRequest.Create(uploadUrl);
                req.Proxy = null;
                req.Method = WebRequestMethods.Ftp.UploadFile;
                req.Credentials = new NetworkCredential(userName, password);
                req.UseBinary = true;
                req.UsePassive = true;
                byte[] data = File.ReadAllBytes(filePath);
                req.ContentLength = data.Length;
                Stream stream = req.GetRequestStream();
                stream.Write(data, 0, data.Length);
                stream.Close();
                FtpWebResponse res = (FtpWebResponse)req.GetResponse();
                return res.StatusDescription;
            }
            catch (Exception err)
            {
                return err.ToString();
            }
        }
    }
}