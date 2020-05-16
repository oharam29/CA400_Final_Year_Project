using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace MMSEApp.Models
{
    public class TestResults
    {
        public int DoctorID { get; set; }
        public int PatientID { get; set; }
        public int ResultID { get; set; }
        public string OrientationAns1 { get; set; }
        public string OrientationAns2 { get; set; }
        public string OrientationAns3 { get; set; }
        public string OrientationAns4 { get; set; }
        public string OrientationAns5 { get; set; }
        public string OrientationAns6 { get; set; }
        public string OrientationAns7 { get; set; }
        public string OrientationAns8 { get; set; }
        public string OrientationAns9 { get; set; }
        public string OrientationAns10 { get; set; }
        public string RegistrationAns1 { get; set; }
        public string RegistrationAns2 { get; set; }
        public string RegistrationAns3 { get; set; }
        public string AttenCalcAns1 { get; set; }
        public string RecallAns1 { get; set; }
        public string RecallAns2 { get; set; }
        public string RecallAns3 { get; set; }
        public string LanguageAns1 { get; set; }
        public string LanguageAns2 { get; set; }
        public string LanguageAns3 { get; set; }
        public string LanguageAns4 { get; set; }
        public string LanguageAns5 { get; set; }
        public string DrawingAns1 { get; set; }
        public DateTime DateTaken { get; set; }
        public int ExamScore { get; set; }

    }
}
