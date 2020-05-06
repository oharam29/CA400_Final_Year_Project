using MMSEApp.Models;
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
    public partial class PatientsViewPage : ContentPage
    {
        public PatientsViewPage()
        {
            InitializeComponent();
            PatientsList.ItemsSource = new List<PatientItem> {
                new PatientItem {PatientID = 0, FirstName = "Matt",LastName = "Nolan" },
                new PatientItem {PatientID = 1, FirstName = "Mike",LastName = "O'Hara" },
                new PatientItem {PatientID = 2, FirstName = "Eoin",LastName = "Clayton" }
            };
             
        }

        async void Add_New_Patient_Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NewPatient());
        }
    }
}