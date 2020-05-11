using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MMSEApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            Logo.Source = ImageSource.FromResource("MMSEApp.Images.logo.jpg");
        }

        public void Login_Button_Clicked(object sender, EventArgs e)
        {
           
            MainPage main = new MainPage();
            Application.Current.MainPage = main;
        }

        async void Register_Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegistrationPage());
        }

        async void Forgot_Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ForgotPasswordPage());
        }
    }
}