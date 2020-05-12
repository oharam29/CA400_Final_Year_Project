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
    public partial class PatientsViewPage : ContentPage
    {
        public PatientsViewPage()
        {
            InitializeComponent();
            PatientsList.ItemsSource = GetPatients();
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
                    string query = "SELECT * FROM TBL_PATIENT";
                    using (MySqlCommand command = new MySqlCommand(query, con))
                    {
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
                                        PatientDOB = reader.GetDateTime(4)
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

    }
}
    