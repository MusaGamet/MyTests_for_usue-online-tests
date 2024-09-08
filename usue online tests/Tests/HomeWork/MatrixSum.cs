using System;
using System.Collections.Generic;
using System.Drawing;
using Test_Wrapper;

namespace usue_online_tests.Tests.List
{
    public class MatrixSum001 : ITestCreator, ITest, ITimeLimit, IHidden, ITestGroup
    {
        public int TestID { get; set; }
        public string GroupName { get; set; }= "Matrix";
        public string Name { get; } = "Вычисление суммы матриц";
        public string Description { get; } = "";

        public class Data
        {

            public string LetterR = "ABCDFGHKMPRSUVWXYZ";
            public int[] answA = new int[4];
            public int[] MatrA = new int[4];
            public int[] MatrB = new int[4];
            public int[] MatrC = new int[4];
            public int iA, jA, iB, jB, iCx, jCx, iCy, jCy, Vvv;
            public string ElemMatrA = "";
            public string ElemMatrB = "";
            public string ElemMatrC = "";
            public string MCa = "";
            public string MCb = "";
            public string MCc = "";
            public string IndAa = "";
            public string IndAb = "";
            public string IndAc = "";
            public string IndBa = "";
            public string IndBb = "";
            public string IndBc = "";
            public string IndexC = "";
            public string MatrEqA = "";
            public int alpha;
            public int beta;

            public Data(Random random)
            {
                CreateMatrixes(random);
            }
            public void CreateMatrixes(Random random)
            {
                int[] Numbers = new int[40];
                for (int i = 0; i < 20; i++)
                {
                    Numbers[2*i] = -i-1;
                    Numbers[2*i+1] = i+1;
                }
                Vvv = random.Next(38);
                MatrA[0] = Numbers[Vvv];
                Numbers[Vvv] = Numbers[39];
                Vvv = random.Next(37);
                MatrA[1] = Numbers[Vvv];
                Numbers[Vvv] = Numbers[38];
                Vvv = random.Next(36);
                MatrA[2] = Numbers[Vvv];
                Numbers[Vvv] = Numbers[37];
                Vvv = random.Next(35);
                MatrA[3] = Numbers[Vvv];
                Numbers[Vvv] = Numbers[36];
                Vvv = random.Next(34);
                MatrB[0] = Numbers[Vvv];
                Numbers[Vvv] = Numbers[35];
                Vvv = random.Next(33);
                MatrB[1] = Numbers[Vvv];
                Numbers[Vvv] = Numbers[34];
                Vvv = random.Next(32);
                MatrB[2] = Numbers[Vvv];
                Numbers[Vvv] = Numbers[33];
                Vvv = random.Next(31);
                MatrB[3] = Numbers[Vvv];
                Numbers[Vvv] = Numbers[32];
                for (int i = 0; i < 4; i++)
                {
                   MatrC[i] = MatrA[i] + MatrB[i];
                }
              
                answA[0] = MatrC[0];
                answA[1] = MatrC[1];
                answA[2] = MatrC[2];
                answA[3] = MatrC[3];
            }
        }
        public ITest CreateTest(int randomSeed)
        {
            ITest result = new MatrixSum001();

            Random random = new Random(randomSeed);
            Data data = new Data(random);
                        
            result.Text =                        
            $"\\(\\left(\\begin{{array}}{{cc}} {data.MatrA[0]} & {data.MatrA[1]}\\\\ {data.MatrA[2]} & {data.MatrA[3]}\\\\ \\end{{array}}\\right)\\) + " + 
            $"\\(\\left(\\begin{{array}}{{cc}} {data.MatrB[0]} & {data.MatrB[1]}\\\\ {data.MatrB[2]} & {data.MatrB[3]}\\\\ \\end{{array}}\\right)\\) = " + 
            $"\\(\\left(\\begin{{array}}{{cc}} <ans[0]:5>      & <ans[1]:5>     \\\\ <ans[2]:5>      & <ans[3]:5>     \\\\ \\end{{array}}\\right)\\)\r\n";

            return result;
        }

        public int CheckAnswer(int randomSeed, Dictionary<string, string> answers)
        {
            int total = 0;

            Random random = new Random(randomSeed);
            Data data = new Data(random);
               
            try
            {
                for (int i = 0; i < 4; i++)
                {
                    if (answers["ans["+i+"]"] == data.answA[i].ToString()) total++;
                }
            }
            catch
            {

            }

            return total;
        }

        public string Text { get; set; }
        public string[] CheckBoxes { get; set; }
        public List<Image> Pictures { get; set; }
        public int TimeLimitSeconds { get; set; } = 120;
        public bool IsHidden { get; set; } = false;
    }
}