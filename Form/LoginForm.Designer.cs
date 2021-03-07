using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace QQ_piracy
{
    partial class LoginForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.userLabel = new System.Windows.Forms.Label();
            this.PasswordLabel = new System.Windows.Forms.Label();
            this.autoLogin = new System.Windows.Forms.CheckBox();
            this.forgetPsw = new System.Windows.Forms.CheckBox();
            this.getPsw = new System.Windows.Forms.Label();
            this.loginButton = new System.Windows.Forms.Button();
            this.close = new System.Windows.Forms.Button();
            this.min = new System.Windows.Forms.Button();
            this.register = new System.Windows.Forms.Label();
            this.AsynTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(252)))), ((int)(((byte)(252)))));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(-1, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(427, 123);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("方正舒体", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox1.ForeColor = System.Drawing.SystemColors.InfoText;
            this.textBox1.Location = new System.Drawing.Point(115, 164);
            this.textBox1.MaximumSize = new System.Drawing.Size(500, 40);
            this.textBox1.MinimumSize = new System.Drawing.Size(100, 30);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(202, 26);
            this.textBox1.TabIndex = 0;
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Font = new System.Drawing.Font("楷体", 18F);
            this.textBox2.ForeColor = System.Drawing.SystemColors.InfoText;
            this.textBox2.Location = new System.Drawing.Point(115, 200);
            this.textBox2.MaximumSize = new System.Drawing.Size(500, 40);
            this.textBox2.MinimumSize = new System.Drawing.Size(100, 30);
            this.textBox2.Name = "textBox2";
            this.textBox2.PasswordChar = '•';
            this.textBox2.Size = new System.Drawing.Size(202, 28);
            this.textBox2.TabIndex = 1;
            // 
            // userLabel
            // 
            this.userLabel.AutoSize = true;
            this.userLabel.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.userLabel.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.userLabel.Font = new System.Drawing.Font("幼圆", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.userLabel.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.userLabel.Location = new System.Drawing.Point(115, 164);
            this.userLabel.MinimumSize = new System.Drawing.Size(202, 26);
            this.userLabel.Name = "userLabel";
            this.userLabel.Size = new System.Drawing.Size(202, 26);
            this.userLabel.TabIndex = 2;
            this.userLabel.Text = "账号";
            this.userLabel.Click += new System.EventHandler(this.label1_Click);
            // 
            // PasswordLabel
            // 
            this.PasswordLabel.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.PasswordLabel.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.PasswordLabel.Font = new System.Drawing.Font("幼圆", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.PasswordLabel.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.PasswordLabel.Location = new System.Drawing.Point(115, 202);
            this.PasswordLabel.MinimumSize = new System.Drawing.Size(202, 26);
            this.PasswordLabel.Name = "PasswordLabel";
            this.PasswordLabel.Size = new System.Drawing.Size(202, 28);
            this.PasswordLabel.TabIndex = 3;
            this.PasswordLabel.Text = "密码";
            this.PasswordLabel.Click += new System.EventHandler(this.label2_Click);
            // 
            // autoLogin
            // 
            this.autoLogin.AutoSize = true;
            this.autoLogin.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.autoLogin.Location = new System.Drawing.Point(100, 243);
            this.autoLogin.Name = "autoLogin";
            this.autoLogin.Size = new System.Drawing.Size(72, 16);
            this.autoLogin.TabIndex = 4;
            this.autoLogin.Text = "自动登录";
            this.autoLogin.UseVisualStyleBackColor = true;
            // 
            // forgetPsw
            // 
            this.forgetPsw.AutoSize = true;
            this.forgetPsw.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.forgetPsw.Location = new System.Drawing.Point(191, 243);
            this.forgetPsw.Name = "forgetPsw";
            this.forgetPsw.Size = new System.Drawing.Size(72, 16);
            this.forgetPsw.TabIndex = 5;
            this.forgetPsw.Text = "记住密码";
            this.forgetPsw.UseVisualStyleBackColor = true;
            // 
            // getPsw
            // 
            this.getPsw.AutoSize = true;
            this.getPsw.BackColor = System.Drawing.SystemColors.Control;
            this.getPsw.Cursor = System.Windows.Forms.Cursors.Hand;
            this.getPsw.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.getPsw.Location = new System.Drawing.Point(285, 244);
            this.getPsw.MinimumSize = new System.Drawing.Size(56, 21);
            this.getPsw.Name = "getPsw";
            this.getPsw.Size = new System.Drawing.Size(56, 21);
            this.getPsw.TabIndex = 7;
            this.getPsw.Text = "找回密码";
            this.getPsw.Click += new System.EventHandler(this.getPsw_Click);
            // 
            // loginButton
            // 
            this.loginButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(194)))), ((int)(((byte)(255)))));
            this.loginButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.loginButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.loginButton.Font = new System.Drawing.Font("方正舒体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.loginButton.ForeColor = System.Drawing.Color.White;
            this.loginButton.Location = new System.Drawing.Point(97, 268);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(241, 37);
            this.loginButton.TabIndex = 8;
            this.loginButton.Text = "登录";
            this.loginButton.UseVisualStyleBackColor = false;
            this.loginButton.Click += new System.EventHandler(this.loginButton_Click);
            // 
            // close
            // 
            this.close.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.close.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.close.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.close.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.close.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.close.Font = new System.Drawing.Font("方正舒体", 15F);
            this.close.ForeColor = System.Drawing.Color.White;
            this.close.Location = new System.Drawing.Point(391, 0);
            this.close.Name = "close";
            this.close.Size = new System.Drawing.Size(35, 33);
            this.close.TabIndex = 9;
            this.close.Text = "×";
            this.close.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.close.UseVisualStyleBackColor = false;
            this.close.Click += new System.EventHandler(this.close_Click);
            // 
            // min
            // 
            this.min.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.min.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.min.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.min.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.min.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.min.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.min.Font = new System.Drawing.Font("方正舒体", 15F);
            this.min.ForeColor = System.Drawing.Color.White;
            this.min.Location = new System.Drawing.Point(355, 0);
            this.min.Name = "min";
            this.min.Size = new System.Drawing.Size(35, 33);
            this.min.TabIndex = 10;
            this.min.Text = "-";
            this.min.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.min.UseVisualStyleBackColor = false;
            this.min.Click += new System.EventHandler(this.min_Click);
            // 
            // register
            // 
            this.register.AutoSize = true;
            this.register.BackColor = System.Drawing.SystemColors.Control;
            this.register.Cursor = System.Windows.Forms.Cursors.Hand;
            this.register.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.register.Location = new System.Drawing.Point(11, 304);
            this.register.MinimumSize = new System.Drawing.Size(56, 21);
            this.register.Name = "register";
            this.register.Size = new System.Drawing.Size(56, 21);
            this.register.TabIndex = 11;
            this.register.Text = "注册账号";
            this.register.Click += new System.EventHandler(this.register_Click);
            // 
            // AsynTimer
            // 
            this.AsynTimer.Enabled = true;
            this.AsynTimer.Tick += new System.EventHandler(this.AsynTimer_Tick);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Menu;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(426, 327);
            this.Controls.Add(this.register);
            this.Controls.Add(this.min);
            this.Controls.Add(this.close);
            this.Controls.Add(this.loginButton);
            this.Controls.Add(this.getPsw);
            this.Controls.Add(this.forgetPsw);
            this.Controls.Add(this.autoLogin);
            this.Controls.Add(this.userLabel);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.PasswordLabel);
            this.Controls.Add(this.textBox2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LoginForm";
            this.TransparencyKey = System.Drawing.Color.Maroon;
            this.Load += new System.EventHandler(this.LoginForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label userLabel;
        private System.Windows.Forms.Label PasswordLabel;
        private System.Windows.Forms.CheckBox autoLogin;
        private System.Windows.Forms.CheckBox forgetPsw;
        private System.Windows.Forms.Label getPsw;
        private System.Windows.Forms.Button loginButton;
        private System.Windows.Forms.Button close;
        private System.Windows.Forms.Button min;
        private Label register;
        private Timer AsynTimer;
    }
}