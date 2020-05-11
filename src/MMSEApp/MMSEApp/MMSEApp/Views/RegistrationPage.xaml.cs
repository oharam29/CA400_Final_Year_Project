﻿using MMSEApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MMSEApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegistrationPage : ContentPage
    {
        RegisterViewModel registerViewModel;
        public RegistrationPage()
        {
            registerViewModel = new RegisterViewModel();
            InitializeComponent();
            BindingContext = registerViewModel;
        }
    }
}