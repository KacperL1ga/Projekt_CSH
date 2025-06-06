
using System;
using System.Drawing;
using System.Windows.Forms;

namespace BankApp
{
    partial class Main
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.SavingAccBtn = new System.Windows.Forms.Button();
            this.HistoryTabView = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.TransferView = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.TransactionView = new System.Windows.Forms.DataGridView();
            this.TransferBalance = new System.Windows.Forms.Button();
            this.WithdrawBalance = new System.Windows.Forms.Button();
            this.AddBalance = new System.Windows.Forms.Button();
            this.lblBalance = new System.Windows.Forms.Label();
            this.SavingAButton = new System.Windows.Forms.Button();
            this.MainAButton = new System.Windows.Forms.Button();
            this.LogOutBtn = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.DateFiltr = new System.Windows.Forms.TextBox();
            this.AmountFiltr = new System.Windows.Forms.TextBox();
            this.FiltrBtn = new System.Windows.Forms.Button();
            this.AmountLbl = new System.Windows.Forms.Label();
            this.DateLbl = new System.Windows.Forms.Label();
            this.ResetBtn = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.HistoryTabView.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TransferView)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TransactionView)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ResetBtn);
            this.panel1.Controls.Add(this.DateLbl);
            this.panel1.Controls.Add(this.AmountLbl);
            this.panel1.Controls.Add(this.FiltrBtn);
            this.panel1.Controls.Add(this.AmountFiltr);
            this.panel1.Controls.Add(this.DateFiltr);
            this.panel1.Controls.Add(this.SavingAccBtn);
            this.panel1.Controls.Add(this.HistoryTabView);
            this.panel1.Controls.Add(this.TransferBalance);
            this.panel1.Controls.Add(this.WithdrawBalance);
            this.panel1.Controls.Add(this.AddBalance);
            this.panel1.Controls.Add(this.lblBalance);
            this.panel1.Controls.Add(this.SavingAButton);
            this.panel1.Controls.Add(this.MainAButton);
            this.panel1.Controls.Add(this.LogOutBtn);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(704, 493);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint_1);
            // 
            // SavingAccBtn
            // 
            this.SavingAccBtn.Location = new System.Drawing.Point(584, 45);
            this.SavingAccBtn.Name = "SavingAccBtn";
            this.SavingAccBtn.Size = new System.Drawing.Size(105, 50);
            this.SavingAccBtn.TabIndex = 9;
            this.SavingAccBtn.Text = "dodaj konto oszczednosciowe";
            this.SavingAccBtn.UseVisualStyleBackColor = true;
            this.SavingAccBtn.Click += new System.EventHandler(this.SavingAccBtn_Click);
            // 
            // HistoryTabView
            // 
            this.HistoryTabView.Controls.Add(this.tabPage1);
            this.HistoryTabView.Controls.Add(this.tabPage2);
            this.HistoryTabView.Location = new System.Drawing.Point(45, 180);
            this.HistoryTabView.Name = "HistoryTabView";
            this.HistoryTabView.SelectedIndex = 0;
            this.HistoryTabView.Size = new System.Drawing.Size(636, 261);
            this.HistoryTabView.TabIndex = 8;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.TransferView);
            this.tabPage1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(628, 235);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Przelewy";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // TransferView
            // 
            this.TransferView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.TransferView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TransferView.Location = new System.Drawing.Point(0, 0);
            this.TransferView.Name = "TransferView";
            this.TransferView.Size = new System.Drawing.Size(627, 233);
            this.TransferView.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.TransactionView);
            this.tabPage2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(628, 235);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Transakcje";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // TransactionView
            // 
            this.TransactionView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.TransactionView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TransactionView.Location = new System.Drawing.Point(0, 0);
            this.TransactionView.Name = "TransactionView";
            this.TransactionView.Size = new System.Drawing.Size(625, 233);
            this.TransactionView.TabIndex = 0;
            // 
            // TransferBalance
            // 
            this.TransferBalance.AutoSize = true;
            this.TransferBalance.Font = new System.Drawing.Font("Segoe UI Semibold", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.TransferBalance.Location = new System.Drawing.Point(267, 447);
            this.TransferBalance.Name = "TransferBalance";
            this.TransferBalance.Size = new System.Drawing.Size(161, 38);
            this.TransferBalance.TabIndex = 7;
            this.TransferBalance.Text = "Przelew";
            this.TransferBalance.UseVisualStyleBackColor = true;
            this.TransferBalance.Click += new System.EventHandler(this.TransferBalance_Click);
            // 
            // WithdrawBalance
            // 
            this.WithdrawBalance.AutoSize = true;
            this.WithdrawBalance.Font = new System.Drawing.Font("Segoe UI Semibold", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.WithdrawBalance.Location = new System.Drawing.Point(502, 447);
            this.WithdrawBalance.Name = "WithdrawBalance";
            this.WithdrawBalance.Size = new System.Drawing.Size(179, 38);
            this.WithdrawBalance.TabIndex = 6;
            this.WithdrawBalance.Text = "Wyplata srodkow";
            this.WithdrawBalance.UseVisualStyleBackColor = true;
            this.WithdrawBalance.Click += new System.EventHandler(this.WithdrawBalance_Click);
            // 
            // AddBalance
            // 
            this.AddBalance.AutoSize = true;
            this.AddBalance.Font = new System.Drawing.Font("Segoe UI Semibold", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.AddBalance.Location = new System.Drawing.Point(45, 447);
            this.AddBalance.Name = "AddBalance";
            this.AddBalance.Size = new System.Drawing.Size(170, 38);
            this.AddBalance.TabIndex = 5;
            this.AddBalance.Text = "Wpłata srodkow";
            this.AddBalance.UseVisualStyleBackColor = true;
            this.AddBalance.Click += new System.EventHandler(this.AddBalance_Click);
            // 
            // lblBalance
            // 
            this.lblBalance.AutoSize = true;
            this.lblBalance.Font = new System.Drawing.Font("Segoe UI", 25F);
            this.lblBalance.Location = new System.Drawing.Point(311, 92);
            this.lblBalance.Name = "lblBalance";
            this.lblBalance.Size = new System.Drawing.Size(99, 46);
            this.lblBalance.TabIndex = 3;
            this.lblBalance.Text = "00,00";
            // 
            // SavingAButton
            // 
            this.SavingAButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SavingAButton.AutoSize = true;
            this.SavingAButton.Location = new System.Drawing.Point(385, 43);
            this.SavingAButton.Name = "SavingAButton";
            this.SavingAButton.Size = new System.Drawing.Size(133, 31);
            this.SavingAButton.TabIndex = 2;
            this.SavingAButton.Text = "Konto oszczednosciowe";
            this.SavingAButton.UseVisualStyleBackColor = true;
            this.SavingAButton.Click += new System.EventHandler(this.SavingAButton_Click);
            // 
            // MainAButton
            // 
            this.MainAButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MainAButton.AutoSize = true;
            this.MainAButton.Location = new System.Drawing.Point(187, 43);
            this.MainAButton.Name = "MainAButton";
            this.MainAButton.Size = new System.Drawing.Size(133, 31);
            this.MainAButton.TabIndex = 1;
            this.MainAButton.Text = "Konto glowne";
            this.MainAButton.UseVisualStyleBackColor = true;
            this.MainAButton.Click += new System.EventHandler(this.MainAButton_Click);
            // 
            // LogOutBtn
            // 
            this.LogOutBtn.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.LogOutBtn.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.LogOutBtn.Location = new System.Drawing.Point(584, 3);
            this.LogOutBtn.Name = "LogOutBtn";
            this.LogOutBtn.Size = new System.Drawing.Size(117, 36);
            this.LogOutBtn.TabIndex = 0;
            this.LogOutBtn.Text = "Wyloguj się";
            this.LogOutBtn.UseVisualStyleBackColor = false;
            this.LogOutBtn.Click += new System.EventHandler(this.LogOutBtn_Click);
            // 
            // toolTip1
            // 
            this.toolTip1.Popup += new System.Windows.Forms.PopupEventHandler(this.toolTip1_Popup);
            // 
            // DateFiltr
            // 
            this.DateFiltr.Location = new System.Drawing.Point(459, 163);
            this.DateFiltr.Name = "DateFiltr";
            this.DateFiltr.Size = new System.Drawing.Size(104, 20);
            this.DateFiltr.TabIndex = 10;
            this.DateFiltr.TextChanged += new System.EventHandler(this.DateFiltr_TextChanged);
            // 
            // AmountFiltr
            // 
            this.AmountFiltr.Location = new System.Drawing.Point(333, 163);
            this.AmountFiltr.Name = "AmountFiltr";
            this.AmountFiltr.Size = new System.Drawing.Size(110, 20);
            this.AmountFiltr.TabIndex = 11;
            this.AmountFiltr.TextChanged += new System.EventHandler(this.AmountFiltr_TextChanged);
            // 
            // FiltrBtn
            // 
            this.FiltrBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.FiltrBtn.Location = new System.Drawing.Point(581, 135);
            this.FiltrBtn.Name = "FiltrBtn";
            this.FiltrBtn.Size = new System.Drawing.Size(95, 25);
            this.FiltrBtn.TabIndex = 12;
            this.FiltrBtn.Text = "Filtruj";
            this.FiltrBtn.UseVisualStyleBackColor = true;
            this.FiltrBtn.Click += new System.EventHandler(this.FiltrBtn_Click);
            // 
            // AmountLbl
            // 
            this.AmountLbl.AutoSize = true;
            this.AmountLbl.Location = new System.Drawing.Point(330, 147);
            this.AmountLbl.Name = "AmountLbl";
            this.AmountLbl.Size = new System.Drawing.Size(83, 13);
            this.AmountLbl.TabIndex = 13;
            this.AmountLbl.Text = "Filtruj po kwocie";
            // 
            // DateLbl
            // 
            this.DateLbl.AutoSize = true;
            this.DateLbl.Location = new System.Drawing.Point(456, 147);
            this.DateLbl.Name = "DateLbl";
            this.DateLbl.Size = new System.Drawing.Size(75, 13);
            this.DateLbl.TabIndex = 14;
            this.DateLbl.Text = "Filtruj po dacie";
            // 
            // ResetBtn
            // 
            this.ResetBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ResetBtn.Location = new System.Drawing.Point(581, 158);
            this.ResetBtn.Name = "ResetBtn";
            this.ResetBtn.Size = new System.Drawing.Size(95, 25);
            this.ResetBtn.TabIndex = 15;
            this.ResetBtn.Text = "Reset";
            this.ResetBtn.UseVisualStyleBackColor = true;
            this.ResetBtn.Click += new System.EventHandler(this.ResetBtn_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 493);
            this.Controls.Add(this.panel1);
            this.Name = "Main";
            this.Text = "Form2";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.HistoryTabView.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TransferView)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TransactionView)).EndInit();
            this.ResumeLayout(false);

        }


        #endregion

        private Panel panel1;
        private Button LogOutBtn;
        private Button SavingAButton;
        private Button MainAButton;
        private Label lblBalance;
        private Button AddBalance;
        private Button WithdrawBalance;
        private Button TransferBalance;
        private TabControl HistoryTabView;
        private TabPage tabPage1;
        private DataGridView TransferView;
        private TabPage tabPage2;
        private DataGridView TransactionView;
        private Button SavingAccBtn;
        private ToolTip toolTip1;
        private Button FiltrBtn;
        private TextBox AmountFiltr;
        private TextBox DateFiltr;
        private Label DateLbl;
        private Label AmountLbl;
        private Button ResetBtn;
    }
}