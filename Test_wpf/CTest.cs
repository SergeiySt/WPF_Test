using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_wpf
{
    public class CTest
    {
        public string Text { get; set; }
        public List<string> Answers { get; set; }
        public string Answer { get; set; }

        public List<string> Options { get; set; }

        //public CTest() { }


        public CTest(string text, string answer, List<string> options)
        {
            Text = text;
            Answers = new List<string>();
            Answer = answer;
            Answers.Add(answer);
            Options = options;
        }

        public void AddAnswer(string answer)
        {
            Answers.Add(answer);
        }
    }

    //public class CurrentQuestion
    //{
    //    private int currentQuestion { get; set; }

    //}


    //     private int currentQuestion = 0;
    //private int score = 0;
}
