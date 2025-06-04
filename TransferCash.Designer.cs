
using System.Drawing;
using System.Windows.Forms;

namespace BankApp
{
    partial class TransferCash
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TransferCash));
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.BackBtn = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.AcceptTransfer = new System.Windows.Forms.Button();
            this.DescriptionTransfer = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.BalanceAmount = new System.Windows.Forms.NumericUpDown();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.ClaimKontoBox = new System.Windows.Forms.ComboBox();
            this.SendKontoBox = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BalanceAmount)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.panel1.Controls.Add(this.textBox4);
            this.panel1.Controls.Add(this.BackBtn);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.AcceptTransfer);
            this.panel1.Controls.Add(this.DescriptionTransfer);
            this.panel1.Controls.Add(this.textBox3);
            this.panel1.Controls.Add(this.BalanceAmount);
            this.panel1.Controls.Add(this.textBox2);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.ClaimKontoBox);
            this.panel1.Controls.Add(this.SendKontoBox);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(543, 400);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // textBox4
            // 
            this.textBox4.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox4.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.textBox4.Location = new System.Drawing.Point(10, 257);
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.Size = new System.Drawing.Size(302, 24);
            this.textBox4.TabIndex = 10;
            this.textBox4.Text = "Dodaj tytul przelewu";
            // 
            // BackBtn
            // 
            this.BackBtn.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BackBtn.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.BackBtn.Location = new System.Drawing.Point(411, 9);
            this.BackBtn.Name = "BackBtn";
            this.BackBtn.Size = new System.Drawing.Size(115, 28);
            this.BackBtn.TabIndex = 9;
            this.BackBtn.Text = "Wstecz";
            this.BackBtn.UseVisualStyleBackColor = false;
            this.BackBtn.Click += new System.EventHandler(this.BackBtn_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(339, 116);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(155, 135);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // AcceptTransfer
            // 
            this.AcceptTransfer.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.AcceptTransfer.Font = new System.Drawing.Font("Segoe UI Semibold", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.AcceptTransfer.Location = new System.Drawing.Point(167, 334);
            this.AcceptTransfer.Name = "AcceptTransfer";
            this.AcceptTransfer.Size = new System.Drawing.Size(212, 41);
            this.AcceptTransfer.TabIndex = 7;
            this.AcceptTransfer.Text = "Potwierdz transfer srodkow";
            this.AcceptTransfer.UseVisualStyleBackColor = false;
            this.AcceptTransfer.Click += new System.EventHandler(this.AcceptTransfer_Click);
            // 
            // DescriptionTransfer
            // 
            this.DescriptionTransfer.Location = new System.Drawing.Point(8, 285);
            this.DescriptionTransfer.Name = "DescriptionTransfer";
            this.DescriptionTransfer.Size = new System.Drawing.Size(243, 20);
            this.DescriptionTransfer.TabIndex = 6;
            // 
            // textBox3
            // 
            this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox3.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.textBox3.Location = new System.Drawing.Point(10, 181);
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(302, 24);
            this.textBox3.TabIndex = 5;
            this.textBox3.Text = "Wpisz kwote przelewu";
            // 
            // BalanceAmount
            // 
            this.BalanceAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.BalanceAmount.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.BalanceAmount.Location = new System.Drawing.Point(10, 207);
            this.BalanceAmount.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.BalanceAmount.Name = "BalanceAmount";
            this.BalanceAmount.Size = new System.Drawing.Size(246, 29);
            this.BalanceAmount.TabIndex = 4;
            this.BalanceAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox2
            // 
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.textBox2.Location = new System.Drawing.Point(10, 117);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(302, 24);
            this.textBox2.TabIndex = 3;
            this.textBox2.Text = "Wybór konta otrzymujacego srodki:";
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.textBox1.Location = new System.Drawing.Point(10, 54);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(302, 24);
            this.textBox1.TabIndex = 2;
            this.textBox1.Text = "Wybór konta przekazujacego srodki:";
            // 
            // ClaimKontoBox
            // 
            this.ClaimKontoBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ClaimKontoBox.FormattingEnabled = true;
            this.ClaimKontoBox.Location = new System.Drawing.Point(10, 143);
            this.ClaimKontoBox.Name = "ClaimKontoBox";
            this.ClaimKontoBox.Size = new System.Drawing.Size(247, 21);
            this.ClaimKontoBox.TabIndex = 1;
            this.ClaimKontoBox.SelectedIndexChanged += new System.EventHandler(this.ClaimKontoBox_SelectedIndexChanged);
            // 
            // SendKontoBox
            // 
            this.SendKontoBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SendKontoBox.FormattingEnabled = true;
            this.SendKontoBox.Location = new System.Drawing.Point(10, 79);
            this.SendKontoBox.Name = "SendKontoBox";
            this.SendKontoBox.Size = new System.Drawing.Size(247, 21);
            this.SendKontoBox.TabIndex = 0;
            // 
            // TransferCash
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(543, 400);
            this.Controls.Add(this.panel1);
            this.Name = "TransferCash";
            this.Text = "Form3";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BalanceAmount)).EndInit();
            this.ResumeLayout(false);

        }



        #endregion

        private Panel panel1;
        private ComboBox SendKontoBox;
        private TextBox textBox2;
        private TextBox textBox1;
        private ComboBox ClaimKontoBox;
        private NumericUpDown BalanceAmount;
        private Button AcceptTransfer;
        private TextBox DescriptionTransfer;
        private PictureBox pictureBox1;
        private Button BackBtn;
        private TextBox textBox4;
        private TextBox textBox3;
    }
}