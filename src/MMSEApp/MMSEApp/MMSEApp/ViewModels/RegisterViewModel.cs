using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text;
using Xamarin.Forms;

namespace MMSEApp.ViewModels
{
    public class RegisterViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;     
        public RegisterViewModel() { }

        private string username;
        public string Username
        {
            get { return username; }
            set
            {
                username = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Username"));
            }
        }

        private string password;
        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Password"));
            }
        }

        private string confirmPassword;
        public string ConfirmPassword
        {
            get { return confirmPassword; }
            set
            {
                confirmPassword = value;
                PropertyChanged(this, new PropertyChangedEventArgs("ConfirmPassword"));
            }
        }

        public Command RegisterCommand
        {
            get
            {
                return new Command(Register);
            }
        }

        private void Register() {
            if (string.IsNullOrEmpty(Username) || string.IsNullOrEmpty(Password) || string.IsNullOrEmpty(ConfirmPassword))
            {
                App.Current.MainPage.DisplayAlert("Empty Values", "Please enter Username and Password", "OK");
            }
            else
            {
                if (Password != ConfirmPassword)
                {
                    App.Current.MainPage.DisplayAlert("Passwords do not match", "Please retry", "OK");
                }
                else
                {
                    RegisterUser();
                }
            }
        }

        private void RegisterUser()
        {
            string cs = @"server=oharam29-nolanm45-mmse-app.c4zhfzwco8qq.eu-west-1.rds.amazonaws.com;Port=3306;database=patient_info;user id=oharam29;password=f1sfo9mu;Persist Security Info=True;charset=utf8;";
            MySqlConnection con = new MySqlConnection(cs);
            try
            {

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                    MySqlCommand cmd = new MySqlCommand("INSERT INTO TBL_USER(UserName, PassWord) VALUES(@user, @pass)", con);
                    cmd.Parameters.AddWithValue("@user", Username);
                    cmd.Parameters.AddWithValue("@pass", Password);
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
            }
        }
    }
}
