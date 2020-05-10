
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
using VideoMotionApp.Utility;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VideoMotionApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InitializePage : ContentPage
    {
        public InitializePage()
        {
            InitializeComponent();

            List<Model.Module> modules = new List<Model.Module>()
            {
                new Model.Module(){ Name="Module 1", Description= "Module 1 description", FileName="file 1" },
                new Model.Module(){ Name="Module 2", Description= "Module 2 description", FileName="file 2" },
                new Model.Module(){ Name="Module 3", Description= "Module 3 description", FileName="file 3" },
                new Model.Module(){ Name="Module 4", Description= "Module 4 description", FileName="file 4" },
                new Model.Module(){ Name="Module 5", Description= "Module 5 description", FileName="file 5" },
                new Model.Module(){ Name="Module 6", Description= "Module 6 description", FileName="file 6" },
                new Model.Module(){ Name="Module 7", Description= "Module 7 description", FileName="file 7" },
                new Model.Module(){ Name="Module 8", Description= "Module 8 description", FileName="file 8" },
                new Model.Module(){ Name="Module 9", Description= "Module 9 description", FileName="file 9" },
                new Model.Module(){ Name="Module 10", Description= "Module 10 description", FileName="file 10" },
            };

            lvModules.ItemsSource = modules;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            //string url = "https://something.com/something.mov";
            //var mediaItem = await CrossMediaManager.Current.Extractor.CreateMediaItem(url);

            //if (!string.IsNullOrWhiteSpace(filePath))
            //{
            //    videoPlayer.IsVisible = true;
            //    FileInfo fileInfo = new FileInfo(filePath);
            //    var mediaItem = await CrossMediaManager.Current.Extractor.CreateMediaItem(fileInfo);
            //    var image = await CrossMediaManager.Current.Extractor.GetVideoFrame(mediaItem, TimeSpan.FromSeconds(1));
            //    videoPlayer.Source = image;
            //}
            //else
            //{
            //    videoPlayer.IsVisible = false;
            //}
        }

        private void lvModules_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (sender is ListView lv)
            {
                lv.SelectedItem = null;
            }

            Navigation.PushAsync(new Views.ModulePage(e.Item as Model.Module));
        }
    }
}