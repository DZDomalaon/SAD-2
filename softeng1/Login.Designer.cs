﻿namespace softeng1
{
    partial class loginForm
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
            this.time = new System.Windows.Forms.Label();
            this.loginBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.passwdTxt = new System.Windows.Forms.TextBox();
            this.unameTxt = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.showPassword = new System.Windows.Forms.CheckBox();
            this.incorrectpanel = new System.Windows.Forms.Panel();
            this.panel11 = new System.Windows.Forms.Panel();
            this.closePanel = new System.Windows.Forms.Button();
            this.label18 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label19 = new System.Windows.Forms.Label();
            this.incorrectpanel.SuspendLayout();
            this.panel11.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // time
            // 
            this.time.AutoSize = true;
            this.time.BackColor = System.Drawing.Color.Transparent;
            this.time.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.time.ForeColor = System.Drawing.Color.Black;
            this.time.Location = new System.Drawing.Point(171, 59);
            this.time.Name = "time";
            this.time.Size = new System.Drawing.Size(199, 73);
            this.time.TabIndex = 8;
            this.time.Text = "00:00";
            // 
            // loginBtn
            // 
            this.loginBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.loginBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.loginBtn.Font = new System.Drawing.Font("Calibri Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loginBtn.ForeColor = System.Drawing.Color.White;
            this.loginBtn.Location = new System.Drawing.Point(201, 252);
            this.loginBtn.Name = "loginBtn";
            this.loginBtn.Size = new System.Drawing.Size(124, 38);
            this.loginBtn.TabIndex = 3;
            this.loginBtn.Text = "LOGIN";
            this.loginBtn.UseVisualStyleBackColor = false;
            this.loginBtn.Click += new System.EventHandler(this.loginBtn_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cancelBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cancelBtn.Font = new System.Drawing.Font("Calibri Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelBtn.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.cancelBtn.Location = new System.Drawing.Point(321, 252);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(116, 38);
            this.cancelBtn.TabIndex = 4;
            this.cancelBtn.Text = "CANCEL";
            this.cancelBtn.UseVisualStyleBackColor = false;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // passwdTxt
            // 
            this.passwdTxt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(24)))), ((int)(((byte)(29)))));
            this.passwdTxt.Font = new System.Drawing.Font("Calibri Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwdTxt.ForeColor = System.Drawing.Color.White;
            this.passwdTxt.Location = new System.Drawing.Point(201, 191);
            this.passwdTxt.Name = "passwdTxt";
            this.passwdTxt.PasswordChar = '*';
            this.passwdTxt.Size = new System.Drawing.Size(236, 27);
            this.passwdTxt.TabIndex = 2;
            this.passwdTxt.Text = "PASSWORD";
            this.passwdTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // unameTxt
            // 
            this.unameTxt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(24)))), ((int)(((byte)(29)))));
            this.unameTxt.Font = new System.Drawing.Font("Calibri Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.unameTxt.ForeColor = System.Drawing.Color.White;
            this.unameTxt.Location = new System.Drawing.Point(201, 143);
            this.unameTxt.Name = "unameTxt";
            this.unameTxt.Size = new System.Drawing.Size(236, 27);
            this.unameTxt.TabIndex = 1;
            this.unameTxt.Text = "username";
            this.unameTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(147)))), ((int)(((byte)(244)))));
            this.panel1.BackgroundImage = global::softeng1.Properties.Resources.bg;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(127, 341);
            this.panel1.TabIndex = 9;
            // 
            // showPassword
            // 
            this.showPassword.AutoSize = true;
            this.showPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.showPassword.Location = new System.Drawing.Point(258, 225);
            this.showPassword.Name = "showPassword";
            this.showPassword.Size = new System.Drawing.Size(115, 17);
            this.showPassword.TabIndex = 10;
            this.showPassword.Text = "Show Password";
            this.showPassword.UseVisualStyleBackColor = true;
            this.showPassword.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // incorrectpanel
            // 
            this.incorrectpanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(57)))), ((int)(((byte)(64)))));
            this.incorrectpanel.Controls.Add(this.panel11);
            this.incorrectpanel.Controls.Add(this.pictureBox2);
            this.incorrectpanel.Controls.Add(this.label19);
            this.incorrectpanel.Enabled = false;
            this.incorrectpanel.Location = new System.Drawing.Point(112, 98);
            this.incorrectpanel.Name = "incorrectpanel";
            this.incorrectpanel.Size = new System.Drawing.Size(384, 145);
            this.incorrectpanel.TabIndex = 115;
            this.incorrectpanel.Visible = false;
            // 
            // panel11
            // 
            this.panel11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(49)))), ((int)(((byte)(55)))));
            this.panel11.Controls.Add(this.closePanel);
            this.panel11.Controls.Add(this.label18);
            this.panel11.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel11.Location = new System.Drawing.Point(0, 0);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(384, 35);
            this.panel11.TabIndex = 64;
            // 
            // closePanel
            // 
            this.closePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(90)))), ((int)(((byte)(74)))));
            this.closePanel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closePanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closePanel.ForeColor = System.Drawing.Color.White;
            this.closePanel.Location = new System.Drawing.Point(351, 3);
            this.closePanel.Name = "closePanel";
            this.closePanel.Size = new System.Drawing.Size(30, 25);
            this.closePanel.TabIndex = 64;
            this.closePanel.Text = "X";
            this.closePanel.UseVisualStyleBackColor = false;
            this.closePanel.Click += new System.EventHandler(this.closePanel_Click);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.label18.Location = new System.Drawing.Point(142, 3);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(82, 21);
            this.label18.TabIndex = 63;
            this.label18.Text = "Incorrect";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::softeng1.Properties.Resources.error;
            this.pictureBox2.Location = new System.Drawing.Point(54, 65);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(45, 35);
            this.pictureBox2.TabIndex = 65;
            this.pictureBox2.TabStop = false;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.label19.Location = new System.Drawing.Point(105, 54);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(162, 46);
            this.label19.TabIndex = 63;
            this.label19.Text = "Incorrect username\r\nor password.";
            // 
            // loginForm
            // 
            this.AcceptButton = this.loginBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(609, 341);
            this.Controls.Add(this.incorrectpanel);
            this.Controls.Add(this.showPassword);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.passwdTxt);
            this.Controls.Add(this.loginBtn);
            this.Controls.Add(this.unameTxt);
            this.Controls.Add(this.time);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "loginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Glacier Tractor Parts & Sales | Login";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.incorrectpanel.ResumeLayout(false);
            this.incorrectpanel.PerformLayout();
            this.panel11.ResumeLayout(false);
            this.panel11.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label time;
        private System.Windows.Forms.Button loginBtn;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.TextBox passwdTxt;
        private System.Windows.Forms.TextBox unameTxt;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox showPassword;
        private System.Windows.Forms.Panel incorrectpanel;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.Button closePanel;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label19;
    }
}

