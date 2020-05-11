using System;
using System.Collections.Generic;
using System.Data;
using MMSEApp.Models;
using MySql.Data.MySqlClient;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MMSEApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Content : ContentPage
    {

        public Content()
        {
            InitializeComponent();
        }

        private void Add_to_DB(object sender, EventArgs e)
        {
            string username = UserNameVar.Text;
            string password = PasswordVar.Text;

            string cs = @"server=oharam29-nolanm45-mmse-app.c4zhfzwco8qq.eu-west-1.rds.amazonaws.com;Port=3306;database=patient_info;user id=oharam29;password=f1sfo9mu;Persist Security Info=True;charset=utf8;";
            MySqlConnection con = new MySqlConnection(cs);
            try
            {

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                    MySqlCommand cmd = new MySqlCommand("INSERT INTO TBL_USER(UserName, PassWord) VALUES(@user, @pass)", con);
                    cmd.Parameters.AddWithValue("@user", username);
                    cmd.Parameters.AddWithValue("@pass", password);
                    cmd.ExecuteNonQuery();
                };
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

        private void DB_Validate(object sender, EventArgs e)
        {
            string username = UserNameVar.Text;
            string password = PasswordVar.Text;
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
                                User U = new User();
                                U.UserName = reader.GetString(0);
                                U.PassWord = reader.GetString(1);
                                Users.Add(U);
                            }
                        }
                    }
                    if (username != "" || password != "")
                    {
                        foreach (User user in Users)
                        {
                            if (user.UserName == username)
                            {
                                if (user.PassWord == password)
                                {
                                    Console.WriteLine("logged in");
                                }
                                else
                                {
                                    //password incorrect
                                }
                            }
                            else
                            {
                                //username incorrect 
                            }
                        }
                    }
                    else
                    {
                        //username or password blan
                    }
                };
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