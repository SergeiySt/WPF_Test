using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.Net.Mime.MediaTypeNames;


namespace Test_wpf.Pages
{
    /// <summary>
    /// Interaction logic for PTest.xaml
    /// </summary>
    public partial class PTest : Page
    {
        private List<CTest> questions = new List<CTest>();
        private int currentQuestion = 0;
        private int score = 0;

        private CUsers users2;

        public PTest(CUsers user)
        {
            InitializeComponent();
            users2 = user;
            textFull.Text = $"{users2.Name} {users2.Surname}";

            InitializeComponent();

            questions.Add(new CTest("Як називається столиця України?", "Київ", new List<string>() { "Львів", "Харків", "Київ", "Одеса" }));
            questions.Add(new CTest("Який рік було прийнято за початок нашої ери?", "1", new List<string>() { "1", "10", "100", "1000" }));
            questions.Add(new CTest("Как называется главная героиня романа Льва Толстого 'Анна Каренина'?", "Анна", new List<string>() { "Маша", "Соня", "Катя", "Анна" }));

            ShowNextQuestion();
        }

        private void buttonSubmit_Click(object sender, RoutedEventArgs e)
        {
            RadioButton selectedAnswer = AnswersStackPanel.Children.OfType<RadioButton>().FirstOrDefault(rb => rb.IsChecked == true);

            if (selectedAnswer != null)
            {
                if (selectedAnswer.Content.ToString() == questions[currentQuestion].Answer)
                {
                    score++;
                }

                currentQuestion++;

                if (currentQuestion < questions.Count)
                {
                    ShowNextQuestion();
                }
                else
                {
                    FinishTest();
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите ответ");
            }
        }

        private void ShowNextQuestion()
        {
            QuestionTextBlock.Text = questions[currentQuestion].Text;
            AnswersStackPanel.Children.Clear();

            foreach (var option in questions[currentQuestion].Options)
            {
                RadioButton radioButton = new RadioButton();
                radioButton.Content = option;
                AnswersStackPanel.Children.Add(radioButton);
            }

            (AnswersStackPanel.Children[0] as RadioButton).IsChecked = true;
        }

        private void FinishTest()
        {
            PResult resultPage = new PResult(currentQuestion, score, users2, questions);
            this.NavigationService.Navigate(resultPage);
        }
    }
}
