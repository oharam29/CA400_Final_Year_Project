using MMSEApp.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text;
using Xamarin.Forms;

namespace MMSEApp.ViewModels
{
    public class ExamViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public INavigation navigation;
        public PatientItem PatientItem;
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

        private string drawingAns1;
        public string DrawingAns1
        {
            get { return drawingAns1; }
            set
            {
                drawingAns1 = value;
                PropertyChanged(this, new PropertyChangedEventArgs("DrawingAns1"));
            }
        }

        private int examScore;
        public int ExamScore
        {
            get { return examScore; }
            set
            {
                examScore = value;
                PropertyChanged(this, new PropertyChangedEventArgs("ExamScore"));
            }
        }

        public DbResult SaveExamResult()
        {
            DbResult res = new DbResult();
            string cs = @"server=oharam29-nolanm45-mmse-app.c4zhfzwco8qq.eu-west-1.rds.amazonaws.com;Port=3306;database=patient_info;user id=oharam29;password=f1sfo9mu;Persist Security Info=True;charset=utf8;Allow User Variables=true;";
            MySqlConnection con = new MySqlConnection(cs);
            try
            {

                if (con.State == ConnectionState.Closed)
                {
                    con.Open(); // open connection 
                    MySqlCommand cmd = new MySqlCommand("INSERT INTO TBL_RESULTS(DoctorID,PatientID," +
                        "OrientationAns1, OrientationAns2, OrientationAns3, OrientationAns4, OrientationAns5," +
                        "OrientationAns6, OrientationAns7, OrientationAns8, OrientationAns9, OrientationAns10," +
                        "RegistrationAns1, RegistrationAns2, RegistrationAns3, AttenCalcAns1, RecallAns1, RecallAns2," +
                        "RecallAns3, LanguageAns1, LanguageAns2, LanguageAns3, LanguageAns4, LanguageAns5, DrawingAns1, ExamScore)" +
                        " VALUES(@DocID, @PatientID, @OriAns1, @OriAns2, @OriAns3, @OriAns4, @OriAns5, @OriAns6" +
                        ", @OriAns7, @OriAns8, @OriAns9, @OriAns10, @RegAns1, @RegAns2, @RegAns3, @AttenAns1, @RecAns1, " +
                        "@RecAns2, @RecAns3, @LangAns1, @LangAns2, @LangAns3, @LangAns4, @LangAns5, @DrawAns1, @result )", con); // sql query string

                    DrawingAns1 = "Test Draw";
                    // add parameters
                    cmd.Parameters.AddWithValue("@DocID", App.currentDoctor.DoctorId);
                    cmd.Parameters.AddWithValue("@PatientID", PatientItem.PatientID);
                    cmd.Parameters.AddWithValue("@OriAns1", OrientationAns1);
                    cmd.Parameters.AddWithValue("@OriAns2", OrientationAns2);
                    cmd.Parameters.AddWithValue("@OriAns3", OrientationAns3);
                    cmd.Parameters.AddWithValue("@OriAns4", OrientationAns4);
                    cmd.Parameters.AddWithValue("@OriAns5", OrientationAns5);
                    cmd.Parameters.AddWithValue("@OriAns6", OrientationAns6);
                    cmd.Parameters.AddWithValue("@OriAns7", OrientationAns7);
                    cmd.Parameters.AddWithValue("@OriAns8", OrientationAns8);
                    cmd.Parameters.AddWithValue("@OriAns9", OrientationAns9);
                    cmd.Parameters.AddWithValue("@OriAns10", OrientationAns10);
                    cmd.Parameters.AddWithValue("@RegAns1", RegistrationAns1);
                    cmd.Parameters.AddWithValue("@RegAns2", RegistrationAns2);
                    cmd.Parameters.AddWithValue("@RegAns3", RegistrationAns3);
                    cmd.Parameters.AddWithValue("@AttenAns1", AttenCalcAns1);
                    cmd.Parameters.AddWithValue("@RecAns1", RecallAns1);
                    cmd.Parameters.AddWithValue("@RecAns2", RecallAns2);
                    cmd.Parameters.AddWithValue("@RecAns3", RecallAns3);
                    cmd.Parameters.AddWithValue("@LangAns1", LanguageAns1);
                    cmd.Parameters.AddWithValue("@LangAns2", LanguageAns2);
                    cmd.Parameters.AddWithValue("@LangAns3", LanguageAns3);
                    cmd.Parameters.AddWithValue("@LangAns4", LanguageAns4);
                    cmd.Parameters.AddWithValue("@LangAns5", LanguageAns5);
                    cmd.Parameters.AddWithValue("@DrawAns1", DrawingAns1);
                    cmd.Parameters.AddWithValue("@result", ExamScore);

                    cmd.ExecuteNonQuery(); // execute the query

                    res.msg = "User added successfully";
                    res.success = true;

                    MySqlCommand command = new MySqlCommand("UPDATE TBL_PATIENT SET LastTestDate = @now WHERE PatientID = @PID", con);
 
                    MySqlCommand command2 = new MySqlCommand("SELECT DateTaken FROM TBL_RESULTS ORDER BY DateTaken LIMIT 1", con);
                    using (MySqlDataReader reader = command2.ExecuteReader())
                    {
                        while (reader.Read()) // read in query results
                        {
                            cmd.Parameters.AddWithValue("@now", reader.GetDateTime(0));
                        };
                    }
  
                    
                    cmd.Parameters.AddWithValue("@PID", PatientItem.PatientID);
                    command.ExecuteNonQuery();

                    App.Current.MainPage.DisplayAlert("Exam Saved","","OK");
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
                con.Close(); // close connection 
            }
            return res;
        }

    }
}
