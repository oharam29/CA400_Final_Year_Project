using Microcharts;
using MMSEApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MMSEApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        Doctor currentDoc = App.currentDoctor;
        private List<Microcharts.Entry> entries = new List<Microcharts.Entry>
        {
            new Microcharts.Entry(200)
            {
                Label = "Ages 80+",
                ValueLabel = "Avg score 5",
                Color = SkiaSharp.SKColor.Parse("#127ac7")

            },
            new Microcharts.Entry(300)
            {
                Label = "Age 60-70",
                ValueLabel = "Avg 10",
                Color = SkiaSharp.SKColor.Parse("#127ac7")
            },
            new Microcharts.Entry(400)
            {
                Label = "Age 40-50",
                ValueLabel = "Avg 15",
                Color = SkiaSharp.SKColor.Parse("#127ac7")
            },
            new Microcharts.Entry(500)
            {
                Label = "Age 30-40",
                ValueLabel = "Avg 20",
                Color = SkiaSharp.SKColor.Parse("#127ac7")
            },
            new Microcharts.Entry(600)
            {
                Label = "Age 20-30",
                ValueLabel = "Avg 25 +",
                Color = SkiaSharp.SKColor.Parse("#127ac7")
            },
            new Microcharts.Entry(600)
            {
                Label = "Age 10-20",
                ValueLabel = "Avg 25 +",
                Color = SkiaSharp.SKColor.Parse("#127ac7")
            }
        };

        public HomePage()
        {
            InitializeComponent();
            DocName.Text = currentDoc.FirstName + " " + currentDoc.LastName;
            MyLineChart.Chart = new RadarChart { Entries = entries };
            
        }

        async void Patients_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PatientsViewPage());
        }

        async void Exams_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ExamHomePage());
        }
    }
}