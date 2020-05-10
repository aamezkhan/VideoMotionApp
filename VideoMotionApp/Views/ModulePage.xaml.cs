using Plugin.Media;
using Plugin.Media.Abstractions;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoMotionApp.DependencyService;
using VideoMotionApp.Utility;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VideoMotionApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ModulePage : ContentPage
    {
        private byte[] videoBytes;
        private string fileExtension;
        private string filePath;

        private Model.Module module;
        public ModulePage(Model.Module module)
        {
            InitializeComponent();
            this.module = module;
            this.Title = this.module.Name;
        }

        private async void btnCapture_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (await Common.isInternetConnectedPrompt(this))
                {
                    await CrossMedia.Current.Initialize();

                    if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported
                        || !CrossMedia.Current.IsTakeVideoSupported)
                    {
                        await DisplayAlert("Notification", "No camera available", "OK");
                        return;
                    }

                    var cameraStatus = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Camera);
                    var storageStatus = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Storage);

                    if (cameraStatus != PermissionStatus.Granted || storageStatus != PermissionStatus.Granted)
                    {
                        var results = await CrossPermissions.Current.RequestPermissionsAsync(new[] { Permission.Camera, Permission.Storage });
                        cameraStatus = results[Permission.Camera];
                        storageStatus = results[Permission.Storage];
                    }

                    if (cameraStatus == PermissionStatus.Granted && storageStatus == PermissionStatus.Granted)
                    {
                        var file = await CrossMedia.Current.TakeVideoAsync(new StoreVideoOptions
                        {
                            Quality = VideoQuality.Low,
                            DefaultCamera = CameraDevice.Rear,
                            //DesiredLength = TimeSpan.FromMinutes(3),
                            //ModalPresentationStyle = MediaPickerModalPresentationStyle.FullScreen,
                        });

                        if (file != null)
                        {
                            var videoBytes = Common.StreamToByte(file.GetStream());
                            this.videoBytes = videoBytes;
                            lblPathName.Text = filePath = file.Path;
                            string fileExt = Path.GetExtension(file.Path);
                            fileExtension = fileExt;

                            btnCapture.IsEnabled = false;
                            btnUpload.IsEnabled = true;
                            //if (!string.IsNullOrWhiteSpace(filePath))
                            //{
                            //    FileInfo fileInfo = new FileInfo(filePath);
                            //    var mediaItem = await CrossMediaManager.Current.Extractor.CreateMediaItem(fileInfo);
                            //    var image = await CrossMediaManager.Current.Extractor.GetVideoFrame(mediaItem, TimeSpan.FromSeconds(1));
                            //    videoPlayer.Source = image;
                            //    // CrossMediaManager.Current.Play(videoUrl, MediaFileType.Video);
                            //}
                            //else
                            //{
                            //    videoPlayer.IsVisible = false;
                            //}
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                var exp = ex.Message;
            }
        }

        private void btnUpload_Clicked(object sender, EventArgs e)
        {
            try
            {
                string ftpUrl = "ftp://ftp.swfwmd.state.fl.us";
                string fileName = Path.GetFileName(filePath);
                string userName = "Anonymous";
                string password = "gabriel@icloud.com";
                string uploadDirectory = "/pub/incoming";

                Xamarin.Forms.DependencyService.Get<IFtpWebRequest>().uploadFile(ftpUrl, fileName, filePath, userName, password, uploadDirectory);

                btnUpload.IsEnabled = false;
                btnCapture.IsEnabled = true;

                File.Delete(filePath);
            }
            catch (Exception ex)
            {
                var exp = ex.Message;
            }
        }
    }
}