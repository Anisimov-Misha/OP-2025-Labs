using System;
using System.Drawing;
using System.Windows.Forms;

namespace HermiteCurveApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonDraw_Click(object sender, EventArgs e)
        {
            // Зчитування значень з текстбоксів
            float x1 = float.Parse(textBoxX1.Text);
            float y1 = float.Parse(textBoxY1.Text);
            float x2 = float.Parse(textBoxX2.Text);
            float y2 = float.Parse(textBoxY2.Text);
            float vx1 = float.Parse(textBoxVx1.Text);
            float vy1 = float.Parse(textBoxVy1.Text);
            float vx2 = float.Parse(textBoxVx2.Text);
            float vy2 = float.Parse(textBoxVy2.Text);

            // Створення точок
            PointF P1 = new PointF(x1, y1);
            PointF P2 = new PointF(x2, y2);
            PointF V1 = new PointF(vx1, vy1);
            PointF V2 = new PointF(vx2, vy2);

            // Малювання
            Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Graphics g = Graphics.FromImage(bmp);
            g.Clear(Color.White);

            Pen pen = new Pen(Color.Blue, 2);

            PointF prev = Hermite(0, P1, P2, V1, V2);
            for (float t = 0.01f; t <= 1.0f; t += 0.01f)
            {
                PointF curr = Hermite(t, P1, P2, V1, V2);
                g.DrawLine(pen, prev, curr);
                prev = curr;
            }

            pictureBox1.Image = bmp;
        }

        private PointF Hermite(float t, PointF P1, PointF P2, PointF V1, PointF V2)
        {
            float h1 = 2 * t * t * t - 3 * t * t + 1;
            float h2 = -2 * t * t * t + 3 * t * t;
            float h3 = t * t * t - 2 * t * t + t;
            float h4 = t * t * t - t * t;

            float x = h1 * P1.X + h2 * P2.X + h3 * V1.X + h4 * V2.X;
            float y = h1 * P1.Y + h2 * P2.Y + h3 * V1.Y + h4 * V2.Y;

            return new PointF(x, y);
        }
    }
}
