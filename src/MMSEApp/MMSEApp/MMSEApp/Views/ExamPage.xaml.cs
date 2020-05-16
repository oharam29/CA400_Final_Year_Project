using MMSEApp.Models;
using MMSEApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace MMSEApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ExamPage : ContentPage
    {
        ExamViewModel examViewModel;
        public ExamPage(PatientItem PatientSelected)
        {
            examViewModel = new ExamViewModel();
            InitializeComponent();
            BindingContext = examViewModel;
            examViewModel.PatientItem = PatientSelected;
            startExam();
        }

        private void ClearGrid() 
        {
            QuestionsGrid.Children.Clear(); // emptys grid
        }

        private void AddQuestionEntry(int QColumn, int QRow, int AColumn, int ARow, string question, string binding) 
        {
            var Question = new Label { Text = question }; // makes a new label with the question set as its text
            var Answer = new Entry(); // adds a new entry for answer
            Answer.SetBinding(Entry.TextProperty, new Binding(binding));
            
            QuestionsGrid.Children.Add(Question, QColumn, QRow); // add question to row
            QuestionsGrid.Children.Add(Answer, AColumn, ARow); // add answer to row
        }

        private void startExam()
        {
            

            ClearGrid();

            SectionTitle.Text = "Orientation";

            // add first set of questions

            AddQuestionEntry(0, 0, 1, 0, "What year is it?", "OrientationAns1");
            AddQuestionEntry(0, 1, 1, 1, "What month is it?", "OrientationAns2");
            AddQuestionEntry(0, 2, 1, 2, "What day is it?", "OrientationAns3");
            AddQuestionEntry(0, 3, 1, 3, "What time is it?", "OrientationAns4");
            AddQuestionEntry(0, 4, 1, 4, "What date is it?", "OrientationAns5");

            var backButton = new Button { Text = "Back" };
            backButton.Style = Application.Current.Resources["blueButtonStyle"] as Style;
            backButton.Clicked += new EventHandler(cancelExam);
            QuestionsGrid.Children.Add(backButton, 0, 5);


            // add the next 
            var nextButton = new Button { Text = "Next" };
            nextButton.Style = Application.Current.Resources["blueButtonStyle"] as Style;

            nextButton.Clicked += new EventHandler(OrientationQuestionPartTwo);
            QuestionsGrid.Children.Add(nextButton, 1, 5);
        }

       
        private void OrientationQuestions(object sender, EventArgs e) // first part
        {
            startExam();
        }

        async void cancelExam(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private void OrientationQuestionPartTwo(object sender, EventArgs e) // Second part
        {

            

            ClearGrid();

            SectionTitle.Text = "Orientation";

            // add first set of questions
            AddQuestionEntry(0, 0, 1, 0, "What Country are we in?", "OrientationAns6");
            AddQuestionEntry(0, 1, 1, 1, "What Town are we in?", "OrientationAns7");
            AddQuestionEntry(0, 2, 1, 2, "What Province are we in?", "OrientationAns8");
            AddQuestionEntry(0, 3, 1, 3, "What Hospital are we in?", "OrientationAns9");
            AddQuestionEntry(0, 4, 1, 4, "What ward are we in?", "OrientationAns10");

            var backButton = new Button { Text = "Back" };
            backButton.Style = Application.Current.Resources["blueButtonStyle"] as Style;
            backButton.Clicked += new EventHandler(OrientationQuestions);
            QuestionsGrid.Children.Add(backButton, 0, 5);
            // add the next 
            var nextButton = new Button { Text = "Next" };
            nextButton.Style = Application.Current.Resources["blueButtonStyle"] as Style;
            nextButton.Clicked += new EventHandler(RegistrationQuesitons);
            QuestionsGrid.Children.Add(nextButton, 1, 5);
        }

        private void RegistrationQuesitons(object sender, EventArgs e) // third part
        {
            ClearGrid();

            SectionTitle.Text = "Registration";
            // add second set of questions
            AddQuestionEntry(0, 0, 1, 0, "This is a chair", "RegistrationAns1");
            AddQuestionEntry(0, 1, 1, 1, "This is a car", "RegistrationAns2");
            AddQuestionEntry(0, 2, 1, 2, "This is a house", "RegistrationAns3");

            // back button 
            var backButton = new Button { Text = "Back" };
            backButton.Style = Application.Current.Resources["blueButtonStyle"] as Style;
            backButton.Clicked += new EventHandler(OrientationQuestionPartTwo);
            QuestionsGrid.Children.Add(backButton, 0, 5);

            // next button
            var nextButton = new Button { Text = "Next" };
            nextButton.Style = Application.Current.Resources["blueButtonStyle"] as Style;
            nextButton.Clicked += new EventHandler(AttentionCalulationQuestions);
            QuestionsGrid.Children.Add(nextButton, 1, 5);
        }

        private void AttentionCalulationQuestions(object sender, EventArgs e) // fourth part 
        {
            ClearGrid();

            SectionTitle.Text = "Attention and Calculation";
            AddQuestionEntry(0, 0, 1, 0, "Subtract 7 from 100, Repeat 5 times", "AttenCalcAns1");
            

            var backButton = new Button { Text = "Back" };
            backButton.Style = Application.Current.Resources["blueButtonStyle"] as Style;
            backButton.Clicked += new EventHandler(RegistrationQuesitons);
            QuestionsGrid.Children.Add(backButton, 0, 5);

            // next button
            var nextButton = new Button { Text = "Next" };
            nextButton.Style = Application.Current.Resources["blueButtonStyle"] as Style;
            nextButton.Clicked += new EventHandler(RecallQuestions);
            QuestionsGrid.Children.Add(nextButton, 1, 5);

        }

        private void RecallQuestions(object sender, EventArgs e) // fifth part
        {
            ClearGrid();

            SectionTitle.Text = "Recall";
            AddQuestionEntry(0, 0, 1, 0, "Can you name the 3 objects u learned in section 2? ", "RecallAns1");
            AddQuestionEntry(0, 1, 1, 1, "", "RecallAns2");
            AddQuestionEntry(0, 2, 1, 2, "", "RecallAns3");

            var backButton = new Button { Text = "Back" };
            backButton.Style = Application.Current.Resources["blueButtonStyle"] as Style;
            backButton.Clicked += new EventHandler(AttentionCalulationQuestions);
            QuestionsGrid.Children.Add(backButton, 0, 5);

            // next button
            var nextButton = new Button { Text = "Next" };
            nextButton.Style = Application.Current.Resources["blueButtonStyle"] as Style;
            nextButton.Clicked += new EventHandler(LanguageQuestions);
            QuestionsGrid.Children.Add(nextButton, 1, 5);
        }

        private void LanguageQuestions(object sender, EventArgs e) // sixth part
        {
            ClearGrid();
            SectionTitle.Text = "Language";
            AddQuestionEntry(0, 0, 1, 0, "Name a pencil and watch", "LanguageAns1");
            AddQuestionEntry(0, 1, 1, 1, "Repeat \"No ifs,ands,or buts\" ", "LanguageAns2");
            AddQuestionEntry(0, 2, 1, 2, "3 stage command ", "LanguageAns3");
            AddQuestionEntry(0, 3, 1, 3, "Read a piece of paper ", "LanguageAns4");
            AddQuestionEntry(0, 4, 1, 4, "write a sentence ", "LanguageAns5");

            var backButton = new Button { Text = "Back" };
            backButton.Style = Application.Current.Resources["blueButtonStyle"] as Style;
            backButton.Clicked += new EventHandler(RecallQuestions);
            QuestionsGrid.Children.Add(backButton, 0, 5);

            // next button
            var nextButton = new Button { Text = "Next" };
            nextButton.Style = Application.Current.Resources["blueButtonStyle"] as Style;
            nextButton.Clicked += new EventHandler(CopyingQuestion);
            QuestionsGrid.Children.Add(nextButton, 1, 5);
        }
        
        async void CopyingQuestion(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DrawingQuestion(examViewModel));
            //ClearGrid();

            //SectionTitle.Text = "Copying";
            //AddQuestionEntry(0, 0, 1, 0, "Copy this picture");

            //var backButton = new Button { Text = "Back" };
            //backButton.Clicked += new EventHandler(LanguageQuestions);
            //QuestionsGrid.Children.Add(backButton, 0, 5);

            //var FinishTest = new Button { Text = "Finish Test" };
            //FinishTest.Clicked += new EventHandler(RecallQuestions); 
            //QuestionsGrid.Children.Add(FinishTest, 1, 5);
        }

         

    }
}