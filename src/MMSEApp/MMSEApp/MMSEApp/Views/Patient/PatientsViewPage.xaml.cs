using MMSEApp.Models;
using MMSEApp.Views.Patient;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
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
        private List<PatientItem> patientItems;
        public PatientsViewPage()
        {
            InitializeComponent();
            patientItems = GetPatients();
            PatientsList.ItemsSource = patientItems;
            InitSearch();
        }

        async void Add_New_Patient_Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NewPatient());
        }

        private List<PatientItem> GetPatients()
        {
            List<PatientItem> patients = new List<PatientItem>(); 
            string cs = @"server=oharam29-nolanm45-mmse-app.c4zhfzwco8qq.eu-west-1.rds.amazonaws.com;Port=3306;database=patient_info;user id=oharam29;password=f1sfo9mu;Persist Security Info=True;charset=utf8;";
            MySqlConnection con = new MySqlConnection(cs);
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                    string query = "SELECT * FROM TBL_PATIENT WHERE DoctorID = @doc";
                    using (MySqlCommand command = new MySqlCommand(query, con))
                    {
                        command.Parameters.AddWithValue("@doc", App.currentDoctor.DoctorId);
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                patients.Add(
                                    new PatientItem
                                    {

                                        PatientID = reader.GetInt32(0),
                                        LastName = reader.GetString(1),
                                        FirstName = reader.GetString(2),
                                        LastTestDate = reader.GetDateTime(3),
                                        PatientDOB = reader.GetDateTime(4).Date
                                    });
                            }
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                throw (ex);
            }
            finally
            {
                con.Close(); // close connection
            }
            return patients;
        }

        async void PatientsList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            await Navigation.PushAsync(new PatientDashboardPage(e.SelectedItem as PatientItem));
        }

        void InitSearch() {
            PatientSearch.TextChanged += (s, e) => FilterItem(PatientSearch.Text);
        }

        private void FilterItem(string filter)
        {
            PatientsList.BeginRefresh();
            if (string.IsNullOrEmpty(filter)) {
                PatientsList.ItemsSource = patientItems;
            }
            else
            {
                PatientsList.ItemsSource = patientItems.Where(p=> p.FirstName.ToLower().Contains(filter.ToLower()) || p.LastName.ToLower().Contains(filter.ToLower())  );
            }
            PatientsList.EndRefresh();
        }
    }
}
    