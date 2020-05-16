using MMSEApp.Models;
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
    public partial class ExamHomePage : ContentPage
    {
        public PatientItem PatientSelected;
        public ExamHomePage()
        {
            InitializeComponent();
            InitSearch();
        }

        private void StartExamButtonClicked(object sender, EventArgs e)
        {
            if(PatientSelected!= null)
            {
                 Navigation.PushAsync(new ExamPage(PatientSelected));
            }
            else
            {
                App.Current.MainPage.DisplayAlert("You must select a patient", "", "OK");
            }
            
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

        void InitSearch()
        {
            PatientSearch.TextChanged += (s, e) => FilterItem(PatientSearch.Text);
        }

        private void FilterItem(string filter)
        {
            List<PatientItem> patientItems = GetPatients();
            PatientsList.BeginRefresh();
            if (string.IsNullOrEmpty(filter))
            {
                PatientsList.ItemsSource = patientItems;
            }
            else
            {
                PatientsList.ItemsSource = patientItems.Where(p => p.FirstName.ToLower().Contains(filter.ToLower()) || p.LastName.ToLower().Contains(filter.ToLower()));
            }
            PatientsList.EndRefresh();
        }

        private void PatientsList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            
            SelectedPatientGrid.Children.Clear();
            PatientSelected = e.SelectedItem as PatientItem;

            PatientsList.ItemsSource = null;
            SelectedLabel.Text = "Selected Patient: ";
            var selectedPatient = e.SelectedItem as PatientItem;

            Label firstName = new Label { Text = "First Name: ", FontAttributes =  FontAttributes.Bold };
            Label PatientFirstName = new Label { Text = selectedPatient.FirstName };

            SelectedPatientGrid.Children.Add(firstName, 0, 0);
            SelectedPatientGrid.Children.Add(PatientFirstName, 1, 0);

            Label lastName = new Label { Text = "Last Name: ", FontAttributes = FontAttributes.Bold };
            Label PatientLastName = new Label { Text = selectedPatient.LastName };

            SelectedPatientGrid.Children.Add(lastName, 0, 1);
            SelectedPatientGrid.Children.Add(PatientLastName, 1, 1);

            Label Dob = new Label { Text = "Date of Birth: ", FontAttributes = FontAttributes.Bold };
            Label PatientDob = new Label { Text = selectedPatient.PatientDOB.Date.ToString() };

            SelectedPatientGrid.Children.Add(Dob, 0, 2);
            SelectedPatientGrid.Children.Add(PatientDob, 1, 2);

            Label lastExam = new Label { Text = "Last Exam Date: ", FontAttributes = FontAttributes.Bold };
            Label PatientLastExam = new Label { Text = selectedPatient.LastTestDate.Date.ToString() };

            SelectedPatientGrid.Children.Add(lastExam, 0, 3);
            SelectedPatientGrid.Children.Add(PatientLastExam, 1, 3);
        }
    }
}