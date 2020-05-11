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
    public partial class MenuPage : ContentPage
    {
        MainPage RootPage { get => Application.Current.MainPage as MainPage; }
        List<HomeMenuItem> MenuStructure;
        public MenuPage()
        {
            InitializeComponent();
            MenuStructure = new List<HomeMenuItem>
            {
                new HomeMenuItem { ID = MenuItemType.Home, Title = "Home"},
                new HomeMenuItem { ID = MenuItemType.Patient, Title = "Patients"},
                new HomeMenuItem { ID = MenuItemType.Exam, Title = "Exam"},
            };

            ListViewMenu.ItemsSource = MenuStructure;
            ListViewMenu.SelectedItem = MenuStructure[0];
            ListViewMenu.ItemSelected += async (sender, e) =>
            {
                if (e.SelectedItem == null)
                    return;
                
                var id = (int)((HomeMenuItem)e.SelectedItem).ID;

                await RootPage.NavigateFromMenu(id);
               
            };
        }

        private void LogoutClicked(object sender, EventArgs e)
        {
            LoginPage main = new LoginPage();
            Application.Current.MainPage = main;
        }
    }
}