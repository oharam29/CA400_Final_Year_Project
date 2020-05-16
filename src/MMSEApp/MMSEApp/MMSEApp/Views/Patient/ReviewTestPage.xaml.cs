using MMSEApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MMSEApp.Views.Patient
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ReviewTestPage : ContentPage
    {
        private TestResults results; 
        public ReviewTestPage(TestResults testResults)
        {
            results = testResults;
            InitializeComponent();
            BindingContext = testResults;
            date.Text = "Date Taken: "+ testResults.DateTaken.ToString();
            score.Text = "Exam Score: " + testResults.ExamScore.ToString(); 
            startReview();
        }

        private void ClearGrid()
        {
            QuestionsGrid.Children.Clear(); // emptys grid
        }

        private void AddQuestionEntry(int QColumn, int QRow, int AColumn, int ARow, string question, string answer)
        {
            var Question = new Label { Text = question }; // makes a new label with the question set as its text
            var Answer = new Label { Text = answer}; // adds a new entry for answer

            QuestionsGrid.Children.Add(Question, QColumn, QRow); // add question to row
            QuestionsGrid.Children.Add(Answer, AColumn, ARow); // add answer to row
        }

        private void startReview()
        {


            ClearGrid();

            SectionTitle.Text = "Orientation";

            // add first set of questions

            AddQuestionEntry(0, 0, 1, 0, "What year is it?", results.OrientationAns1);
            AddQuestionEntry(0, 1, 1, 1, "What month is it?", results.OrientationAns2);
            AddQuestionEntry(0, 2, 1, 2, "What day is it?", results.OrientationAns3);
            AddQuestionEntry(0, 3, 1, 3, "What time is it?", results.OrientationAns4);
            AddQuestionEntry(0, 4, 1, 4, "What date is it?", results.OrientationAns5);

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
            startReview();
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
            AddQuestionEntry(0, 0, 1, 0, "What Country are we in?", results.OrientationAns6);
            AddQuestionEntry(0, 1, 1, 1, "What Town are we in?", results.OrientationAns7);
            AddQuestionEntry(0, 2, 1, 2, "What Province are we in?", results.OrientationAns8);
            AddQuestionEntry(0, 3, 1, 3, "What Hospital are we in?", results.OrientationAns9);
            AddQuestionEntry(0, 4, 1, 4, "What ward are we in?", results.OrientationAns10);

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
            AddQuestionEntry(0, 0, 1, 0, "This is a chair", results.RegistrationAns1);
            AddQuestionEntry(0, 1, 1, 1, "This is a car", results.RegistrationAns2);
            AddQuestionEntry(0, 2, 1, 2, "This is a house", results.RegistrationAns3);

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
            AddQuestionEntry(0, 0, 1, 0, "Subtract 7 from 100, Repeat 5 times", results.AttenCalcAns1);


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
            AddQuestionEntry(0, 0, 1, 0, "Can you name the 3 objects u learned in section 2? ", results.RecallAns1);
            AddQuestionEntry(0, 1, 1, 1, "", results.RecallAns2);
            AddQuestionEntry(0, 2, 1, 2, "", results.RecallAns3);

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
            AddQuestionEntry(0, 0, 1, 0, "Name a pencil and watch", results.LanguageAns1);
            AddQuestionEntry(0, 1, 1, 1, "Repeat \"No ifs,ands,or buts\" ", results.LanguageAns2);
            AddQuestionEntry(0, 2, 1, 2, "3 stage command ", results.LanguageAns3);
            AddQuestionEntry(0, 3, 1, 3, "Read a piece of paper ", results.LanguageAns4);
            AddQuestionEntry(0, 4, 1, 4, "write a sentence ", results.LanguageAns5);

            var backButton = new Button { Text = "Back" };
            backButton.Style = Application.Current.Resources["blueButtonStyle"] as Style;
            backButton.Clicked += new EventHandler(RecallQuestions);
            QuestionsGrid.Children.Add(backButton, 0, 5);

            
        }


    }
}