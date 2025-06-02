namespace ComputerStoreApp
{
    partial class AddForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.TextBox textBoxCPU;
        private System.Windows.Forms.TextBox textBoxFreq;
        private System.Windows.Forms.TextBox textBoxRAM;
        private System.Windows.Forms.TextBox textBoxHDD;
        private System.Windows.Forms.TextBox textBoxGPU;
        private System.Windows.Forms.TextBox textBoxSound;
        private System.Windows.Forms.Button buttonSave;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        // Оголошення Labelів у partial class AddForm (перед InitializeComponent)
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label labelCPU;
        private System.Windows.Forms.Label labelFreq;
        private System.Windows.Forms.Label labelRAM;
        private System.Windows.Forms.Label labelHDD;
        private System.Windows.Forms.Label labelGPU;
        private System.Windows.Forms.Label labelSound;


        private void InitializeComponent()
        {
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.textBoxCPU = new System.Windows.Forms.TextBox();
            this.textBoxFreq = new System.Windows.Forms.TextBox();
            this.textBoxRAM = new System.Windows.Forms.TextBox();
            this.textBoxHDD = new System.Windows.Forms.TextBox();
            this.textBoxGPU = new System.Windows.Forms.TextBox();
            this.textBoxSound = new System.Windows.Forms.TextBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.labelName = new System.Windows.Forms.Label();
            this.labelCPU = new System.Windows.Forms.Label();
            this.labelFreq = new System.Windows.Forms.Label();
            this.labelRAM = new System.Windows.Forms.Label();
            this.labelHDD = new System.Windows.Forms.Label();
            this.labelGPU = new System.Windows.Forms.Label();
            this.labelSound = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(150, 20);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(200, 22);
            this.textBoxName.TabIndex = 0;
            // 
            // textBoxCPU
            // 
            this.textBoxCPU.Location = new System.Drawing.Point(150, 50);
            this.textBoxCPU.Name = "textBoxCPU";
            this.textBoxCPU.Size = new System.Drawing.Size(200, 22);
            this.textBoxCPU.TabIndex = 1;
            // 
            // textBoxFreq
            // 
            this.textBoxFreq.Location = new System.Drawing.Point(150, 80);
            this.textBoxFreq.Name = "textBoxFreq";
            this.textBoxFreq.Size = new System.Drawing.Size(200, 22);
            this.textBoxFreq.TabIndex = 2;
            // 
            // textBoxRAM
            // 
            this.textBoxRAM.Location = new System.Drawing.Point(150, 110);
            this.textBoxRAM.Name = "textBoxRAM";
            this.textBoxRAM.Size = new System.Drawing.Size(200, 22);
            this.textBoxRAM.TabIndex = 3;
            // 
            // textBoxHDD
            // 
            this.textBoxHDD.Location = new System.Drawing.Point(150, 140);
            this.textBoxHDD.Name = "textBoxHDD";
            this.textBoxHDD.Size = new System.Drawing.Size(200, 22);
            this.textBoxHDD.TabIndex = 4;
            // 
            // textBoxGPU
            // 
            this.textBoxGPU.Location = new System.Drawing.Point(150, 170);
            this.textBoxGPU.Name = "textBoxGPU";
            this.textBoxGPU.Size = new System.Drawing.Size(200, 22);
            this.textBoxGPU.TabIndex = 5;
            // 
            // textBoxSound
            // 
            this.textBoxSound.Location = new System.Drawing.Point(150, 200);
            this.textBoxSound.Name = "textBoxSound";
            this.textBoxSound.Size = new System.Drawing.Size(200, 22);
            this.textBoxSound.TabIndex = 6;
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(150, 240);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(100, 30);
            this.buttonSave.TabIndex = 7;
            this.buttonSave.Text = "Зберегти";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(20, 23);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(52, 17);
            this.labelName.TabIndex = 8;
            this.labelName.Text = "Назва:";
            // 
            // labelCPU
            // 
            this.labelCPU.AutoSize = true;
            this.labelCPU.Location = new System.Drawing.Point(20, 53);
            this.labelCPU.Name = "labelCPU";
            this.labelCPU.Size = new System.Drawing.Size(77, 17);
            this.labelCPU.TabIndex = 9;
            this.labelCPU.Text = "Процесор:";
            // 
            // labelFreq
            // 
            this.labelFreq.AutoSize = true;
            this.labelFreq.Location = new System.Drawing.Point(20, 83);
            this.labelFreq.Name = "labelFreq";
            this.labelFreq.Size = new System.Drawing.Size(105, 17);
            this.labelFreq.TabIndex = 10;
            this.labelFreq.Text = "Частота (ГГц):";
            // 
            // labelRAM
            // 
            this.labelRAM.AutoSize = true;
            this.labelRAM.Location = new System.Drawing.Point(20, 113);
            this.labelRAM.Name = "labelRAM";
            this.labelRAM.Size = new System.Drawing.Size(73, 17);
            this.labelRAM.TabIndex = 11;
            this.labelRAM.Text = "ОЗП (ГБ):";
            // 
            // labelHDD
            // 
            this.labelHDD.AutoSize = true;
            this.labelHDD.Location = new System.Drawing.Point(20, 143);
            this.labelHDD.Name = "labelHDD";
            this.labelHDD.Size = new System.Drawing.Size(112, 17);
            this.labelHDD.TabIndex = 12;
            this.labelHDD.Text = "Жорсткий диск:";
            // 
            // labelGPU
            // 
            this.labelGPU.AutoSize = true;
            this.labelGPU.Location = new System.Drawing.Point(20, 173);
            this.labelGPU.Name = "labelGPU";
            this.labelGPU.Size = new System.Drawing.Size(86, 17);
            this.labelGPU.TabIndex = 13;
            this.labelGPU.Text = "Відеокарта:";
            // 
            // labelSound
            // 
            this.labelSound.AutoSize = true;
            this.labelSound.Location = new System.Drawing.Point(20, 203);
            this.labelSound.Name = "labelSound";
            this.labelSound.Size = new System.Drawing.Size(107, 17);
            this.labelSound.TabIndex = 14;
            this.labelSound.Text = "Звукова карта:";
            // 
            // AddForm
            // 
            this.ClientSize = new System.Drawing.Size(400, 300);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.textBoxCPU);
            this.Controls.Add(this.textBoxFreq);
            this.Controls.Add(this.textBoxRAM);
            this.Controls.Add(this.textBoxHDD);
            this.Controls.Add(this.textBoxGPU);
            this.Controls.Add(this.textBoxSound);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.labelCPU);
            this.Controls.Add(this.labelFreq);
            this.Controls.Add(this.labelRAM);
            this.Controls.Add(this.labelHDD);
            this.Controls.Add(this.labelGPU);
            this.Controls.Add(this.labelSound);
            this.Name = "AddForm";
            this.Text = "Додавання комп\'ютера";
            this.Load += new System.EventHandler(this.AddForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
