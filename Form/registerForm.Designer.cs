namespace QQ_piracy
{
    partial class RegisterForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegisterForm));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textNick = new System.Windows.Forms.TextBox();
            this.textPsw = new System.Windows.Forms.TextBox();
            this.textPswR = new System.Windows.Forms.TextBox();
            this.userLabel = new System.Windows.Forms.Label();
            this.Pswlabel = new System.Windows.Forms.Label();
            this.PswRLabel = new System.Windows.Forms.Label();
            this.registerButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("华文彩云", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(117, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(155, 36);
            this.label1.TabIndex = 0;
            this.label1.Text = "欢迎注册";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("幼圆", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(119, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(189, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "每一天，乐在沟通。";
            // 
            // textNick
            // 
            this.textNick.Font = new System.Drawing.Font("幼圆", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textNick.Location = new System.Drawing.Point(81, 100);
            this.textNick.MinimumSize = new System.Drawing.Size(100, 40);
            this.textNick.Name = "textNick";
            this.textNick.Size = new System.Drawing.Size(250, 37);
            this.textNick.TabIndex = 2;
            // 
            // textPsw
            // 
            this.textPsw.Font = new System.Drawing.Font("幼圆", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textPsw.Location = new System.Drawing.Point(81, 155);
            this.textPsw.MinimumSize = new System.Drawing.Size(100, 40);
            this.textPsw.Name = "textPsw";
            this.textPsw.PasswordChar = '·';
            this.textPsw.Size = new System.Drawing.Size(250, 37);
            this.textPsw.TabIndex = 3;
            // 
            // textPswR
            // 
            this.textPswR.Font = new System.Drawing.Font("幼圆", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textPswR.Location = new System.Drawing.Point(81, 211);
            this.textPswR.MinimumSize = new System.Drawing.Size(100, 40);
            this.textPswR.Name = "textPswR";
            this.textPswR.PasswordChar = '·';
            this.textPswR.Size = new System.Drawing.Size(250, 37);
            this.textPswR.TabIndex = 4;
            // 
            // userLabel
            // 
            this.userLabel.AutoSize = true;
            this.userLabel.BackColor = System.Drawing.Color.White;
            this.userLabel.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.userLabel.Font = new System.Drawing.Font("幼圆", 20.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.userLabel.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.userLabel.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.userLabel.Location = new System.Drawing.Point(82, 101);
            this.userLabel.MinimumSize = new System.Drawing.Size(250, 40);
            this.userLabel.Name = "userLabel";
            this.userLabel.Size = new System.Drawing.Size(250, 40);
            this.userLabel.TabIndex = 5;
            this.userLabel.Text = "昵称";
            this.userLabel.Click += new System.EventHandler(this.userLabel_Click);
            // 
            // Pswlabel
            // 
            this.Pswlabel.AutoSize = true;
            this.Pswlabel.BackColor = System.Drawing.Color.White;
            this.Pswlabel.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.Pswlabel.Font = new System.Drawing.Font("幼圆", 20.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Pswlabel.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.Pswlabel.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.Pswlabel.Location = new System.Drawing.Point(82, 155);
            this.Pswlabel.MinimumSize = new System.Drawing.Size(250, 40);
            this.Pswlabel.Name = "Pswlabel";
            this.Pswlabel.Size = new System.Drawing.Size(250, 40);
            this.Pswlabel.TabIndex = 6;
            this.Pswlabel.Text = "密码";
            this.Pswlabel.Click += new System.EventHandler(this.Pswlabel_Click);
            // 
            // PswRLabel
            // 
            this.PswRLabel.AutoSize = true;
            this.PswRLabel.BackColor = System.Drawing.Color.White;
            this.PswRLabel.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.PswRLabel.Font = new System.Drawing.Font("幼圆", 20.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.PswRLabel.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.PswRLabel.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.PswRLabel.Location = new System.Drawing.Point(82, 211);
            this.PswRLabel.MinimumSize = new System.Drawing.Size(250, 40);
            this.PswRLabel.Name = "PswRLabel";
            this.PswRLabel.Size = new System.Drawing.Size(250, 40);
            this.PswRLabel.TabIndex = 7;
            this.PswRLabel.Text = "重复密码";
            this.PswRLabel.Click += new System.EventHandler(this.PswRLabel_Click);
            // 
            // registerButton
            // 
            this.registerButton.BackColor = System.Drawing.Color.DodgerBlue;
            this.registerButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.registerButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.registerButton.Font = new System.Drawing.Font("方正舒体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.registerButton.ForeColor = System.Drawing.Color.White;
            this.registerButton.Location = new System.Drawing.Point(81, 278);
            this.registerButton.Name = "registerButton";
            this.registerButton.Size = new System.Drawing.Size(251, 42);
            this.registerButton.TabIndex = 9;
            this.registerButton.Text = "立即注册";
            this.registerButton.UseVisualStyleBackColor = false;
            this.registerButton.Click += new System.EventHandler(this.registerButton_Click);
            // 
            // RegisterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(401, 354);
            this.Controls.Add(this.registerButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.userLabel);
            this.Controls.Add(this.PswRLabel);
            this.Controls.Add(this.textNick);
            this.Controls.Add(this.textPswR);
            this.Controls.Add(this.Pswlabel);
            this.Controls.Add(this.textPsw);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "RegisterForm";
            this.Text = "Register";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RegisterForm_FormClosing);
            this.Load += new System.EventHandler(this.RegisterForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textNick;
        private System.Windows.Forms.TextBox textPsw;
        private System.Windows.Forms.TextBox textPswR;
        private System.Windows.Forms.Label userLabel;
        private System.Windows.Forms.Label Pswlabel;
        private System.Windows.Forms.Label PswRLabel;
        private System.Windows.Forms.Button registerButton;
    }
}