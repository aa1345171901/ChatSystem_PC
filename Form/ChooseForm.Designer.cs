namespace QQ_piracy
{
    partial class ChooseForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChooseForm));
            this.sureButton = new System.Windows.Forms.Button();
            this.goLoginButton = new System.Windows.Forms.Button();
            this.name = new System.Windows.Forms.TextBox();
            this.age = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.fmale = new System.Windows.Forms.RadioButton();
            this.male = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.start = new System.Windows.Forms.ComboBox();
            this.blood = new System.Windows.Forms.ComboBox();
            this.ageLabel = new System.Windows.Forms.Label();
            this.trueNameLabel = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // sureButton
            // 
            this.sureButton.BackColor = System.Drawing.Color.DodgerBlue;
            this.sureButton.Font = new System.Drawing.Font("幼圆", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.sureButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.sureButton.Location = new System.Drawing.Point(83, 309);
            this.sureButton.Name = "sureButton";
            this.sureButton.Size = new System.Drawing.Size(94, 33);
            this.sureButton.TabIndex = 0;
            this.sureButton.Text = "确定";
            this.sureButton.UseVisualStyleBackColor = false;
            this.sureButton.Click += new System.EventHandler(this.sureButton_Click);
            // 
            // goLoginButton
            // 
            this.goLoginButton.BackColor = System.Drawing.Color.DodgerBlue;
            this.goLoginButton.Font = new System.Drawing.Font("幼圆", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.goLoginButton.ForeColor = System.Drawing.Color.White;
            this.goLoginButton.Location = new System.Drawing.Point(225, 309);
            this.goLoginButton.Name = "goLoginButton";
            this.goLoginButton.Size = new System.Drawing.Size(97, 33);
            this.goLoginButton.TabIndex = 1;
            this.goLoginButton.Text = "前往登录";
            this.goLoginButton.UseVisualStyleBackColor = false;
            this.goLoginButton.Click += new System.EventHandler(this.goLoginButton_Click);
            // 
            // name
            // 
            this.name.BackColor = System.Drawing.SystemColors.Window;
            this.name.Font = new System.Drawing.Font("幼圆", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.name.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.name.Location = new System.Drawing.Point(83, 33);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(239, 37);
            this.name.TabIndex = 2;
            // 
            // age
            // 
            this.age.BackColor = System.Drawing.SystemColors.Window;
            this.age.Font = new System.Drawing.Font("幼圆", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.age.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.age.Location = new System.Drawing.Point(83, 86);
            this.age.Name = "age";
            this.age.Size = new System.Drawing.Size(239, 37);
            this.age.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.fmale);
            this.panel1.Controls.Add(this.male);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(83, 138);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(239, 37);
            this.panel1.TabIndex = 4;
            // 
            // fmale
            // 
            this.fmale.AutoSize = true;
            this.fmale.Font = new System.Drawing.Font("幼圆", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.fmale.Location = new System.Drawing.Point(136, 3);
            this.fmale.Name = "fmale";
            this.fmale.Size = new System.Drawing.Size(58, 31);
            this.fmale.TabIndex = 2;
            this.fmale.TabStop = true;
            this.fmale.Text = "女";
            this.fmale.UseVisualStyleBackColor = true;
            // 
            // male
            // 
            this.male.AutoSize = true;
            this.male.Font = new System.Drawing.Font("幼圆", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.male.Location = new System.Drawing.Point(72, 3);
            this.male.Name = "male";
            this.male.Size = new System.Drawing.Size(58, 31);
            this.male.TabIndex = 1;
            this.male.TabStop = true;
            this.male.Text = "男";
            this.male.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("幼圆", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(-2, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 27);
            this.label1.TabIndex = 0;
            this.label1.Text = "性别";
            // 
            // start
            // 
            this.start.Font = new System.Drawing.Font("幼圆", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.start.FormattingEnabled = true;
            this.start.Location = new System.Drawing.Point(83, 190);
            this.start.Name = "start";
            this.start.Size = new System.Drawing.Size(236, 35);
            this.start.TabIndex = 5;
            // 
            // blood
            // 
            this.blood.Font = new System.Drawing.Font("幼圆", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.blood.FormattingEnabled = true;
            this.blood.Location = new System.Drawing.Point(83, 240);
            this.blood.Name = "blood";
            this.blood.Size = new System.Drawing.Size(236, 35);
            this.blood.TabIndex = 6;
            // 
            // ageLabel
            // 
            this.ageLabel.AutoSize = true;
            this.ageLabel.BackColor = System.Drawing.Color.White;
            this.ageLabel.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.ageLabel.Font = new System.Drawing.Font("幼圆", 20.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ageLabel.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.ageLabel.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.ageLabel.Location = new System.Drawing.Point(83, 86);
            this.ageLabel.MinimumSize = new System.Drawing.Size(239, 37);
            this.ageLabel.Name = "ageLabel";
            this.ageLabel.Size = new System.Drawing.Size(239, 37);
            this.ageLabel.TabIndex = 7;
            this.ageLabel.Text = "年龄";
            this.ageLabel.Click += new System.EventHandler(this.ageLabel_Click);
            // 
            // trueNameLabel
            // 
            this.trueNameLabel.AutoSize = true;
            this.trueNameLabel.BackColor = System.Drawing.Color.White;
            this.trueNameLabel.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.trueNameLabel.Font = new System.Drawing.Font("幼圆", 20.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.trueNameLabel.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.trueNameLabel.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.trueNameLabel.Location = new System.Drawing.Point(83, 33);
            this.trueNameLabel.MinimumSize = new System.Drawing.Size(239, 37);
            this.trueNameLabel.Name = "trueNameLabel";
            this.trueNameLabel.Size = new System.Drawing.Size(239, 37);
            this.trueNameLabel.TabIndex = 8;
            this.trueNameLabel.Text = "真实姓名";
            this.trueNameLabel.Click += new System.EventHandler(this.trueNameLabel_Click);
            // 
            // ChooseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(401, 354);
            this.Controls.Add(this.trueNameLabel);
            this.Controls.Add(this.blood);
            this.Controls.Add(this.start);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.name);
            this.Controls.Add(this.goLoginButton);
            this.Controls.Add(this.sureButton);
            this.Controls.Add(this.ageLabel);
            this.Controls.Add(this.age);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ChooseForm";
            this.Text = "选填信息";
            this.TransparencyKey = System.Drawing.Color.Fuchsia;
            this.Load += new System.EventHandler(this.ChooseForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button sureButton;
        private System.Windows.Forms.Button goLoginButton;
        private System.Windows.Forms.TextBox name;
        private System.Windows.Forms.TextBox age;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton fmale;
        private System.Windows.Forms.RadioButton male;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox start;
        private System.Windows.Forms.ComboBox blood;
        private System.Windows.Forms.Label ageLabel;
        private System.Windows.Forms.Label trueNameLabel;
    }
}