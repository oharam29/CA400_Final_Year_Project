﻿using MMSEApp.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MMSEApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //MainPage = new NavigationPage(new LoginPage());
            MainPage = new Content();
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
