﻿namespace softeng1
{
    partial class settingsForm
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
            this.panel3 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.unameTxt = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.userBtn = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.passBtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.opsswrdTxt = new System.Windows.Forms.TextBox();
            this.npsswrdTxt = new System.Windows.Forms.TextBox();
            this.cpsswrdTxt = new System.Windows.Forms.TextBox();
            this.backBtn = new System.Windows.Forms.Button();
            this.usernLbl = new System.Windows.Forms.Label();
            this.psswrdLbl = new System.Windows.Forms.Label();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(49)))), ((int)(((byte)(55)))));
            this.panel3.Controls.Add(this.label1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(334, 47);
            this.panel3.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(106, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 33);
            this.label1.TabIndex = 0;
            this.label1.Text = "Settings";
            // 
            // unameTxt
            // 
            this.unameTxt.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.unameTxt.Location = new System.Drawing.Point(12, 55);
            this.unameTxt.Name = "unameTxt";
            this.unameTxt.Size = new System.Drawing.Size(211, 26);
            this.unameTxt.TabIndex = 41;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(49)))), ((int)(((byte)(55)))));
            this.label7.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(12, 18);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(183, 22);
            this.label7.TabIndex = 40;
            this.label7.Text = "Change Username";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(57)))), ((int)(((byte)(64)))));
            this.panel1.Controls.Add(this.usernLbl);
            this.panel1.Controls.Add(this.userBtn);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.unameTxt);
            this.panel1.Location = new System.Drawing.Point(0, 47);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(334, 107);
            this.panel1.TabIndex = 5;
            // 
            // userBtn
            // 
            this.userBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(185)))), ((int)(((byte)(0)))));
            this.userBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.userBtn.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userBtn.ForeColor = System.Drawing.Color.White;
            this.userBtn.Location = new System.Drawing.Point(244, 49);
            this.userBtn.Name = "userBtn";
            this.userBtn.Size = new System.Drawing.Size(78, 35);
            this.userBtn.TabIndex = 36;
            this.userBtn.Text = "Update";
            this.userBtn.UseVisualStyleBackColor = false;
            this.userBtn.Click += new System.EventHandler(this.userBtn_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(77)))), ((int)(((byte)(86)))));
            this.panel2.Controls.Add(this.psswrdLbl);
            this.panel2.Controls.Add(this.backBtn);
            this.panel2.Controls.Add(this.cpsswrdTxt);
            this.panel2.Controls.Add(this.npsswrdTxt);
            this.panel2.Controls.Add(this.passBtn);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.opsswrdTxt);
            this.panel2.Location = new System.Drawing.Point(0, 152);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(334, 190);
            this.panel2.TabIndex = 42;
            // 
            // passBtn
            // 
            this.passBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(185)))), ((int)(((byte)(0)))));
            this.passBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.passBtn.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passBtn.ForeColor = System.Drawing.Color.White;
            this.passBtn.Location = new System.Drawing.Point(244, 55);
            this.passBtn.Name = "passBtn";
            this.passBtn.Size = new System.Drawing.Size(78, 35);
            this.passBtn.TabIndex = 36;
            this.passBtn.Text = "Update";
            this.passBtn.UseVisualStyleBackColor = false;
            this.passBtn.Click += new System.EventHandler(this.passBtn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(49)))), ((int)(((byte)(55)))));
            this.label2.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(12, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(177, 22);
            this.label2.TabIndex = 40;
            this.label2.Text = "Change Password";
            // 
            // opsswrdTxt
            // 
            this.opsswrdTxt.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.opsswrdTxt.ForeColor = System.Drawing.Color.Gray;
            this.opsswrdTxt.Location = new System.Drawing.Point(12, 55);
            this.opsswrdTxt.Name = "opsswrdTxt";
            this.opsswrdTxt.Size = new System.Drawing.Size(211, 26);
            this.opsswrdTxt.TabIndex = 41;
            this.opsswrdTxt.Text = "Old Password";
            // 
            // npsswrdTxt
            // 
            this.npsswrdTxt.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.npsswrdTxt.ForeColor = System.Drawing.Color.Gray;
            this.npsswrdTxt.Location = new System.Drawing.Point(12, 87);
            this.npsswrdTxt.Name = "npsswrdTxt";
            this.npsswrdTxt.Size = new System.Drawing.Size(211, 26);
            this.npsswrdTxt.TabIndex = 42;
            this.npsswrdTxt.Text = "New Password";
            // 
            // cpsswrdTxt
            // 
            this.cpsswrdTxt.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cpsswrdTxt.ForeColor = System.Drawing.Color.Gray;
            this.cpsswrdTxt.Location = new System.Drawing.Point(12, 119);
            this.cpsswrdTxt.Name = "cpsswrdTxt";
            this.cpsswrdTxt.Size = new System.Drawing.Size(211, 26);
            this.cpsswrdTxt.TabIndex = 43;
            this.cpsswrdTxt.Text = "Re-type New Password";
            // 
            // backBtn
            // 
            this.backBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(164)))), ((int)(((byte)(239)))));
            this.backBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.backBtn.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.backBtn.ForeColor = System.Drawing.Color.White;
            this.backBtn.Location = new System.Drawing.Point(244, 108);
            this.backBtn.Name = "backBtn";
            this.backBtn.Size = new System.Drawing.Size(78, 37);
            this.backBtn.TabIndex = 46;
            this.backBtn.Text = "Back";
            this.backBtn.UseVisualStyleBackColor = false;
            this.backBtn.Click += new System.EventHandler(this.backBtn_Click);
            // 
            // usernLbl
            // 
            this.usernLbl.AutoSize = true;
            this.usernLbl.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usernLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.usernLbl.Location = new System.Drawing.Point(34, 84);
            this.usernLbl.Name = "usernLbl";
            this.usernLbl.Size = new System.Drawing.Size(58, 18);
            this.usernLbl.TabIndex = 42;
            this.usernLbl.Text = "----------";
            this.usernLbl.Visible = false;
            // 
            // psswrdLbl
            // 
            this.psswrdLbl.AutoSize = true;
            this.psswrdLbl.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.psswrdLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.psswrdLbl.Location = new System.Drawing.Point(34, 148);
            this.psswrdLbl.Name = "psswrdLbl";
            this.psswrdLbl.Size = new System.Drawing.Size(58, 18);
            this.psswrdLbl.TabIndex = 43;
            this.psswrdLbl.Text = "----------";
            // 
            // settingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(334, 340);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "settingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Glacier Tractor Parts & Sales | Settings";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.settingsForm_FormClosing);
            this.Load += new System.EventHandler(this.settingsForm_Load);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox unameTxt;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button userBtn;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button passBtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox opsswrdTxt;
        private System.Windows.Forms.TextBox cpsswrdTxt;
        private System.Windows.Forms.TextBox npsswrdTxt;
        private System.Windows.Forms.Button backBtn;
        private System.Windows.Forms.Label usernLbl;
        private System.Windows.Forms.Label psswrdLbl;
    }
}