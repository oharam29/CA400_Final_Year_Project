using Microcharts;
using MMSEApp.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MMSEApp.Views.Patient
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PatientDashboardPage : ContentPage
    {
        private PatientItem currentPatient;
        private List<Microcharts.Entry> entries = new List<Microcharts.Entry>
        {
            new Microcharts.Entry(200)
            {
                Label = "Test 1",
                ValueLabel = "200",
                Color = SkiaSharp.SKColor.Parse("#127ac7")
                
            },
            new Microcharts.Entry(400)
            {
                Label = "Test 2",
                ValueLabel = "400",
                Color = SkiaSharp.SKColor.Parse("#127ac7")
            },
            new Microcharts.Entry(250)
            {                
                Label = "Test 3",
                ValueLabel = "250",
                Color = SkiaSharp.SKColor.Parse("#127ac7")
            },
            new Microcharts.Entry(600)
            {
                Label = "Test 4",
                ValueLabel = "600",
                Color = SkiaSharp.SKColor.Parse("#127ac7")
            },            
            new Microcharts.Entry(300)
            {
                Label = "Test 5",
                ValueLabel = "300",
                Color = SkiaSharp.SKColor.Parse("#127ac7")
            }
        };

        public PatientDashboardPage(PatientItem patientItem)
        {
            InitializeComponent();
            BindingContext = patientItem;
            MyLineChart.Chart = new LineChart { Entries = entries };
            currentPatient = patientItem;
        }

        public DbResult Delete_From_DB()
        {
            DbResult res = new DbResult();
            string cs = @"server=oharam29-nolanm45-mmse-app.c4zhfzwco8qq.eu-west-1.rds.amazonaws.com;Port=3306;database=patient_info;user id=oharam29;password=f1sfo9mu;Persist Security Info=True;charset=utf8;";
            MySqlConnection con = new MySqlConnection(cs);
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                    MySqlCommand cmd = new MySqlCommand("DELETE FROM TBL_PATIENT WHERE PATIENTID  = @patient_id", con);
                    cmd.Parameters.AddWithValue("@patient_id", currentPatient.PatientID);


                    cmd.ExecuteNonQuery();

                    res.msg = "Patient Info deleted successfully";
                    res.success = true;
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
                con.Close();
            }
            return res;
        }

        private void Delete_Patient(object sender, EventArgs e)
        {
            DbResult result = Delete_From_DB();
            if (result.success)
            {
                App.Current.MainPage.DisplayAlert(result.msg, "", "Ok");
                Navigation.PopAsync();
            }
        }

        async void Review_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ReviewTestHomePage(currentPatient));
        }

        async void Go_Back(object sender, EventArgs e)
        {
            await Navigation.PopAsync();

        }
    }
}