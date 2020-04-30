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
        
        public ExamPage()
        {
            InitializeComponent();
        }

        private void ClearGrid() 
        {
            QuestionsGrid.Children.Clear(); // emptys grid
        }

        private void AddQuestionEntry(int QColumn, int QRow, int AColumn, int ARow, string question) 
        {
            var Question = new Label { Text = question }; // makes a new label with the question set as its text
            var Answer = new Entry(); // adds a new entry for answer

            QuestionsGrid.Children.Add(Question, QColumn, QRow); // add question to row
            QuestionsGrid.Children.Add(Answer, AColumn, ARow); // add answer to row
        }

       
        private void OrientationQuestions(object sender, EventArgs e) // first part
        {

            ExamContent.Children.Remove(startButton); // remove the start button

            ClearGrid();

            SectionTitle.Text = "Orientation";

            // add first set of questions
            AddQuestionEntry(0, 0, 1, 0, "What year is it?");
            AddQuestionEntry(0, 1, 1, 1, "What month is it?");
            AddQuestionEntry(0, 2, 1, 2, "What day is it?");
            AddQuestionEntry(0, 3, 1, 3, "What time is it?");
            AddQuestionEntry(0, 4, 1, 4, "What year is it?");

            // add the next 
            var nextButton = new Button { Text = "Next" };
            nextButton.Clicked += new EventHandler(RegistrationQuesitons);
            QuestionsGrid.Children.Add(nextButton, 1, 5);
        }

        private void RegistrationQuesitons(object sender, EventArgs e) // second part
        {
            ClearGrid();

            SectionTitle.Text = "Registration";
            // add second set of questions
            AddQuestionEntry(0, 0, 1, 0, "This is a chair");
            AddQuestionEntry(0, 1, 1, 1, "This is a car");
            AddQuestionEntry(0, 2, 1, 2, "This is a house");

            // back button 
            var backButton = new Button { Text = "Back" };
            backButton.Clicked += new EventHandler(OrientationQuestions);
            QuestionsGrid.Children.Add(backButton, 0, 5);

            // next button
            var nextButton = new Button { Text = "Next" };
            nextButton.Clicked += new EventHandler(AttentionCalulationQuestions);
            QuestionsGrid.Children.Add(nextButton, 1, 5);
        }

        private void AttentionCalulationQuestions(object sender, EventArgs e) // third part 
        {
            ClearGrid();

            SectionTitle.Text = "Attention and Calculation";
            AddQuestionEntry(0, 0, 1, 0, "Subtract 7 from 100, Repeat 5 times");
            for(int i = 1; i < 5; i++)
            {
                QuestionsGrid.Children.Add( new Entry(),1,i);
            }

            var backButton = new Button { Text = "Back" };
            backButton.Clicked += new EventHandler(RegistrationQuesitons);
            QuestionsGrid.Children.Add(backButton, 0, 5);

            // next button
            var nextButton = new Button { Text = "Next" };
            nextButton.Clicked += new EventHandler(RecallQuestions);
            QuestionsGrid.Children.Add(nextButton, 1, 5);

        }

        private void RecallQuestions(object sender, EventArgs e) // fourth part
        {
            ClearGrid();

            SectionTitle.Text = "Recall";
            AddQuestionEntry(0, 0, 1, 0, "Can you name the 3 objects u learned in section 2");
            for (int i = 1; i < 4; i++)
            {
                QuestionsGrid.Children.Add(new Entry(), 1, i);
            }

            var backButton = new Button { Text = "Back" };
            backButton.Clicked += new EventHandler(AttentionCalulationQuestions);
            QuestionsGrid.Children.Add(backButton, 0, 5);

            // next button
            var nextButton = new Button { Text = "Next" };
            nextButton.Clicked += new EventHandler(LanguageQuestions);
            QuestionsGrid.Children.Add(nextButton, 1, 5);
        }

        private void LanguageQuestions(object sender, EventArgs e) // fifth part
        {
            ClearGrid();
            SectionTitle.Text = "Language";
            AddQuestionEntry(0, 0, 1, 0, "Name a pencil and watch");
            AddQuestionEntry(0, 1, 1, 1, "Repeat \"No ifs,ands,or buts\" ");
            AddQuestionEntry(0, 2, 1, 2, "3 stage command ");
            AddQuestionEntry(0, 3, 1, 3, "Read a piece of paper ");
            AddQuestionEntry(0, 4, 1, 4, "write a sentence ");

            var backButton = new Button { Text = "Back" };
            backButton.Clicked += new EventHandler(RecallQuestions);
            QuestionsGrid.Children.Add(backButton, 0, 5);

            // next button
            var nextButton = new Button { Text = "Next" };
            nextButton.Clicked += new EventHandler(CopyingQuestion);
            QuestionsGrid.Children.Add(nextButton, 1, 5);
        }
        
        private void CopyingQuestion(object sender, EventArgs e)
        {
            ClearGrid();

            SectionTitle.Text = "Copying";
            AddQuestionEntry(0, 0, 1, 0, "Copy this picture");

            var backButton = new Button { Text = "Back" };
            backButton.Clicked += new EventHandler(LanguageQuestions);
            QuestionsGrid.Children.Add(backButton, 0, 5);

            var FinishTest = new Button { Text = "Finish Test" };
            FinishTest.Clicked += new EventHandler(RecallQuestions);
            QuestionsGrid.Children.Add(FinishTest, 1, 5);
        }

    }
}