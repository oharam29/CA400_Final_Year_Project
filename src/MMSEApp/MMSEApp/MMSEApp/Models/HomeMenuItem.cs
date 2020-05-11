using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MMSEApp.Models
{
    public enum MenuItemType
    {
        Home,
        Patient,
        Exam
    }
    public class HomeMenuItem
    {
        public MenuItemType ID { get; set; }
        public string Title { get; set; }
    }
}
