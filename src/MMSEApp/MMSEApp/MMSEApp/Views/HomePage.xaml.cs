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
        public HomePage()
        {
            InitializeComponent();
            DocName.Text = currentDoc.FirstName + " " + currentDoc.LastName;
        }
    }
}