namespace BankApp
{
    partial class Rejestracja
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Rejestracja));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.passwdLabel = new System.Windows.Forms.Label();
            this.loginLabel = new System.Windows.Forms.Label();
            this.NewpasswdBox = new System.Windows.Forms.TextBox();
            this.NewloginBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.accnumerBox = new System.Windows.Forms.TextBox();
            this.RandomNumber = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.RegisterButton = new System.Windows.Forms.Button();
            this.BalanceLbl = new System.Windows.Forms.Label();
            this.Balance = new System.Windows.Forms.NumericUpDown();
            this.LogOutBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Balance)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(28, 37);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(150, 125);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // passwdLabel
            // 
            this.passwdLabel.AutoSize = true;
            this.passwdLabel.Location = new System.Drawing.Point(257, 195);
            this.passwdLabel.Name = "passwdLabel";
            this.passwdLabel.Size = new System.Drawing.Size(34, 13);
            this.passwdLabel.TabIndex = 7;
            this.passwdLabel.Text = "Haslo";
            // 
            // loginLabel
            // 
            this.loginLabel.AutoSize = true;
            this.loginLabel.Location = new System.Drawing.Point(25, 195);
            this.loginLabel.Name = "loginLabel";
            this.loginLabel.Size = new System.Drawing.Size(33, 13);
            this.loginLabel.TabIndex = 6;
            this.loginLabel.Text = "Login";
            // 
            // NewpasswdBox
            // 
            this.NewpasswdBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NewpasswdBox.Location = new System.Drawing.Point(260, 211);
            this.NewpasswdBox.Name = "NewpasswdBox";
            this.NewpasswdBox.PasswordChar = '*';
            this.NewpasswdBox.Size = new System.Drawing.Size(218, 26);
            this.NewpasswdBox.TabIndex = 5;
            this.NewpasswdBox.UseSystemPasswordChar = true;
            // 
            // NewloginBox
            // 
            this.NewloginBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NewloginBox.Location = new System.Drawing.Point(28, 211);
            this.NewloginBox.Name = "NewloginBox";
            this.NewloginBox.Size = new System.Drawing.Size(218, 26);
            this.NewloginBox.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 254);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Numer konta";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // accnumerBox
            // 
            this.accnumerBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.accnumerBox.Location = new System.Drawing.Point(28, 270);
            this.accnumerBox.Name = "accnumerBox";
            this.accnumerBox.Size = new System.Drawing.Size(218, 26);
            this.accnumerBox.TabIndex = 8;
            this.accnumerBox.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // RandomNumber
            // 
            this.RandomNumber.BackColor = System.Drawing.SystemColors.ControlLight;
            this.RandomNumber.Location = new System.Drawing.Point(252, 271);
            this.RandomNumber.Name = "RandomNumber";
            this.RandomNumber.Size = new System.Drawing.Size(97, 26);
            this.RandomNumber.TabIndex = 10;
            this.RandomNumber.Text = "Losuj";
            this.RandomNumber.UseVisualStyleBackColor = false;
            this.RandomNumber.Click += new System.EventHandler(this.RandomNumber_Click);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBox1.Location = new System.Drawing.Point(184, 131);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(294, 24);
            this.textBox1.TabIndex = 11;
            this.textBox1.Text = "Podaj dane do rejestracji";
            // 
            // RegisterButton
            // 
            this.RegisterButton.BackColor = System.Drawing.SystemColors.ControlLight;
            this.RegisterButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.RegisterButton.Location = new System.Drawing.Point(184, 388);
            this.RegisterButton.Name = "RegisterButton";
            this.RegisterButton.Size = new System.Drawing.Size(218, 38);
            this.RegisterButton.TabIndex = 12;
            this.RegisterButton.Text = "Zarejestruj sie";
            this.RegisterButton.UseVisualStyleBackColor = false;
            this.RegisterButton.Click += new System.EventHandler(this.RegisterButton_Click);
            // 
            // BalanceLbl
            // 
            this.BalanceLbl.AutoSize = true;
            this.BalanceLbl.Location = new System.Drawing.Point(25, 311);
            this.BalanceLbl.Name = "BalanceLbl";
            this.BalanceLbl.Size = new System.Drawing.Size(82, 13);
            this.BalanceLbl.TabIndex = 14;
            this.BalanceLbl.Text = "Wstepna kwota";
            // 
            // Balance
            // 
            this.Balance.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Balance.Location = new System.Drawing.Point(28, 327);
            this.Balance.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.Balance.Name = "Balance";
            this.Balance.Size = new System.Drawing.Size(220, 26);
            this.Balance.TabIndex = 15;
            // 
            // LogOutBtn
            // 
            this.LogOutBtn.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.LogOutBtn.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.LogOutBtn.Location = new System.Drawing.Point(445, 12);
            this.LogOutBtn.Name = "LogOutBtn";
            this.LogOutBtn.Size = new System.Drawing.Size(117, 36);
            this.LogOutBtn.TabIndex = 16;
            this.LogOutBtn.Text = "Wróc";
            this.LogOutBtn.UseVisualStyleBackColor = false;
            this.LogOutBtn.Click += new System.EventHandler(this.LogOutBtn_Click);
            // 
            // Rejestracja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(574, 450);
            this.Controls.Add(this.LogOutBtn);
            this.Controls.Add(this.Balance);
            this.Controls.Add(this.BalanceLbl);
            this.Controls.Add(this.RegisterButton);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.RandomNumber);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.accnumerBox);
            this.Controls.Add(this.passwdLabel);
            this.Controls.Add(this.loginLabel);
            this.Controls.Add(this.NewpasswdBox);
            this.Controls.Add(this.NewloginBox);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Rejestracja";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Rejestracja_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Balance)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label passwdLabel;
        private System.Windows.Forms.Label loginLabel;
        private System.Windows.Forms.TextBox NewpasswdBox;
        private System.Windows.Forms.TextBox NewloginBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox accnumerBox;
        private System.Windows.Forms.Button RandomNumber;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button RegisterButton;
        private System.Windows.Forms.Label BalanceLbl;
        private System.Windows.Forms.NumericUpDown Balance;
        private System.Windows.Forms.Button LogOutBtn;
    }
}