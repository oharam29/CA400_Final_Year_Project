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

        private void StartExam_Clicked(object sender, EventArgs e)
        {
            OrientationQuestions();

        }

        private void OrientationQuestions()
        {
            var firstQuestion = new Label { Text = "What year is it?" };
            var firstAnswer = new Entry();

            QuestionsGrid.Children.Add(firstQuestion,0,0);
            QuestionsGrid.Children.Add(firstAnswer,1,0);

            var secondQuestion = new Label { Text = "What month is it?" };
            var secondAnswer = new Entry();

            QuestionsGrid.Children.Add(secondQuestion, 0, 1);
            QuestionsGrid.Children.Add(secondAnswer, 1, 1);

            var thirdQuestion = new Label { Text = "What day is it?" };
            var thirdAnswer = new Entry();

            QuestionsGrid.Children.Add(thirdQuestion, 0, 2);
            QuestionsGrid.Children.Add(thirdAnswer, 1, 2);

            var fourthQuestion = new Label { Text = "What date is it?" };
            var fourthAnswer = new Entry();

            QuestionsGrid.Children.Add(fourthQuestion, 0, 3);
            QuestionsGrid.Children.Add(fourthAnswer, 1, 3);

            var fifthQuestion = new Label { Text = "What time is it?" };
            var fifthAnswer = new Entry();

            QuestionsGrid.Children.Add(fifthQuestion, 0, 4);
            QuestionsGrid.Children.Add(fifthAnswer, 1, 4);

            var nextButton = new Button { Text = "Next" };
            nextButton.Clicked += new EventHandler(NextButton);
            QuestionsGrid.Children.Add(nextButton, 1, 5);
        }

        private void NextButton(object sender, EventArgs e)
        {


            var firstQuestion = new Label { Text = "This is a Chair" };
            var firstAnswer = new Entry();

            QuestionsGrid.Children.Add(firstQuestion, 0, 0);
            QuestionsGrid.Children.Add(firstAnswer, 1, 0);

            var secondQuestion = new Label { Text = "This is a car" };
            var secondAnswer = new Entry();

            QuestionsGrid.Children.Add(secondQuestion, 0, 1);
            QuestionsGrid.Children.Add(secondAnswer, 1, 1);

            var thirdQuestion = new Label { Text = "This is a potato" };
            var thirdAnswer = new Entry();

            QuestionsGrid.Children.Add(thirdQuestion, 0, 2);
            QuestionsGrid.Children.Add(thirdAnswer, 1, 2);
        }
    }
}