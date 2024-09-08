using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using Test_Wrapper;

namespace usue_online_tests.Tests.List
{
    public class Vector004 : ITestCreator, ITest
    {
        private int targetNumber;
        private int targetNumberInverse;

        public int TestID { get; set; }
        public string Name { get; } = "Векторная аглебра 004";
        public string Description { get; } = "Упражнение по векторной алгебре";

        public ITest CreateTest(int randomSeed)
        {
            Random random = new Random(randomSeed);
            ITest test = new Vector004();

            List<(int, int)> ranges = new List<(int, int)> {
                (141, 147),
                (159, 166),
                (176, 183)
            };

            (int startRange, int endRange) = ranges[random.Next(ranges.Count)];
            int startV = random.Next(startRange, endRange + 1);

            int positionYV1 = (startV - 1) / 17;
            int positionXV1 = (startV - 1) % 17;

            Bitmap img = new Bitmap(510, 510);
            Graphics graphics = Graphics.FromImage(img);
            graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
            graphics.SmoothingMode = SmoothingMode.AntiAlias;

            int startX = 3;
            int startY = 16 * 30 + 7;

            int ellipseSize = 30;
            int counter = 1;
            for (int i = 0; i < 17; i++)
            {
                if (i % 2 != 0)
                {
                    for (int j = 16; j >= 0; j--)
                    {
                        DrawNumber(graphics, counter, startX + j * 30, startY - i * 30);
                        if (counter == startV)
                        {
                            int ellipseX = startX + j * 30 - ellipseSize / 2 + 12;
                            int ellipseY = startY - i * 30 - ellipseSize / 2 + 7;
                            graphics.DrawEllipse(new Pen(Color.Red, 3), ellipseX, ellipseY, ellipseSize, ellipseSize);
                        }
                        counter++;
                    }
                }
                else
                {
                    for (int j = 16; j >= 0; j--)
                    {
                        DrawNumber(graphics, counter, startX + j * 30, startY - i * 30);
                        if (counter == startV)
                        {
                            int ellipseX = startX + j * 30 - ellipseSize / 2 + 12;
                            int ellipseY = startY - positionYV1 * 30 - ellipseSize / 2 + 7;
                            graphics.DrawEllipse(new Pen(Color.Red, 3), ellipseX, ellipseY, ellipseSize, ellipseSize);
                        }
                        counter++;
                    }
                }
            }

            Pen pen = new Pen(Color.Red, 5);
            CustomLineCap bigArrow = new AdjustableArrowCap(3, 3, true);
            pen.CustomEndCap = bigArrow;

            int targetNumberX = startV % 17 + 1;
            int targetNumberY = random.Next(0, positionYV1);

            if (targetNumberX == positionXV1 && targetNumberY == positionYV1)
            {
                targetNumberX = random.Next(positionXV1 + 1, 17);
                targetNumberY = random.Next(0, positionYV1);
            }

            targetNumber = startV + (positionXV1 - targetNumberX) + 17 * (positionYV1 - targetNumberY);

            int targetNumberYInverse = targetNumberX;
            int targetNumberXInverse = targetNumberY;
            targetNumberInverse = startV - 17 * (positionXV1 - targetNumberYInverse) + (positionYV1 - targetNumberXInverse);

            graphics.DrawLine(pen, (positionXV1 * 30) + 13, (positionYV1 * 30) + 12, (targetNumberX * 30) + 13, (targetNumberY * 30) + 12);

            test.Pictures.Add(img);

            void DrawNumber(Graphics g, int number, int x, int y)
            {
                g.DrawString(number.ToString(), new Font("Arial", 10), Brushes.Black, new PointF(x, y));
            }

            string questionText = $"Если \\(\\overline{{a}}\\) отложить от точки с номером {startV}, то конец направленного отрезка будет в точке с номером" +
            $" номером \\({targetNumber}\\) \\({targetNumberInverse}\\)\\(<targetNumber>\\). Номер точки — конца направленного отрезка, отложенного в сторону-вверх от точки {startV}, ортогонального к \\(\\overline{{a}}\\) и равного по длине \\(\\overline{{a}}\\), равна \\(<targetNumberInverse>\\) ";

            test.Text = questionText;

            return test;
        }

        public int CheckAnswer(int randomSeed, Dictionary<string, string> answers)
        {
            int total = 0;


            foreach (var answer in answers)
            {
                if (answer.Key == "targetNumber" && answer.Value == targetNumber.ToString() ||
                    answer.Key == "targetNumberInverse" && answer.Value == targetNumberInverse.ToString())
                    total += 1;
            }
            if (answers.TryGetValue("targetV", out string userAnswer))
            {
                int expectedTargetV = int.Parse(userAnswer);

                if (targetNumber == expectedTargetV || targetNumberInverse == expectedTargetV)
                {
                    total++;
                }
            }

            return total;
        }

        public string Text { get; set; }
        public string[] CheckBoxes { get; set; }
        public List<Image> Pictures { get; set; } = new List<Image>();
    }
}
