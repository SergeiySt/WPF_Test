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
            questions.Add(new CTest("Яка подія стала початком Першої світової війни?", "Вбивство Франца Фердинанда у Сараєві", new List<string>() { "Напад Німеччини на Польщу", "Вбивство Франца Фердинанда у Сараєві", "Напад Німеччини на Францію", "Вибух Лузитанії" }));
            questions.Add(new CTest("Коли відбулася Битва під Ватерлоо?", "18 червня 1815 року", new List<string>() { "13 червня 1814 року", "24 жовтня 1815 року", "18 червня 1815 року", "15 червня 1816 року" }));
            questions.Add(new CTest("Хто завоював Галлію?", "Гай Юлій Цезар", new List<string>() { "Саня", "Гай Юлій Цезар", "Гней Помпей Великий", "Хто зна" }));
            questions.Add(new CTest("Хто заснував місто Львів?", "Данило Галицький", new List<string>() { "Лев Данилович", "Данило Галицький", "Ігор Петрович", "Андрій Данилко" }));
            questions.Add(new CTest("Найбільша пустеля у світі?", "Антарктична пустеля", new List<string>() { "Сахара", "Антарктична пустеля", "Велика пустеля Вікторія", "Якась пустеля" }));
            questions.Add(new CTest("Вага тіла - це?", "сила, з якою тіло діє на опору чи підвіс", new List<string>() { "сила, з якою тіло притягується до Землі", "сила, з якою тіло діє на опору", "сила, з якою тіло діє на опору чи підвіс", "хто зна" }));
            questions.Add(new CTest("Ядро атома складається з ...", "Протонів і нейтронів", new List<string>() { "Протонів і електронів", "Протонів і нейтронів", "α-частинок і нейтронів", "Хто зна" }));
            questions.Add(new CTest("Хто такий Богдан Хмельницький?", "Гетьман Війська Запорозького", new List<string>() { "Гетьман Війська Запорозького", "Отоман", "Командир", "Начальник" }));

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
                radioButton.FontSize = 20;
                radioButton.Height = 30;
                radioButton.Width = 750;
                radioButton.VerticalContentAlignment = VerticalAlignment.Center;
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
