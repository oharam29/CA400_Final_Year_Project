using MMSEApp.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text;
using Xamarin.Forms;

namespace MMSEApp.ViewModels
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public LoginViewModel() { }

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
        public Command LoginCommand
        {
            get
            {
                return new Command(Login);
            }
        }

        private void Login()
        {
            //null or empty field validation, check weather email and password is null or empty  
            if (string.IsNullOrEmpty(Username) || string.IsNullOrEmpty(Password))
            {
                App.Current.MainPage.DisplayAlert("Empty Values", "Please enter Username and Password", "OK");
            }
            else
            {
                LoginResult res = DB_Validate();
                if (res.LoginSuccess)
                {
                    MainPage main = new MainPage();
                    Application.Current.MainPage = main;
                }
                else
                    App.Current.MainPage.DisplayAlert("Login Fail", res.msg, "OK");
            }
        }

        private LoginResult DB_Validate()
        { 
            List<User> Users = new List<User>();

            string cs = @"server=oharam29-nolanm45-mmse-app.c4zhfzwco8qq.eu-west-1.rds.amazonaws.com;Port=3306;database=patient_info;user id=oharam29;password=f1sfo9mu;Persist Security Info=True;charset=utf8;";
            MySqlConnection con = new MySqlConnection(cs);
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                    string query = "SELECT UserName, PassWord FROM TBL_USER";
                    using (MySqlCommand command = new MySqlCommand(query, con))
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                User U = new User
                                {
                                    UserName = reader.GetString(0),
                                    PassWord = reader.GetString(1)
                                };
                                Users.Add(U);
                            }
                        }
                    }

                    LoginResult result = new LoginResult();

                    foreach (User user in Users)
                    {
                        if (user.UserName == Username)
                        {
                            if (user.PassWord == Password)
                            {
                                result.msg = "Login Success";
                                result.LoginSuccess = true;
                            }
                            else
                            {
                                result.msg = "Incorrect Password";
                                result.LoginSuccess = false;
                            }
                            break;
                        }
                        else
                        {
                            result.msg = "Incorrect Username";
                            result.LoginSuccess = false; 
                        }
                    }

                    return result;
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

            return new LoginResult { LoginSuccess = false, msg = "" }; 
        }

    }

}

