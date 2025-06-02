using System;
using System.Drawing;
using System.Windows.Forms;

namespace DandelionFractalApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void DrawDandelion(Graphics g, PointF p1, PointF p2, int order)
        {
            if (order == 0)
            {
                g.DrawLine(Pens.Black, p1, p2);
            }
            else
            {
                // Малюємо лінію
                g.DrawLine(Pens.Black, p1, p2);

                // Визначаємо точку середини
                float midX = (p1.X + p2.X) / 2;
                float midY = (p1.Y + p2.Y) / 2;
                PointF mid = new PointF(midX, midY);

                // Відстань між точками
                float dx = p2.X - p1.X;
                float dy = p2.Y - p1.Y;

                // Кут нахилу лінії
                double angle = Math.Atan2(dy, dx);

                // Довжина "променя"
                float length = (float)Math.Sqrt(dx * dx + dy * dy) / 2;

                // Кут розгалуження (наприклад, 45 градусів)
                double branchAngle = Math.PI / 4;

                // Кінцева точка верхнього "променя"
                PointF branch1 = new PointF(
                    mid.X + length * (float)Math.Cos(angle + branchAngle),
                    mid.Y + length * (float)Math.Sin(angle + branchAngle)
                );

                // Кінцева точка нижнього "променя"
                PointF branch2 = new PointF(
                    mid.X + length * (float)Math.Cos(angle - branchAngle),
                    mid.Y + length * (float)Math.Sin(angle - branchAngle)
                );

                // Рекурсивно малюємо відрізки "променів"
                DrawDandelion(g, mid, branch1, order - 1);
                DrawDandelion(g, mid, branch2, order - 1);
            }
        }

        private void buttonDraw_Click(object sender, EventArgs e)
        {
            int x1, y1, x2, y2, order;

            if (!int.TryParse(textBoxX1.Text, out x1) ||
                !int.TryParse(textBoxY1.Text, out y1) ||
                !int.TryParse(textBoxX2.Text, out x2) ||
                !int.TryParse(textBoxY2.Text, out y2) ||
                !int.TryParse(textBoxOrder.Text, out order))
            {
                MessageBox.Show("Будь ласка, введіть коректні числові значення.");
                return;
            }

            if (order < 0 || order > 10)
            {
                MessageBox.Show("Порядок має бути від 0 до 10.");
                return;
            }

            Bitmap bmp = new Bitmap(pictureBox.Width, pictureBox.Height);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.White);
                DrawDandelion(g, new PointF(x1, y1), new PointF(x2, y2), order);
            }
            pictureBox.Image = bmp;
        }
    }
}
