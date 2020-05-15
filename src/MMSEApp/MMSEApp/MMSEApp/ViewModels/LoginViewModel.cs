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

        private int userId;
        public int UserID
        {
            get { return userId; }
            set
            {
                userId = value;
                PropertyChanged(this, new PropertyChangedEventArgs("UserID"));
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
                DbResult res = DB_Validate();
                if (res.success)
                {
                    App.currentUser = new User
                    {
                        UserId = UserID,
                        UserName = Username,
                        PassWord = Password

                    };
                    UpdateCurrentDoc();
                    MainPage main = new MainPage();
                    Application.Current.MainPage = main;

                }
                else
                    App.Current.MainPage.DisplayAlert("Login Fail", res.msg, "OK");
            }
        }

        private DbResult DB_Validate()
        {
            List<User> Users = new List<User>();
            string cs = @"server=oharam29-nolanm45-mmse-app.c4zhfzwco8qq.eu-west-1.rds.amazonaws.com;Port=3306;database=patient_info;user id=oharam29;password=f1sfo9mu;Persist Security Info=True;charset=utf8;";
            MySqlConnection con = new MySqlConnection(cs);
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open(); // open db connection
                    string query = "SELECT UserID, UserName, PassWord FROM TBL_USER"; // sql query string
                    using (MySqlCommand command = new MySqlCommand(query, con))
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read()) // read in query results
                            {
                                User U = new User
                                {
                                    UserId = reader.GetInt32(0),
                                    UserName = reader.GetString(1), // get the corresponding values 
                                    PassWord = reader.GetString(2)
                                };
                                Users.Add(U); // make a list of all users 
                            }
                        }
                    }
                    DbResult result = new DbResult();
                    foreach (User user in Users) // iterate through the list of users to find desired user
                    {
                        if (user.UserName == Username)
                        {
                            if (user.PassWord == Password)
                            {
                                UserID = user.UserId;
                                result.msg = "Login Success"; // if username and password are correct log user in 
                                result.success = true;
                            }
                            else // else do not log user in 
                            {
                                result.msg = "Incorrect Password";
                                result.success = false;
                            }
                            break;
                        }
                        else
                        {
                            result.msg = "Incorrect Username";
                            result.success = false;
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

            return new DbResult { success = false, msg = "" };
        }

        private void UpdateCurrentDoc()
        {
            string cs = @"server=oharam29-nolanm45-mmse-app.c4zhfzwco8qq.eu-west-1.rds.amazonaws.com;Port=3306;database=patient_info;user id=oharam29;password=f1sfo9mu;Persist Security Info=True;charset=utf8;";
            MySqlConnection con = new MySqlConnection(cs);
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open(); // open db connection
                    
                    MySqlCommand query = new MySqlCommand("SELECT * FROM TBL_DOCTOR WHERE UserID=@user", con);
                    query.Parameters.AddWithValue("@user", App.currentUser.UserId ); // add parameters
                    
                    using (MySqlDataReader reader = query.ExecuteReader())
                    {
                        while (reader.Read()) // read in query results
                        {
                            App.currentDoctor = new Doctor
                            {
                                DoctorId = reader.GetInt32(0),
                                LastName = reader.GetString(1),
                                FirstName = reader.GetString(2),
                                UserId = reader.GetInt32(3)
                            };
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

        }
    }
}

