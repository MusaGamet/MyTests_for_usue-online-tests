using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using Test_Wrapper;

namespace usue_online_tests.Tests.List
{
    public class Vector : ITestCreator, ITest, ITimeLimit
    {
        public int TestID { get; set; }
        public string Name { get; } = "Аналитическая геометрия11";
        public string Description { get; } = "Упражнение по аналитической геометрии";

        public class Data
        {
            public string[] arr { get; set; } = { "6", "9" };
            public string[] ans { get; set; } = { "-12", "27" };
        };

        public ITest CreateTest(int randomSeed)
        {
            Random random = new Random(randomSeed);
            Data data = new Data();

            int num = random.Next(2);

            ITest result = new Vector();

            // Создаем изображение
            Bitmap img = new Bitmap(510, 510);
            Graphics graphics = Graphics.FromImage(img);
            graphics.Clear(Color.White);

            // Рисуем вектор c с стрелкой
            AdjustableArrowCap arrowCap = new AdjustableArrowCap(5, 5);
            Pen arrowPen = new Pen(Color.Black, 3);
            arrowPen.CustomEndCap = arrowCap;
            graphics.DrawLine(arrowPen, 250, 150, 150, 75);
            //graphics.DrawLine(arrowPen, 250, 150, 400, 100);

            // Рисуем вектор b с кружочками и стрелкой
            float startX = 250; // Начальная точка вектора b
            float startY = 150;
            float endX = 350; // Конечная точка вектора b
            float endY = 450;

            // Рассчитываем длину вектора b
            float lengthB = (float)Math.Sqrt((endX - startX) * (endX - startX) + (endY - startY) * (endY - startY));

            // Рисуем вектор b
            graphics.DrawLine(new Pen(Color.Black, 3), startX, startY, endX, endY);
            graphics.DrawString($"b", new Font("Arial", 10), Brushes.Black, new PointF(360, 450));

            // Рисуем кружочки на векторе b
            float intervalB = lengthB / 3; // Разделим на 3, чтобы получить 3 участка
            for (int i = 1; i < 3; i++)
            {
                float x = startX + (endX - startX) * i / 3;
                float y = startY + (endY - startY) * i / 3;
                graphics.FillEllipse(Brushes.Black, x - 3, y - 3, 7, 7); // Рисуем кружочек
            }

            // Рисуем стрелку на векторе b
            AdjustableArrowCap bigArrow = new AdjustableArrowCap(5, 5, true);
            arrowPen.CustomEndCap = bigArrow;
            graphics.DrawLine(arrowPen, startX, startY, endX, endY);

            // Рисуем подписи к векторам
            graphics.DrawString($"c", new Font("Arial", 10), Brushes.Black, new PointF(150, 50));

            // Рисуем вектор противоположный вектору b
            Pen dashedPen = new Pen(Color.Brown, 2);
            dashedPen.DashStyle = DashStyle.Dash;
            graphics.DrawLine(dashedPen, 250, 150, 215, 50);

            // Рисуем штрих пунктиром параллельный вектору b
            Pen Proek = new Pen(Color.Brown, 2);
            dashedPen.DashStyle = DashStyle.Dash;
            graphics.DrawLine(dashedPen, 150, 75, 215, 50);

            result.Pictures.Add(img);
            result.Text = $"Известно, что \\(\\overline{{|b|}}\\) = {data.arr[num]} и опущен перпендикуляр из конца \\(\\overline{{c}}\\) на \\(\\overline{{b}}\\). Знаками отрезок \\(\\overline{{b}}\\) разделен на" +
                $"равные части. Тогда для скалярного произведения (\\(\\overline{{b}}\\), \\(\\overline{{c}}\\)) = \\(<ans:5>\\) .";

            return result;
        }

        public int CheckAnswer(int randomSeed, Dictionary<string, string> answers)
        {
            int total = 0;

            Data data = new Data();
            Random random = new Random(randomSeed);
            int num = random.Next(2);
            string ans = data.ans[num];
            try
            {
                if (answers["ans"] == ans.ToString()) total++;

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