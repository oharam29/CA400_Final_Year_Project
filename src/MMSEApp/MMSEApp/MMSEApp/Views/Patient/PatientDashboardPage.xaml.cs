using Microcharts;
using MMSEApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        }




    }
}