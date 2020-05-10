using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VideoMotionApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignUpPage : ContentPage
    {
        public SignUpPage()
        {
            InitializeComponent();
        }

        private void btnSignUp_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtToken.Text))
                {
                    Utility.FileManager.SaveLog(txtToken.Text);
                    App.Current.MainPage = new NavigationPage(new Views.InitializePage());
                }
            }
            catch (Exception ex)
            {
                var exp = ex.Message;
            }
        }
    }
}