using System.Globalization;
using System.Text;

namespace WinFormsApp1
{
    public class ScreenField
    {
        Random rand;
        int screenWidth;
        int screenHeight;
        public Point[] points;

        public ScreenField(int numberOfElements, int screenWidth, int screenHeight)
        {
            rand = new Random();
            this.screenWidth = screenWidth;
            this.screenHeight = screenHeight;

            GenerateNewField(numberOfElements);
        }

        public void GenerateNewField(int numberOfElements)
        {
            points = new Point[numberOfElements];

            for (int i = 0; i < points.Length; i++)
            {
                points[i].x = rand.Next(0, screenWidth);
                points[i].y = rand.Next(0, screenHeight);
                points[i].size = rand.Next(1, 30);

                int alpha = 20;

                if (points[i].size > 25)
                {
                    alpha = 255;
                }
                else if (points[i].size > 20)
                {
                    alpha = 150;
                }
                else if (points[i].size > 10)
                {
                    alpha = 125;
                }
                else
                {
                    alpha = 75;
                }

                int r = rand.Next(0, 100);
                int g = rand.Next(0, 100);
                int b = rand.Next(100, 255);

                points[i].color = Color.FromArgb(alpha, r, g, b);
                points[i].text = "\u2744";
            }
        }

        public void DrawField(Graphics g)
        {
            for (int i = 0; i < points.Length; i++)
            {
                Brush b = new SolidBrush(points[i].color);
                g.DrawString(points[i].text, new Font("System", points[i].size), b, points[i].x, points[i].y);
            }
        }

        public void ShiftField()
        {
            for (int i = 0; i < points.Length; i++)
            {
                if (points[i].y >= screenHeight)
                {
                    points[i].y = 0;
                }
                else
                {
                    if (points[i].size > 40)
                    {
                        points[i].y = points[i].y + 2;
                    }
                    else if (points[i].size > 20)
                    {
                        points[i].y = points[i].y + 4;
                    }
                    else if (points[i].size < 10)
                    {
                        points[i].y = points[i].y + 5;
                    }
                    else
                    {
                        points[i].y = points[i].y + 6;
                    }
                }
            }
        }
    }
}