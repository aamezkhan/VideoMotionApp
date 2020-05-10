using System;
using System.Collections.Generic;
using System.Text;

namespace VideoMotionApp.DependencyService
{
    public interface IFtpWebRequest
    {
        string uploadFile(string FtpUrl, string fileName, string filePath, string userName, string password, string UploadDirectory = "");
    }
}
