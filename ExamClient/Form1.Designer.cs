namespace ExamClient
{
    partial class Form1
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
            this.lblTimer = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.lnkRegister = new System.Windows.Forms.LinkLabel();
            this.lnkForgot = new System.Windows.Forms.LinkLabel();
            this.grpRegister = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnRegSubmit = new System.Windows.Forms.Button();
            this.txtRegPass = new System.Windows.Forms.TextBox();
            this.txtRegUser = new System.Windows.Forms.TextBox();
            this.grpForgot = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnForgotSubmit = new System.Windows.Forms.Button();
            this.txtForgotUser = new System.Windows.Forms.TextBox();
            this.grpRegister.SuspendLayout();
            this.grpForgot.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTimer
            // 
            this.lblTimer.AutoSize = true;
            this.lblTimer.Location = new System.Drawing.Point(188, 123);
            this.lblTimer.Name = "lblTimer";
            this.lblTimer.Size = new System.Drawing.Size(0, 16);
            this.lblTimer.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(97, 123);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tài khoản:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(97, 170);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Mật khẩu:";
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(173, 123);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(100, 22);
            this.txtUser.TabIndex = 3;
            // 
            // txtPass
            // 
            this.txtPass.Location = new System.Drawing.Point(173, 170);
            this.txtPass.Name = "txtPass";
            this.txtPass.Size = new System.Drawing.Size(100, 22);
            this.txtPass.TabIndex = 4;
            this.txtPass.UseSystemPasswordChar = true;
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(163, 235);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(128, 31);
            this.btnLogin.TabIndex = 5;
            this.btnLogin.Text = "Đăng nhập";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // lnkRegister
            // 
            this.lnkRegister.AutoSize = true;
            this.lnkRegister.Location = new System.Drawing.Point(101, 287);
            this.lnkRegister.Name = "lnkRegister";
            this.lnkRegister.Size = new System.Drawing.Size(172, 16);
            this.lnkRegister.TabIndex = 6;
            this.lnkRegister.TabStop = true;
            this.lnkRegister.Text = "Chưa có tài khoản? Đăng ký";
            this.lnkRegister.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkRegister_LinkClicked);
            // 
            // lnkForgot
            // 
            this.lnkForgot.AutoSize = true;
            this.lnkForgot.Location = new System.Drawing.Point(101, 317);
            this.lnkForgot.Name = "lnkForgot";
            this.lnkForgot.Size = new System.Drawing.Size(103, 16);
            this.lnkForgot.TabIndex = 7;
            this.lnkForgot.TabStop = true;
            this.lnkForgot.Text = "Quên mật khẩu?";
            this.lnkForgot.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkRegister_LinkClicked);
            // 
            // grpRegister
            // 
            this.grpRegister.Controls.Add(this.label4);
            this.grpRegister.Controls.Add(this.label3);
            this.grpRegister.Controls.Add(this.btnRegSubmit);
            this.grpRegister.Controls.Add(this.txtRegPass);
            this.grpRegister.Controls.Add(this.txtRegUser);
            this.grpRegister.Location = new System.Drawing.Point(370, 170);
            this.grpRegister.Name = "grpRegister";
            this.grpRegister.Size = new System.Drawing.Size(200, 228);
            this.grpRegister.TabIndex = 8;
            this.grpRegister.TabStop = false;
            this.grpRegister.Text = "ĐĂNG KÝ TÀI KHOẢN";
            this.grpRegister.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 116);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 16);
            this.label4.TabIndex = 4;
            this.label4.Text = "Mật khẩu:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(0, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 16);
            this.label3.TabIndex = 3;
            this.label3.Text = "Tài khoản:";
            // 
            // btnRegSubmit
            // 
            this.btnRegSubmit.Location = new System.Drawing.Point(55, 164);
            this.btnRegSubmit.Name = "btnRegSubmit";
            this.btnRegSubmit.Size = new System.Drawing.Size(89, 23);
            this.btnRegSubmit.TabIndex = 2;
            this.btnRegSubmit.Text = "Đăng ký";
            this.btnRegSubmit.UseVisualStyleBackColor = true;
            this.btnRegSubmit.Click += new System.EventHandler(this.btnRegSubmit_Click);
            // 
            // txtRegPass
            // 
            this.txtRegPass.Location = new System.Drawing.Point(76, 113);
            this.txtRegPass.Name = "txtRegPass";
            this.txtRegPass.Size = new System.Drawing.Size(100, 22);
            this.txtRegPass.TabIndex = 1;
            // 
            // txtRegUser
            // 
            this.txtRegUser.Location = new System.Drawing.Point(76, 68);
            this.txtRegUser.Name = "txtRegUser";
            this.txtRegUser.Size = new System.Drawing.Size(100, 22);
            this.txtRegUser.TabIndex = 0;
            // 
            // grpForgot
            // 
            this.grpForgot.Controls.Add(this.label5);
            this.grpForgot.Controls.Add(this.btnForgotSubmit);
            this.grpForgot.Controls.Add(this.txtForgotUser);
            this.grpForgot.Location = new System.Drawing.Point(370, 39);
            this.grpForgot.Name = "grpForgot";
            this.grpForgot.Size = new System.Drawing.Size(200, 100);
            this.grpForgot.TabIndex = 9;
            this.grpForgot.TabStop = false;
            this.grpForgot.Text = "KHÔI PHỤC MẬT KHẨU";
            this.grpForgot.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 34);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 16);
            this.label5.TabIndex = 2;
            this.label5.Text = "Mật khẩu:";
            // 
            // btnForgotSubmit
            // 
            this.btnForgotSubmit.Location = new System.Drawing.Point(60, 59);
            this.btnForgotSubmit.Name = "btnForgotSubmit";
            this.btnForgotSubmit.Size = new System.Drawing.Size(112, 23);
            this.btnForgotSubmit.TabIndex = 1;
            this.btnForgotSubmit.Text = "Đặt lại mật khẩu";
            this.btnForgotSubmit.UseVisualStyleBackColor = true;
            // 
            // txtForgotUser
            // 
            this.txtForgotUser.Location = new System.Drawing.Point(72, 31);
            this.txtForgotUser.Name = "txtForgotUser";
            this.txtForgotUser.Size = new System.Drawing.Size(100, 22);
            this.txtForgotUser.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 415);
            this.Controls.Add(this.grpForgot);
            this.Controls.Add(this.grpRegister);
            this.Controls.Add(this.lnkForgot);
            this.Controls.Add(this.lnkRegister);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.txtPass);
            this.Controls.Add(this.txtUser);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblTimer);
            this.Name = "Form1";
            this.Text = "Đăng nhập";
            this.grpRegister.ResumeLayout(false);
            this.grpRegister.PerformLayout();
            this.grpForgot.ResumeLayout(false);
            this.grpForgot.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTimer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.TextBox txtPass;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.LinkLabel lnkRegister;
        private System.Windows.Forms.LinkLabel lnkForgot;
        private System.Windows.Forms.GroupBox grpRegister;
        private System.Windows.Forms.TextBox txtRegUser;
        private System.Windows.Forms.Button btnRegSubmit;
        private System.Windows.Forms.TextBox txtRegPass;
        private System.Windows.Forms.GroupBox grpForgot;
        private System.Windows.Forms.TextBox txtForgotUser;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnForgotSubmit;
    }
}

