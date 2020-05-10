using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace VideoMotionApp.Utility
{
    public class Common
    {
        public static byte[] StreamToByte(Stream input)
        {
            byte[] buffer = new byte[16 * 1024];
            using (MemoryStream ms = new MemoryStream())
            {
                int read;
                while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, read);
                }
                return ms.ToArray();
            }
        }

        public static bool isInternetConnected(Page page = null)
        {
            if (CrossConnectivity.Current.IsConnected)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async static Task<bool> isInternetConnectedPrompt(Page page)
        {
            bool isTryAgain = true;
            do
            {
                if (CrossConnectivity.Current.IsConnected)
                {
                    return true;
                }
                else
                {
                    isTryAgain = await page.DisplayAlert("Internet Connection", "Unable to connect with the server. Check your internet connection and try again.", "Try Again", "Cancel");
                    if (!isTryAgain)
                    {
                        return false;
                    }
                }
            }
            while (isTryAgain);

            return true;
        }

    }
}
