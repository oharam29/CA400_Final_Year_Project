using MMSEApp.ViewModels;
using MMSEApp.Views.Patient;
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
    public partial class NewPatient : ContentPage
    {

        NewPatientViewModel newPatientViewModel;
        public NewPatient()
        {
            newPatientViewModel = new NewPatientViewModel();
            newPatientViewModel.navigation = Navigation;
            InitializeComponent();
            BindingContext = newPatientViewModel;
        }


        private async void Cancel_Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private void DatePicker_DateSelected(object sender, DateChangedEventArgs e)
        {
            newPatientViewModel.Dob = DatePicker.Date;
        }


    }
}