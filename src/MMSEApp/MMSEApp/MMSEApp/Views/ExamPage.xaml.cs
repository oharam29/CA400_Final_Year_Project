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
    public partial class ExamPage : ContentPage
    {
        public ExamPage()
        {
            InitializeComponent();
        }

        private void StartExam_Clicked(object sender, EventArgs e)
        {

        }
    }
}