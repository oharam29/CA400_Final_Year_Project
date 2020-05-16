using MMSEApp.Views;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text;
using Xamarin.Forms;

namespace MMSEApp.ViewModels
{
    public class NewPatientViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public INavigation navigation;
        public NewPatientViewModel() { }


        private string firstname;
        public string Firstname
        {
            get { return firstname; }
            set
            {
                firstname = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Fistname"));
            }
        }

        private string lastname;
        public string Lastname
        {
            get { return lastname; }
            set
            {
                lastname = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Lastname"));
            }
        }

        private DateTime dob;
        public DateTime Dob
        {
            get { return dob; }
            set
            {
                dob = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Dob"));
            }
        }

        public Command AddPatient
        {
            get
            {
                return new Command(AddNewPatient);
            }
        }

        private void AddNewPatient() {
            string cs = @"server=oharam29-nolanm45-mmse-app.c4zhfzwco8qq.eu-west-1.rds.amazonaws.com;Port=3306;database=patient_info;user id=oharam29;password=f1sfo9mu;Persist Security Info=True;charset=utf8;";
            MySqlConnection con = new MySqlConnection(cs);
            try
            {

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                    MySqlCommand cmd = new MySqlCommand("INSERT INTO TBL_PATIENT(FirstName, LastName, DateOfBirth,DoctorID) VALUES(@firstname, @lastname, @dateofbirth, @doc)", con);
                    cmd.Parameters.AddWithValue("@firstname", Firstname);
                    cmd.Parameters.AddWithValue("@lastname", Lastname);
                    cmd.Parameters.AddWithValue("@dateofbirth", Dob);
                    cmd.Parameters.AddWithValue("@doc",App.currentDoctor.DoctorId);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (MySqlException ex)
            {
                throw (ex);
            }
            finally
            {
                con.Close();
                string patientName ="Patient: " + Firstname + " " + Lastname + " added" ;
                App.Current.MainPage.DisplayAlert(patientName, "", "OK");

                var patientPage = new PatientsViewPage();
                
                navigation.InsertPageBefore(patientPage, navigation.NavigationStack[navigation.NavigationStack.Count-1] ) ;
                navigation.RemovePage(navigation.NavigationStack[navigation.NavigationStack.Count - 1]);
                navigation.PopAsync();
            }
        }
    }
}
