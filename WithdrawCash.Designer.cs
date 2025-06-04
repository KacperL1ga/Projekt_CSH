using System.Drawing;
using System.Windows.Forms;

namespace BankApp
{
    partial class WithdrawCash
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WithdrawCash));
            this.BackBtn = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.AcceptTransfer = new System.Windows.Forms.Button();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.BalanceAmount = new System.Windows.Forms.NumericUpDown();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SendKontoBox = new System.Windows.Forms.ComboBox();
            this.claimlbl = new System.Windows.Forms.TextBox();
            this.ClaimKontoBox = new System.Windows.Forms.ComboBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.TitleOption = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BalanceAmount)).BeginInit();
            this.SuspendLayout();
            // 
            // BackBtn
            // 
            this.BackBtn.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BackBtn.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.BackBtn.Location = new System.Drawing.Point(418, 10);
            this.BackBtn.Name = "BackBtn";
            this.BackBtn.Size = new System.Drawing.Size(115, 28);
            this.BackBtn.TabIndex = 23;
            this.BackBtn.Text = "Wstecz";
            this.BackBtn.UseVisualStyleBackColor = false;
            this.BackBtn.Click += new System.EventHandler(this.BackBtn_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(367, 121);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(155, 135);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 22;
            this.pictureBox2.TabStop = false;
            // 
            // AcceptTransfer
            // 
            this.AcceptTransfer.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.AcceptTransfer.Font = new System.Drawing.Font("Segoe UI Semibold", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.AcceptTransfer.Location = new System.Drawing.Point(176, 334);
            this.AcceptTransfer.Name = "AcceptTransfer";
            this.AcceptTransfer.Size = new System.Drawing.Size(212, 44);
            this.AcceptTransfer.TabIndex = 21;
            this.AcceptTransfer.Text = "Potwierdz wyplate srodkow";
            this.AcceptTransfer.UseVisualStyleBackColor = false;
            this.AcceptTransfer.Click += new System.EventHandler(this.AcceptTransfer_Click);
            // 
            // textBox4
            // 
            this.textBox4.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox4.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.textBox4.Location = new System.Drawing.Point(9, 183);
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.Size = new System.Drawing.Size(277, 24);
            this.textBox4.TabIndex = 19;
            this.textBox4.Text = "Wpisz ilosc wyplacanych srodkow";
            // 
            // BalanceAmount
            // 
            this.BalanceAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.BalanceAmount.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.BalanceAmount.Location = new System.Drawing.Point(10, 213);
            this.BalanceAmount.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.BalanceAmount.Name = "BalanceAmount";
            this.BalanceAmount.Size = new System.Drawing.Size(276, 29);
            this.BalanceAmount.TabIndex = 18;
            this.BalanceAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.textBox1.Location = new System.Drawing.Point(10, 48);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(276, 24);
            this.textBox1.TabIndex = 17;
            this.textBox1.Text = "Wybór konta do wyplaty srodki:";
            // 
            // SendKontoBox
            // 
            this.SendKontoBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SendKontoBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.SendKontoBox.FormattingEnabled = true;
            this.SendKontoBox.Location = new System.Drawing.Point(10, 74);
            this.SendKontoBox.Name = "SendKontoBox";
            this.SendKontoBox.Size = new System.Drawing.Size(276, 28);
            this.SendKontoBox.TabIndex = 16;
            this.SendKontoBox.SelectedIndexChanged += new System.EventHandler(this.SendKontoBox_SelectedIndexChanged);
            // 
            // claimlbl
            // 
            this.claimlbl.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.claimlbl.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.claimlbl.Location = new System.Drawing.Point(10, 121);
            this.claimlbl.Name = "claimlbl";
            this.claimlbl.ReadOnly = true;
            this.claimlbl.Size = new System.Drawing.Size(276, 24);
            this.claimlbl.TabIndex = 25;
            this.claimlbl.Text = "Konta do wplaty srodki:";
            this.claimlbl.Visible = false;
            // 
            // ClaimKontoBox
            // 
            this.ClaimKontoBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ClaimKontoBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ClaimKontoBox.FormattingEnabled = true;
            this.ClaimKontoBox.Location = new System.Drawing.Point(10, 147);
            this.ClaimKontoBox.Name = "ClaimKontoBox";
            this.ClaimKontoBox.Size = new System.Drawing.Size(276, 28);
            this.ClaimKontoBox.TabIndex = 24;
            this.ClaimKontoBox.Visible = false;
            this.ClaimKontoBox.SelectedIndexChanged += new System.EventHandler(this.ClaimKontoBox_SelectedIndexChanged);
            // 
            // textBox3
            // 
            this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox3.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.textBox3.Location = new System.Drawing.Point(9, 258);
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(277, 24);
            this.textBox3.TabIndex = 26;
            this.textBox3.Text = "Rodzaj transakcji";
            // 
            // TitleOption
            // 
            this.TitleOption.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TitleOption.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.TitleOption.FormattingEnabled = true;
            this.TitleOption.Location = new System.Drawing.Point(9, 288);
            this.TitleOption.Name = "TitleOption";
            this.TitleOption.Size = new System.Drawing.Size(276, 28);
            this.TitleOption.TabIndex = 27;
            this.TitleOption.SelectedIndexChanged += new System.EventHandler(this.TitleOption_SelectedIndexChanged);
            // 
            // WithdrawCash
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(543, 400);
            this.Controls.Add(this.TitleOption);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.claimlbl);
            this.Controls.Add(this.ClaimKontoBox);
            this.Controls.Add(this.BackBtn);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.AcceptTransfer);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.BalanceAmount);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.SendKontoBox);
            this.Name = "WithdrawCash";
            this.Text = "Form5";
            this.Load += new System.EventHandler(this.WithdrawCash_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BalanceAmount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button BackBtn;
        private PictureBox pictureBox2;
        private Button AcceptTransfer;
        private TextBox textBox4;
        private NumericUpDown BalanceAmount;
        private TextBox textBox1;
        private ComboBox SendKontoBox;
        private TextBox claimlbl;
        private ComboBox ClaimKontoBox;
        private TextBox textBox3;
        private ComboBox TitleOption;
    }
}