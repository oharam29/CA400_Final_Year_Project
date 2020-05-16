using MMSEApp.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Security.Cryptography;
using System.Text;
using Xamarin.Forms;

namespace MMSEApp
{
    //TEST CASES FOR INTERACTING WITH DATABASE
    class Testing
    {
        public void Test_Connection()
        {
            string cs = @"server=oharam29-nolanm45-mmse-app.c4zhfzwco8qq.eu-west-1.rds.amazonaws.com;Port=3306;database=patient_info;user id=oharam29;password=f1sfo9mu;Persist Security Info=True;charset=utf8;";
            MySqlConnection con = new MySqlConnection(cs);
            try
            {
                con.Open();
            }
            catch(MySqlException ex)
            {
                Console.WriteLine("TEST FAILED - Unable to connect");
                throw (ex);
            }
            Console.WriteLine("TEST PASS - Successfully connected to the DB");
        }


        public void Test_Query()
        {
            string cs = @"server=oharam29-nolanm45-mmse-app.c4zhfzwco8qq.eu-west-1.rds.amazonaws.com;Port=3306;database=patient_info;user id=oharam29;password=f1sfo9mu;Persist Security Info=True;charset=utf8;";
            MySqlConnection con = new MySqlConnection(cs);
            con.Open();
            MySqlCommand cmd2 = new MySqlCommand("SELECT stringTest FROM TBL_UNITTEST", con); // sql query string

            using (MySqlDataReader reader = cmd2.ExecuteReader())
            {
                reader.Read(); // read in query results
                String test_string = reader.GetString(0);
                if(test_string != "test")
                {
                    Console.WriteLine("TEST FAILED - Value does not match query");
                }
                else if(test_string == "")
                {
                    Console.WriteLine("TEST FAILED - Value does not match query");
                }
            }
            Console.WriteLine("TEST PASSED - Value in database matches test value");
        }

        public void Test_Insert()
        {
            string cs = @"server=oharam29-nolanm45-mmse-app.c4zhfzwco8qq.eu-west-1.rds.amazonaws.com;Port=3306;database=patient_info;user id=oharam29;password=f1sfo9mu;Persist Security Info=True;charset=utf8;";
            MySqlConnection con = new MySqlConnection(cs);
            con.Open();
            MySqlCommand cmd1 = new MySqlCommand("INSERT INTO TBL_UNITTEST(insertTest) VALUES(insert)", con);


            MySqlCommand cmd2 = new MySqlCommand("SELECT insertTest FROM TBL_UNITTEST", con);

            using (MySqlDataReader reader = cmd2.ExecuteReader())
            {
                reader.Read(); // read in query results
                String test_string = reader.GetString(0);
                if (test_string != "insert")
                {
                    Console.WriteLine("TEST FAILED - Value not inserted");
                }
                else if (test_string == "")
                {
                    Console.WriteLine("TEST FAILED - Value not inserted");
                }
            }
            Console.WriteLine("TEST PASSED - Value inserted successfully");

        }
        public void Test_Delete()
        {
            string cs = @"server=oharam29-nolanm45-mmse-app.c4zhfzwco8qq.eu-west-1.rds.amazonaws.com;Port=3306;database=patient_info;user id=oharam29;password=f1sfo9mu;Persist Security Info=True;charset=utf8;";
            MySqlConnection con = new MySqlConnection(cs);
            con.Open();
            MySqlCommand cmd1 = new MySqlCommand("DELETE FROM TBL_UNITTEST(insertTest) VALUES(insert)", con);


            MySqlCommand cmd2 = new MySqlCommand("SELECT insertTest FROM TBL_UNITTEST", con);

            using (MySqlDataReader reader = cmd2.ExecuteReader())
            {
                reader.Read(); // read in query results
                String test_string = reader.GetString(0);
                if (test_string != "")
                {
                    Console.WriteLine("TEST FAILED - Value not inserted");
                }
            }
            Console.WriteLine("TEST PASSED - Value inserted successfully");

        }


        public void Run()
        {
            Test_Connection();
        }

    }
}
