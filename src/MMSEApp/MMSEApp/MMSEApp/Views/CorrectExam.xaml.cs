using MMSEApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MMSEApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CorrectExam : ContentPage
    {
        private ExamViewModel examViewModel;
        public CorrectExam(ExamViewModel examView)
        {
            examViewModel = examView;
            InitializeComponent();
            Score.BindingContext = examView;
            startCorrect();
        }

        private void ClearGrid()
        {
            QuestionsGrid.Children.Clear(); // emptys grid
        }

        private void AddQuestionEntry(int QColumn, int QRow, int AColumn, int ARow, string question, string binding)
        {
            var stack = new StackLayout { Spacing = 10, Orientation = StackOrientation.Vertical  };

            var Question = new Label { Text = question, FontAttributes = FontAttributes.Bold}; // makes a new label with the question set as its text
            var Answer = new Label { Text = "Patient Answer: " + binding }; // adds a new entry for answer


            stack.Children.Add(Question);
            stack.Children.Add(Answer);

            var checkbox = new CheckBox();
            checkbox.CheckedChanged += new EventHandler<Xamarin.Forms.CheckedChangedEventArgs>(CheckBox_CheckedChanged);

            QuestionsGrid.Children.Add(stack, QColumn, QRow); // add question to row
            QuestionsGrid.Children.Add(checkbox, AColumn, ARow); // add answer to row
        }

        private void CheckBox_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            if (e.Value)
            {
                examViewModel.ExamScore += 1;
            }
            else
            {
                examViewModel.ExamScore -= 1;
            }
        }

        private void startCorrect()
        {


            ClearGrid();

            SectionTitle.Text = "Orientation";

            // add first set of questions

            AddQuestionEntry(0, 0, 1, 0, "What year is it?", examViewModel.OrientationAns1);
            AddQuestionEntry(0, 1, 1, 1, "What month is it?", examViewModel.OrientationAns2);
            AddQuestionEntry(0, 2, 1, 2, "What day is it?", examViewModel.OrientationAns3);
            AddQuestionEntry(0, 3, 1, 3, "What time is it?", examViewModel.OrientationAns4);
            AddQuestionEntry(0, 4, 1, 4, "What date is it?", examViewModel.OrientationAns5);

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
            startCorrect();
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
            AddQuestionEntry(0, 0, 1, 0, "What Country are we in?", examViewModel.OrientationAns6);
            AddQuestionEntry(0, 1, 1, 1, "What Town are we in?", examViewModel.OrientationAns7);
            AddQuestionEntry(0, 2, 1, 2, "What Province are we in?", examViewModel.OrientationAns8);
            AddQuestionEntry(0, 3, 1, 3, "What Hospital are we in?", examViewModel.OrientationAns9);
            AddQuestionEntry(0, 4, 1, 4, "What ward are we in?", examViewModel.OrientationAns10);

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
            AddQuestionEntry(0, 0, 1, 0, "This is a chair", examViewModel.RegistrationAns1);
            AddQuestionEntry(0, 1, 1, 1, "This is a car", examViewModel.RegistrationAns2);
            AddQuestionEntry(0, 2, 1, 2, "This is a house", examViewModel.RegistrationAns3);

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
            AddQuestionEntry(0, 0, 1, 0, "Subtract 7 from 100, Repeat 5 times", examViewModel.AttenCalcAns1);


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
            AddQuestionEntry(0, 0, 1, 0, "Can you name the 3 objects u learned in section 2? ", examViewModel.RecallAns1);
            AddQuestionEntry(0, 1, 1, 1, "", examViewModel.RecallAns2);
            AddQuestionEntry(0, 2, 1, 2, "", examViewModel.RecallAns3);

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
            AddQuestionEntry(0, 0, 1, 0, "Name a pencil and watch", examViewModel.LanguageAns1);
            AddQuestionEntry(0, 1, 1, 1, "Repeat \"No ifs,ands,or buts\" ", examViewModel.LanguageAns2);
            AddQuestionEntry(0, 2, 1, 2, "3 stage command ", examViewModel.LanguageAns3);
            AddQuestionEntry(0, 3, 1, 3, "Read a piece of paper ", examViewModel.LanguageAns4);
            AddQuestionEntry(0, 4, 1, 4, "write a sentence ", examViewModel.LanguageAns5);

            var backButton = new Button { Text = "Back" };
            backButton.Style = Application.Current.Resources["blueButtonStyle"] as Style;
            backButton.Clicked += new EventHandler(RecallQuestions);
            QuestionsGrid.Children.Add(backButton, 0, 5);

            // next button
            var nextButton = new Button { Text = "Next" };
            nextButton.Style = Application.Current.Resources["blueButtonStyle"] as Style;
            nextButton.Clicked += new EventHandler(DrawingResult);
            QuestionsGrid.Children.Add(nextButton, 1, 5);
        }

        private void DrawingResult(object sender, EventArgs e)
        {
            ClearGrid();
            SectionTitle.Text = "Drawing";
            AddQuestionEntry(0, 0, 1, 0, "Was the Drawing Correct?", examViewModel.DrawingAns1);

            var backButton = new Button { Text = "Back" };
            backButton.Style = Application.Current.Resources["blueButtonStyle"] as Style;
            backButton.Clicked += new EventHandler(LanguageQuestions);
            QuestionsGrid.Children.Add(backButton, 0, 5);

            // next button
            var nextButton = new Button { Text = "Save Results" };
            nextButton.Style = Application.Current.Resources["blueButtonStyle"] as Style;
            nextButton.Clicked += new EventHandler(SaveResults);
            QuestionsGrid.Children.Add(nextButton, 1, 5);
        }

        private void SaveResults(object sender, EventArgs e)
        {
            examViewModel.SaveExamResult();
            Navigation.RemovePage(Navigation.NavigationStack[Navigation.NavigationStack.Count - 3]);
            Navigation.RemovePage(Navigation.NavigationStack[Navigation.NavigationStack.Count - 2]);
            Navigation.PopAsync();
        }
    }
}