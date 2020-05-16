using MMSEApp.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Security.Cryptography;
using System.Text;
using Xamarin.Forms;

namespace MMSEApp.ViewModels
{
    public class RegisterViewModel : INotifyPropertyChanged
    {
        public INavigation navigation;
        public event PropertyChangedEventHandler PropertyChanged;     
        public RegisterViewModel() { }

        private string firstName;
        public string FirstName
        {
            get { return firstName; }
            set
            {
                firstName = value;
                PropertyChanged(this, new PropertyChangedEventArgs("FirstName"));
            }
        }


        private string lastName;
        public string LastName
        {
            get { return lastName; }
            set
            {
                lastName = value;
                PropertyChanged(this, new PropertyChangedEventArgs("LastName"));
            }
        }

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
                    DbResult reg = RegisterUser();
                    App.Current.MainPage.DisplayAlert(reg.msg, "", "OK");
                    if (reg.success)
                    {
                        navigation.PopAsync();
                    }

                }
            }
        }

        private DbResult RegisterUser()
        {
            DbResult res = new DbResult();
            string cs = @"server=oharam29-nolanm45-mmse-app.c4zhfzwco8qq.eu-west-1.rds.amazonaws.com;Port=3306;database=patient_info;user id=oharam29;password=f1sfo9mu;Persist Security Info=True;charset=utf8;";
            MySqlConnection con = new MySqlConnection(cs);
            try
            {

                if (con.State == ConnectionState.Closed)
                {
                    //// add to user table
                    con.Open(); // open connection 

                    MySqlCommand init_check = new MySqlCommand("SELECT UserName FROM TBL_USER WHERE UserName=@user;", con); // sql query string
                    init_check.Parameters.AddWithValue("@user", Username); // add parameters
                    MySqlDataReader init_reader = init_check.ExecuteReader();
                    if (!init_reader.HasRows)
                    {
                        init_reader.Close();
                        MySqlCommand cmd = new MySqlCommand("INSERT INTO TBL_USER(UserName, PassWord) VALUES(@user, @pass)", con); // sql query string
                        cmd.Parameters.AddWithValue("@user", Username); // add parameters
                        cmd.Parameters.AddWithValue("@pass", Password);
                        cmd.ExecuteNonQuery(); // execute the query

                        res.msg = "User added successfully";
                        res.success = true;

                        MySqlCommand cmd2 = new MySqlCommand("SELECT UserID FROM TBL_USER WHERE UserName=@user;", con); // sql query string
                        cmd2.Parameters.AddWithValue("@user", Username); // add parameters

                        User u = new User();
                        using (MySqlDataReader reader = cmd2.ExecuteReader())
                        {
                            while (reader.Read()) // read in query results
                            {
                                u.UserId = reader.GetInt32(0);
                            };
                        }

                        // add to doctor table
                        MySqlCommand cmd3 = new MySqlCommand("INSERT INTO TBL_DOCTOR(LastName, FirstName,UserID) VALUES(@user, @pass,@userid)", con); // sql query string
                        cmd3.Parameters.AddWithValue("@user", Username); // add parameters
                        cmd3.Parameters.AddWithValue("@pass", Password);
                        cmd3.Parameters.AddWithValue("@userid", u.UserId);
                        cmd3.ExecuteNonQuery(); // execute the query
                    }
                    else
                    {
                        App.Current.MainPage.DisplayAlert("User already exists", "Please choose another username", "Ok");
                    }
                }
                
            }
            catch (MySqlException ex)
            {
                res.msg = "Error occured, please try again";
                res.success = false;

                throw (ex);

            }
            finally
            {
                con.Close(); // close connection 
            }
            return res;
        }
    }
}
