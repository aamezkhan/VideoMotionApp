using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VideoMotionApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            // CrossMediaManager.Current.Init();

            //MainPage = new NavigationPage(new Views.SignUpPage());
            if (Utility.FileManager.ExistTokenFile().Result)
            {
                MainPage = new NavigationPage(new Views.InitializePage());
            }
            else
            {
                MainPage = new NavigationPage(new Views.SignUpPage());
            }
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
