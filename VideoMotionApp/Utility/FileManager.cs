using PCLStorage;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace VideoMotionApp.Utility
{
    public class FileManager
    {
        public FileManager()
        {

        }

        public async static void SaveLog(string contentLog)
        {
            try
            {
                string existString = string.Empty;
                IFolder rootFolder = FileSystem.Current.LocalStorage;
                IFolder folder;

                folder = rootFolder.CreateFolderAsync("Log", CreationCollisionOption.OpenIfExists).Result;

                IFile file;
                ExistenceCheckResult fileExists;

                fileExists = folder.CheckExistsAsync("Token.txt").Result;

                if (fileExists == ExistenceCheckResult.FileExists)
                {
                    file = folder.GetFileAsync("Token.txt").Result;
                    //existString = file.ReadAllTextAsync().Result;
                }
                else
                {
                    file = folder.CreateFileAsync("Token.txt", CreationCollisionOption.ReplaceExisting).Result;
                }

                file.WriteAllTextAsync(contentLog);
            }
            catch (System.Exception ex)
            {
                var exp = ex.Message;
            }
        }

        public async static Task<bool> ExistTokenFile()
        {
            bool result = false;
            try
            {
                IFolder rootFolder = FileSystem.Current.LocalStorage;
                IFolder folder;

                folder = rootFolder.CreateFolderAsync("Log", CreationCollisionOption.OpenIfExists).Result;

                IFile file;
                ExistenceCheckResult fileExists;

                fileExists = folder.CheckExistsAsync("Token.txt").Result;
                if (fileExists != ExistenceCheckResult.FileExists)
                {
                    file = folder.CreateFileAsync("Token.txt", CreationCollisionOption.ReplaceExisting).Result;
                    result = false;
                }
                else
                {
                    file = folder.GetFileAsync("Token.txt").Result;
                    result = file.ReadAllTextAsync().Result != null;
                }
            }
            catch (System.Exception ex)
            {
                var exp = ex.Message;
            }
            return result;
        }
    }
}
