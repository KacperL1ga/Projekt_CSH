using System.Drawing;
using System.Windows.Forms;

namespace BankApp
{
    partial class DepositCash
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DepositCash));
            this.panel1 = new System.Windows.Forms.Panel();
            this.TitleOption = new System.Windows.Forms.ComboBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.BackBtn = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.AcceptTransfer = new System.Windows.Forms.Button();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.BalanceAmount = new System.Windows.Forms.NumericUpDown();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.ClaimKontoBox = new System.Windows.Forms.ComboBox();
            this.accountBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BalanceAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.accountBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.TitleOption);
            this.panel1.Controls.Add(this.textBox2);
            this.panel1.Controls.Add(this.BackBtn);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.AcceptTransfer);
            this.panel1.Controls.Add(this.textBox4);
            this.panel1.Controls.Add(this.BalanceAmount);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.ClaimKontoBox);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(543, 400);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // TitleOption
            // 
            this.TitleOption.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TitleOption.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.TitleOption.FormattingEnabled = true;
            this.TitleOption.Location = new System.Drawing.Point(12, 266);
            this.TitleOption.Name = "TitleOption";
            this.TitleOption.Size = new System.Drawing.Size(278, 28);
            this.TitleOption.TabIndex = 28;
            this.TitleOption.SelectedIndexChanged += new System.EventHandler(this.TitleOption_SelectedIndexChanged);
            // 
            // textBox2
            // 
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.textBox2.Location = new System.Drawing.Point(12, 236);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(246, 24);
            this.textBox2.TabIndex = 16;
            this.textBox2.Text = "Tytul przelewu";
            // 
            // BackBtn
            // 
            this.BackBtn.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BackBtn.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.BackBtn.Location = new System.Drawing.Point(418, 10);
            this.BackBtn.Name = "BackBtn";
            this.BackBtn.Size = new System.Drawing.Size(115, 28);
            this.BackBtn.TabIndex = 15;
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
            this.pictureBox2.TabIndex = 14;
            this.pictureBox2.TabStop = false;
            // 
            // AcceptTransfer
            // 
            this.AcceptTransfer.AutoSize = true;
            this.AcceptTransfer.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.AcceptTransfer.Font = new System.Drawing.Font("Segoe UI Semibold", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.AcceptTransfer.Location = new System.Drawing.Point(140, 334);
            this.AcceptTransfer.Name = "AcceptTransfer";
            this.AcceptTransfer.Size = new System.Drawing.Size(271, 38);
            this.AcceptTransfer.TabIndex = 13;
            this.AcceptTransfer.Text = "Potwierdz transfer srodkow";
            this.AcceptTransfer.UseVisualStyleBackColor = false;
            this.AcceptTransfer.Click += new System.EventHandler(this.AcceptTransfer_Click);
            // 
            // textBox4
            // 
            this.textBox4.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox4.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.textBox4.Location = new System.Drawing.Point(10, 156);
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.Size = new System.Drawing.Size(246, 24);
            this.textBox4.TabIndex = 11;
            this.textBox4.Text = "Wpisz ilosc wplaconych srodkow";
            // 
            // BalanceAmount
            // 
            this.BalanceAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.BalanceAmount.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.BalanceAmount.Location = new System.Drawing.Point(10, 182);
            this.BalanceAmount.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.BalanceAmount.Name = "BalanceAmount";
            this.BalanceAmount.Size = new System.Drawing.Size(280, 29);
            this.BalanceAmount.TabIndex = 5;
            this.BalanceAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.textBox1.Location = new System.Drawing.Point(10, 57);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(280, 24);
            this.textBox1.TabIndex = 3;
            this.textBox1.Text = "Wybór konta otrzymujacego srodki:";
            // 
            // ClaimKontoBox
            // 
            this.ClaimKontoBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.accountBindingSource, "Balance", true));
            this.ClaimKontoBox.DataSource = this.accountBindingSource;
            this.ClaimKontoBox.DisplayMember = "AccountType";
            this.ClaimKontoBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ClaimKontoBox.FormattingEnabled = true;
            this.ClaimKontoBox.Location = new System.Drawing.Point(10, 83);
            this.ClaimKontoBox.Name = "ClaimKontoBox";
            this.ClaimKontoBox.Size = new System.Drawing.Size(280, 21);
            this.ClaimKontoBox.TabIndex = 1;
            this.ClaimKontoBox.ValueMember = "AccountNumber";
            // 
            // accountBindingSource
            // 
            this.accountBindingSource.DataSource = typeof(Projekt_C.Models.Account);
            // 
            // DepositCash
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(543, 400);
            this.Controls.Add(this.panel1);
            this.Name = "DepositCash";
            this.Text = "Form4";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BalanceAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.accountBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel1;
        private ComboBox ClaimKontoBox;
        private TextBox textBox1;
        private NumericUpDown BalanceAmount;
        private TextBox textBox4;
        private Button AcceptTransfer;
        private PictureBox pictureBox2;
        private Button BackBtn;
        private TextBox textBox2;
        private ComboBox TitleOption;
        private BindingSource accountBindingSource;
    }
}