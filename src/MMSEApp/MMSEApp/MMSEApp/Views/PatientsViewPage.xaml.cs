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
            PatientsList.ItemsSource = new List<Patient> {
                new Patient {PatientID = 0, FirstName = "Matt",LastName = "Nolan" },
                new Patient {PatientID = 1, FirstName = "Mike",LastName = "O'Hara" },
                new Patient {PatientID = 2, FirstName = "Eoin",LastName = "Clayton" }
            };
             
        }
    }
}