namespace HermiteCurveApp
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox textBoxX1;
        private System.Windows.Forms.TextBox textBoxY1;
        private System.Windows.Forms.TextBox textBoxX2;
        private System.Windows.Forms.TextBox textBoxY2;
        private System.Windows.Forms.TextBox textBoxVx1;
        private System.Windows.Forms.TextBox textBoxVy1;
        private System.Windows.Forms.TextBox textBoxVx2;
        private System.Windows.Forms.TextBox textBoxVy2;
        private System.Windows.Forms.Button buttonDraw;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label[] labels;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.textBoxX1 = new System.Windows.Forms.TextBox();
            this.textBoxY1 = new System.Windows.Forms.TextBox();
            this.textBoxX2 = new System.Windows.Forms.TextBox();
            this.textBoxY2 = new System.Windows.Forms.TextBox();
            this.textBoxVx1 = new System.Windows.Forms.TextBox();
            this.textBoxVy1 = new System.Windows.Forms.TextBox();
            this.textBoxVx2 = new System.Windows.Forms.TextBox();
            this.textBoxVy2 = new System.Windows.Forms.TextBox();
            this.buttonDraw = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();

            this.labels = new System.Windows.Forms.Label[8];
            string[] texts = {
                "X1 (P1)", "Y1 (P1)", "X2 (P2)", "Y2 (P2)",
                "Vx1", "Vy1", "Vx2", "Vy2"
            };

            for (int i = 0; i < labels.Length; i++)
            {
                labels[i] = new System.Windows.Forms.Label();
                labels[i].Text = texts[i];
                labels[i].Location = new System.Drawing.Point(20, 20 + i * 30);
                labels[i].Size = new System.Drawing.Size(60, 20);
                this.Controls.Add(labels[i]);
            }

            // Текстбокси
            this.textBoxX1.Location = new System.Drawing.Point(90, 20);
            this.textBoxY1.Location = new System.Drawing.Point(90, 50);
            this.textBoxX2.Location = new System.Drawing.Point(90, 80);
            this.textBoxY2.Location = new System.Drawing.Point(90, 110);
            this.textBoxVx1.Location = new System.Drawing.Point(90, 140);
            this.textBoxVy1.Location = new System.Drawing.Point(90, 170);
            this.textBoxVx2.Location = new System.Drawing.Point(90, 200);
            this.textBoxVy2.Location = new System.Drawing.Point(90, 230);

            this.textBoxX1.Size = this.textBoxY1.Size = this.textBoxX2.Size = this.textBoxY2.Size =
                this.textBoxVx1.Size = this.textBoxVy1.Size = this.textBoxVx2.Size = this.textBoxVy2.Size =
                new System.Drawing.Size(100, 20);

            // Кнопка
            this.buttonDraw.Location = new System.Drawing.Point(50, 270);
            this.buttonDraw.Size = new System.Drawing.Size(100, 30);
            this.buttonDraw.Text = "Побудувати";
            this.buttonDraw.Click += new System.EventHandler(this.buttonDraw_Click);

            // PictureBox
            this.pictureBox1.Location = new System.Drawing.Point(220, 20);
            this.pictureBox1.Size = new System.Drawing.Size(500, 300);
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            // Додати все на форму
            this.Controls.Add(this.textBoxX1);
            this.Controls.Add(this.textBoxY1);
            this.Controls.Add(this.textBoxX2);
            this.Controls.Add(this.textBoxY2);
            this.Controls.Add(this.textBoxVx1);
            this.Controls.Add(this.textBoxVy1);
            this.Controls.Add(this.textBoxVx2);
            this.Controls.Add(this.textBoxVy2);
            this.Controls.Add(this.buttonDraw);
            this.Controls.Add(this.pictureBox1);

            // Властивості форми
            this.ClientSize = new System.Drawing.Size(750, 350);
            this.Name = "Form1";
            this.Text = "Крива Ерміта";
        }
    }
}
