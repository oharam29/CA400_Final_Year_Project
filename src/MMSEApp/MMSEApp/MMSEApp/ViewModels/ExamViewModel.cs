using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace MMSEApp.ViewModels
{
    public class ExamViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public INavigation navigation;

        public ExamViewModel() { }
        
        // orientation answers
        #region 

        private string orientationAns1;
        public string OrientationAns1 
        {
            get { return orientationAns1; }
            set
            {
                orientationAns1 = value;
                PropertyChanged(this, new PropertyChangedEventArgs("OrientationAns1"));
            }
        }


        private string orientationAns2;
        public string OrientationAns2
        {
            get { return orientationAns2; }
            set
            {
                orientationAns2 = value;
                PropertyChanged(this, new PropertyChangedEventArgs("OrientationAns2"));
            }
        }

        private string orientationAns3;
        public string OrientationAns3
        {
            get { return orientationAns3; }
            set
            {
                orientationAns3 = value;
                PropertyChanged(this, new PropertyChangedEventArgs("OrientationAns3"));
            }
        }

        private string orientationAns4;
        public string OrientationAns4
        {
            get { return orientationAns4; }
            set
            {
                orientationAns4 = value;
                PropertyChanged(this, new PropertyChangedEventArgs("OrientationAns4"));
            }
        }

        private string orientationAns5;
        public string OrientationAns5
        {
            get { return orientationAns5; }
            set
            {
                orientationAns5 = value;
                PropertyChanged(this, new PropertyChangedEventArgs("OrientationAns5"));
            }
        }

        private string orientationAns6;
        public string OrientationAns6
        {
            get { return orientationAns6; }
            set
            {
                orientationAns6 = value;
                PropertyChanged(this, new PropertyChangedEventArgs("OrientationAns6"));
            }
        }

        private string orientationAns7;
        public string OrientationAns7
        {
            get { return orientationAns7; }
            set
            {
                orientationAns7 = value;
                PropertyChanged(this, new PropertyChangedEventArgs("OrientationAns7"));
            }
        }

        private string orientationAns8;
        public string OrientationAns8
        {
            get { return orientationAns8; }
            set
            {
                orientationAns8 = value;
                PropertyChanged(this, new PropertyChangedEventArgs("OrientationAns3"));
            }
        }

        private string orientationAns9;
        public string OrientationAns9
        {
            get { return orientationAns9; }
            set
            {
                orientationAns9 = value;
                PropertyChanged(this, new PropertyChangedEventArgs("OrientationAns9"));
            }
        }

        private string orientationAns10;
        public string OrientationAns10
        {
            get { return orientationAns10; }
            set
            {
                orientationAns10 = value;
                PropertyChanged(this, new PropertyChangedEventArgs("OrientationAns10"));
            }
        }

        #endregion

        // registration answers
        #region
        private string registrationAns1;
        public string RegistrationAns1
        {
            get { return registrationAns1; }
            set
            {
                registrationAns1 = value;
                PropertyChanged(this, new PropertyChangedEventArgs("RegistrationAns1"));
            }
        }

        private string registrationAns2;
        public string RegistrationAns2
        {
            get { return registrationAns2; }
            set
            {
                registrationAns2 = value;
                PropertyChanged(this, new PropertyChangedEventArgs("RegistrationAns2"));
            }
        }

        private string registrationAns3;
        public string RegistrationAns3
        {
            get { return registrationAns3; }
            set
            {
                registrationAns3 = value;
                PropertyChanged(this, new PropertyChangedEventArgs("RegistrationAns3"));
            }
        }
        #endregion

        //  Attention and Calculation answers
        #region
        private string attenCalcAns1;
        public string AttenCalcAns1
        {
            get { return attenCalcAns1; }
            set
            {
                attenCalcAns1 = value;
                PropertyChanged(this, new PropertyChangedEventArgs("AttenCalcAns1"));
            }
        }

        #endregion

        // recall answers
        #region
        private string recallAns1;
        public string RecallAns1
        {
            get { return recallAns1; }
            set
            {
                recallAns1 = value;
                PropertyChanged(this, new PropertyChangedEventArgs("RecallAns1"));
            }
        }

        private string recallAns2;
        public string RecallAns2
        {
            get { return recallAns2; }
            set
            {
                recallAns2 = value;
                PropertyChanged(this, new PropertyChangedEventArgs("RecallAns2"));
            }
        }

        private string recallAns3;
        public string RecallAns3
        {
            get { return recallAns3; }
            set
            {
                recallAns3 = value;
                PropertyChanged(this, new PropertyChangedEventArgs("RecallAns3"));
            }
        }
        #endregion

        // Language questions
        #region
        private string languageAns1;
        public string LanguageAns1
        {
            get { return languageAns1; }
            set
            {
                languageAns1 = value;
                PropertyChanged(this, new PropertyChangedEventArgs("LanguageAns1"));
            }
        }

        private string languageAns2;
        public string LanguageAns2
        {
            get { return languageAns2; }
            set
            {
                languageAns2 = value;
                PropertyChanged(this, new PropertyChangedEventArgs("LanguageAns2"));
            }
        }

        private string languageAns3;
        public string LanguageAns3
        {
            get { return languageAns3; }
            set
            {
                languageAns3 = value;
                PropertyChanged(this, new PropertyChangedEventArgs("LanguageAns3"));
            }
        }

        private string languageAns4;
        public string LanguageAns4
        {
            get { return languageAns4; }
            set
            {
                languageAns4 = value;
                PropertyChanged(this, new PropertyChangedEventArgs("LanguageAns4"));
            }
        }

        private string languageAns5;
        public string LanguageAns5
        {
            get { return languageAns5; }
            set
            {
                languageAns5 = value;
                PropertyChanged(this, new PropertyChangedEventArgs("LanguageAns5"));
            }
        }
        #endregion

    }
}
