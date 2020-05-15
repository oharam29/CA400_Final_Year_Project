using MMSEApp.Models;
using MMSEApp.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MMSEApp
{
    public partial class App : Application
    {
        public static User currentUser; // global variables
        public static Doctor currentDoctor;
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new LoginPage());
            
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
