using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Test_Wrapper;

namespace usue_online_tests.Tests.List
{
    public class Analit004 : ITestCreator, ITest
    {
        private int answer1;
        private int answer2;
        private int answer3;
        private int answer4;
        private int answer5;
        private int answer6;

        public int TestID { get; set; }
        public string Name { get; } = "Аналитическая геометрия 004";
        public string Description { get; } = "Упражнение по аналитической геометрии";

        public ITest CreateTest(int randomSeed)
        {
            Random random = new Random(randomSeed);

            answer1 = random.Next(-5, 5);
            answer2 = random.Next(-5, 5);
            answer3 = random.Next(-5, 5);
            answer4 = random.Next(-5, 5);
            answer5 = random.Next(-5, 5);
            answer6 = random.Next(-5, 5);

            var test = new Analit004
            {
                Text = $"Общие уравнения плоскости, проходящей через точку \\( A({answer1}, {answer2}, {answer3}) \\) перпендикулярно вектору \\( \\vec{{n}} = {answer4}\\vec{{i}} + {answer5}\\vec{{j}} + {answer6}\\vec{{k}} \\), имеют вид в векторной форме:" +
                       $"\\[" +
                       $"\\quad \\left( <answer1> \\vec{{i}} + <answer2> \\vec{{j}} + <answer3> \\vec{{k}}, \\, ( x - <answer4>)\\vec{{i}} + ( y - <answer5>)\\vec{{j}} + ( z - <answer6>)\\vec{{k}} \\right) = 0," +
                       $"\\]" +
                       $"в координатной форме: " +
                       $"\\[" +
                       $"\\quad <answer7> ( x - <answer8>) + <answer9> ( y - <answer10>) + <answer11> ( z - <answer12>) = 0,\\]" +
                       $"что после приведения подобных даёт:" +
                       $"\\[" +
                       $"<answer13>x + <answer14>y + <answer15>z + (<answer16>) = 0." +
                       $"\\]"
            };

            return test;
        }

        public int CheckAnswer(int randomSeed, Dictionary<string, string> answers)
        {
            CreateTest(randomSeed); // Ensure answers are initialized
            int total = 0;

            if (answers.TryGetValue("answer1", out var ans1) && ans1 == answer4.ToString()) total++;
            if (answers.TryGetValue("answer2", out var ans2) && ans2 == answer5.ToString()) total++;
            if (answers.TryGetValue("answer3", out var ans3) && ans3 == answer6.ToString()) total++;
            if (answers.TryGetValue("answer4", out var ans4) && ans4 == answer1.ToString()) total++;
            if (answers.TryGetValue("answer5", out var ans5) && ans5 == answer2.ToString()) total++;
            if (answers.TryGetValue("answer6", out var ans6) && ans6 == answer3.ToString()) total++;
            if (answers.TryGetValue("answer7", out var ans7) && ans7 == answer4.ToString()) total++;
            if (answers.TryGetValue("answer8", out var ans8) && ans8 == answer1.ToString()) total++;
            if (answers.TryGetValue("answer9", out var ans9) && ans9 == answer5.ToString()) total++;
            if (answers.TryGetValue("answer10", out var ans10) && ans10 == answer2.ToString()) total++;
            if (answers.TryGetValue("answer11", out var ans11) && ans11 == answer6.ToString()) total++;
            if (answers.TryGetValue("answer12", out var ans12) && ans12 == answer3.ToString()) total++;
            if (answers.TryGetValue("answer13", out var ans13) && ans13 == answer4.ToString()) total++;
            if (answers.TryGetValue("answer14", out var ans14) && ans14 == answer5.ToString()) total++;
            if (answers.TryGetValue("answer15", out var ans15) && ans15 == answer6.ToString()) total++;
            if (answers.TryGetValue("answer16", out var ans16) && ans16 == (-(answer4 * answer1 + answer5 * answer2 + answer6 * answer3)).ToString()) total++;

            return total;
        }

        public string Text { get; set; }
        public string[] CheckBoxes { get; set; }
        public List<Image> Pictures { get; set; } = new List<Image>();
    }
}
