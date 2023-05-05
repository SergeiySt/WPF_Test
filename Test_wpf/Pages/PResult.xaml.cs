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

namespace Test_wpf.Pages
{
    /// <summary>
    /// Interaction logic for PResult.xaml
    /// </summary>
    public partial class PResult : Page
    {
        private List<CTest> questions2 = new List<CTest>();
        private int currentQuestion;
        private int score;
        private CUsers users2;
        public PResult(int currentQuestion, int score, CUsers users2, List<CTest> questions)
        {
            InitializeComponent();

            this.currentQuestion = currentQuestion;
            this.score = score;
            this.users2 = users2;
           this.questions2 = questions;

            //    textResult.Text = $"Поздравляем, {user.Name} {user.Surname}! Вы ответили правильно на {score} вопросов из {questions.Count}. Оценка: {GetGrade(score, questions.Count)}";

            fullName5.Text = $"{users2.Name} {users2.Surname}";
            textblockScore.Text = $"{score}";
            textblockQuestions.Text = $"{questions2.Count}";
            textblockGrade.Text = $"{GetGrade()}";

    }



        private string GetGrade()
        {
            // Определим оценку в зависимости от количества правильных ответов
            double percentage = (double)score / questions2.Count * 100;

            if (percentage >= 90)
            {
                return "Відмінно!";
            }
            else if (percentage >= 70)
            {
                return "Добре!";
            }
            else if (percentage >= 50)
            {
                return "Задовільно!";
            }
            else
            {
                return "Незадовільно";
            }

        }
    }
}
