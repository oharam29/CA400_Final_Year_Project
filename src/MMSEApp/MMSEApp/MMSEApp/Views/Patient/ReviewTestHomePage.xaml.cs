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

namespace MMSEApp.Views.Patient
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ReviewTestHomePage : ContentPage
    {
        private PatientItem currentPatient;
        private List<TestResults> testResults;
        public ReviewTestHomePage(PatientItem patientItem )
        {
            currentPatient = patientItem;
            
            InitializeComponent();
            title.Text = "Exam Review: " + currentPatient.FirstName + " " + currentPatient.LastName;
            testResults = getResults();
            ReviewTestList.ItemsSource = testResults;
        }

        private List<TestResults> getResults()
        {
            List<TestResults> testResults = new List<TestResults>();
            string cs = @"server=oharam29-nolanm45-mmse-app.c4zhfzwco8qq.eu-west-1.rds.amazonaws.com;Port=3306;database=patient_info;user id=oharam29;password=f1sfo9mu;Persist Security Info=True;charset=utf8;";
            MySqlConnection con = new MySqlConnection(cs);
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                    string query = "SELECT * FROM TBL_RESULTS WHERE PatientID = @Pid";
                    using (MySqlCommand command = new MySqlCommand(query, con))
                    {
                        command.Parameters.AddWithValue("@Pid", currentPatient.PatientID);
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                testResults.Add(
                                    new TestResults
                                    {
                                        DoctorID = reader.GetInt32(0),
                                        PatientID = reader.GetInt32(1),
                                        ResultID = reader.GetInt32(2),
                                        OrientationAns1 = reader.GetString(3),
                                        OrientationAns2 = reader.GetString(4),
                                        OrientationAns3 = reader.GetString(5),
                                        OrientationAns4 = reader.GetString(6),
                                        OrientationAns5 = reader.GetString(7),
                                        OrientationAns6 = reader.GetString(8),
                                        OrientationAns7 = reader.GetString(9),
                                        OrientationAns8 = reader.GetString(10),
                                        OrientationAns9 = reader.GetString(11),
                                        OrientationAns10 = reader.GetString(12),
                                        RegistrationAns1 = reader.GetString(13),
                                        RegistrationAns2 = reader.GetString(14),
                                        RegistrationAns3 = reader.GetString(15),
                                        AttenCalcAns1 = reader.GetString(16),
                                        RecallAns1 = reader.GetString(17),
                                        RecallAns2 = reader.GetString(18),
                                        RecallAns3 = reader.GetString(19),
                                        LanguageAns1 = reader.GetString(20),
                                        LanguageAns2 = reader.GetString(21),
                                        LanguageAns3 = reader.GetString(22),
                                        LanguageAns4 = reader.GetString(23),
                                        LanguageAns5 = reader.GetString(24),
                                        DrawingAns1 = reader.GetString(25),
                                        DateTaken = reader.GetDateTime(26), 
                                        ExamScore = reader.GetInt32(27)
                                    }) ; 
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

            return testResults;
        }

        async void ReviewTestList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            await Navigation.PushAsync(new ReviewTestPage(e.SelectedItem as TestResults));
        }

        async void Back_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}