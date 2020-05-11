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
    public partial class ExamHomePage : ContentPage
    {
        public ExamHomePage()
        {
            InitializeComponent();
        }

        async void StartExamButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ExamPage());
        }
    }
}