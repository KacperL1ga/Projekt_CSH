namespace BankApp
{
    partial class SavingKonto
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SavingKonto));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.accnumerBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.RandomNumber = new System.Windows.Forms.Button();
            this.MakeSaveAccBtn = new System.Windows.Forms.Button();
            this.BackBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 45);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(178, 159);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBox1.Location = new System.Drawing.Point(196, 128);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(347, 76);
            this.textBox1.TabIndex = 17;
            this.textBox1.Text = "Wygeneruj dane do zalozenia konta oszczednosciowego";
            // 
            // accnumerBox
            // 
            this.accnumerBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.accnumerBox.Location = new System.Drawing.Point(170, 283);
            this.accnumerBox.Name = "accnumerBox";
            this.accnumerBox.Size = new System.Drawing.Size(218, 26);
            this.accnumerBox.TabIndex = 17;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(167, 267);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Numer konta";
            // 
            // RandomNumber
            // 
            this.RandomNumber.BackColor = System.Drawing.SystemColors.ControlLight;
            this.RandomNumber.Location = new System.Drawing.Point(228, 315);
            this.RandomNumber.Name = "RandomNumber";
            this.RandomNumber.Size = new System.Drawing.Size(97, 26);
            this.RandomNumber.TabIndex = 17;
            this.RandomNumber.Text = "Losuj";
            this.RandomNumber.UseVisualStyleBackColor = false;
            this.RandomNumber.Click += new System.EventHandler(this.RandomNumber_Click);
            // 
            // MakeSaveAccBtn
            // 
            this.MakeSaveAccBtn.BackColor = System.Drawing.SystemColors.ControlLight;
            this.MakeSaveAccBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.MakeSaveAccBtn.Location = new System.Drawing.Point(170, 381);
            this.MakeSaveAccBtn.Name = "MakeSaveAccBtn";
            this.MakeSaveAccBtn.Size = new System.Drawing.Size(218, 38);
            this.MakeSaveAccBtn.TabIndex = 17;
            this.MakeSaveAccBtn.Text = "Zaloz konto";
            this.MakeSaveAccBtn.UseVisualStyleBackColor = false;
            this.MakeSaveAccBtn.Click += new System.EventHandler(this.MakeSaveAccBtn_Click);
            // 
            // BackBtn
            // 
            this.BackBtn.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.BackBtn.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.BackBtn.Location = new System.Drawing.Point(426, 12);
            this.BackBtn.Name = "BackBtn";
            this.BackBtn.Size = new System.Drawing.Size(117, 36);
            this.BackBtn.TabIndex = 17;
            this.BackBtn.Text = "Wróc";
            this.BackBtn.UseVisualStyleBackColor = false;
            this.BackBtn.Click += new System.EventHandler(this.BackBtn_Click);
            // 
            // SavingKonto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(555, 450);
            this.Controls.Add(this.BackBtn);
            this.Controls.Add(this.MakeSaveAccBtn);
            this.Controls.Add(this.RandomNumber);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.accnumerBox);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "SavingKonto";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.SavingKonto_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox accnumerBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button RandomNumber;
        private System.Windows.Forms.Button MakeSaveAccBtn;
        private System.Windows.Forms.Button BackBtn;
    }
}