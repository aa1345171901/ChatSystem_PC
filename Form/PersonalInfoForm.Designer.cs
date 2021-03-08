using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace QQ_piracy
{
    partial class PersonalInfoForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PersonalInfoForm));
            this.min = new System.Windows.Forms.Button();
            this.close = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.xiugai = new System.Windows.Forms.Label();
            this.bloodlabel = new System.Windows.Forms.Label();
            this.blood = new System.Windows.Forms.Label();
            this.startlabel = new System.Windows.Forms.Label();
            this.start = new System.Windows.Forms.Label();
            this.namelabel = new System.Windows.Forms.Label();
            this.name = new System.Windows.Forms.Label();
            this.agelabel = new System.Windows.Forms.Label();
            this.age = new System.Windows.Forms.Label();
            this.sexlabel = new System.Windows.Forms.Label();
            this.sex = new System.Windows.Forms.Label();
            this.idLabel = new System.Windows.Forms.Label();
            this.id = new System.Windows.Forms.Label();
            this.touxiang = new System.Windows.Forms.PictureBox();
            this.nickLabel = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.touxiang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // min
            // 
            this.min.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.min.BackColor = System.Drawing.Color.White;
            this.min.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.min.FlatAppearance.BorderSize = 0;
            this.min.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.min.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.min.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.min.Font = new System.Drawing.Font("方正舒体", 15F);
            this.min.ForeColor = System.Drawing.Color.Black;
            this.min.Location = new System.Drawing.Point(573, 1);
            this.min.Name = "min";
            this.min.Size = new System.Drawing.Size(35, 33);
            this.min.TabIndex = 18;
            this.min.Text = "-";
            this.min.UseVisualStyleBackColor = false;
            this.min.Click += new System.EventHandler(this.min_Click);
            // 
            // close
            // 
            this.close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.close.BackColor = System.Drawing.Color.White;
            this.close.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.close.FlatAppearance.BorderSize = 0;
            this.close.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.close.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.close.Font = new System.Drawing.Font("方正舒体", 15F);
            this.close.ForeColor = System.Drawing.Color.Black;
            this.close.Location = new System.Drawing.Point(607, 1);
            this.close.Name = "close";
            this.close.Size = new System.Drawing.Size(35, 33);
            this.close.TabIndex = 17;
            this.close.Text = "×";
            this.close.UseVisualStyleBackColor = false;
            this.close.Click += new System.EventHandler(this.close_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Default;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(-1, 1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(265, 289);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 19;
            this.pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.Controls.Add(this.xiugai);
            this.panel1.Controls.Add(this.bloodlabel);
            this.panel1.Controls.Add(this.blood);
            this.panel1.Controls.Add(this.startlabel);
            this.panel1.Controls.Add(this.start);
            this.panel1.Controls.Add(this.namelabel);
            this.panel1.Controls.Add(this.name);
            this.panel1.Controls.Add(this.agelabel);
            this.panel1.Controls.Add(this.age);
            this.panel1.Controls.Add(this.sexlabel);
            this.panel1.Controls.Add(this.sex);
            this.panel1.Controls.Add(this.idLabel);
            this.panel1.Controls.Add(this.id);
            this.panel1.Location = new System.Drawing.Point(261, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(382, 370);
            this.panel1.TabIndex = 20;
            // 
            // xiugai
            // 
            this.xiugai.AutoSize = true;
            this.xiugai.Cursor = System.Windows.Forms.Cursors.Hand;
            this.xiugai.Font = new System.Drawing.Font("新宋体", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.xiugai.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.xiugai.Location = new System.Drawing.Point(301, 347);
            this.xiugai.Name = "xiugai";
            this.xiugai.Size = new System.Drawing.Size(71, 15);
            this.xiugai.TabIndex = 12;
            this.xiugai.Text = "编辑资料";
            this.xiugai.Click += new System.EventHandler(this.xiugai_Click);
            // 
            // bloodlabel
            // 
            this.bloodlabel.AutoSize = true;
            this.bloodlabel.Font = new System.Drawing.Font("幼圆", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bloodlabel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.bloodlabel.Location = new System.Drawing.Point(194, 266);
            this.bloodlabel.Name = "bloodlabel";
            this.bloodlabel.Size = new System.Drawing.Size(0, 19);
            this.bloodlabel.TabIndex = 11;
            // 
            // blood
            // 
            this.blood.AutoSize = true;
            this.blood.Font = new System.Drawing.Font("幼圆", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.blood.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.blood.Location = new System.Drawing.Point(89, 266);
            this.blood.Name = "blood";
            this.blood.Size = new System.Drawing.Size(49, 19);
            this.blood.TabIndex = 10;
            this.blood.Text = "血型";
            // 
            // startlabel
            // 
            this.startlabel.AutoSize = true;
            this.startlabel.Font = new System.Drawing.Font("幼圆", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.startlabel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.startlabel.Location = new System.Drawing.Point(195, 226);
            this.startlabel.Name = "startlabel";
            this.startlabel.Size = new System.Drawing.Size(0, 16);
            this.startlabel.TabIndex = 9;
            // 
            // start
            // 
            this.start.AutoSize = true;
            this.start.Font = new System.Drawing.Font("幼圆", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.start.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.start.Location = new System.Drawing.Point(89, 226);
            this.start.Name = "start";
            this.start.Size = new System.Drawing.Size(49, 19);
            this.start.TabIndex = 8;
            this.start.Text = "星座";
            // 
            // namelabel
            // 
            this.namelabel.AutoSize = true;
            this.namelabel.Font = new System.Drawing.Font("幼圆", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.namelabel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.namelabel.Location = new System.Drawing.Point(194, 186);
            this.namelabel.Name = "namelabel";
            this.namelabel.Size = new System.Drawing.Size(0, 19);
            this.namelabel.TabIndex = 7;
            // 
            // name
            // 
            this.name.AutoSize = true;
            this.name.Font = new System.Drawing.Font("幼圆", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.name.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.name.Location = new System.Drawing.Point(69, 186);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(89, 19);
            this.name.TabIndex = 6;
            this.name.Text = "真实姓名";
            // 
            // agelabel
            // 
            this.agelabel.AutoSize = true;
            this.agelabel.Font = new System.Drawing.Font("幼圆", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.agelabel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.agelabel.Location = new System.Drawing.Point(194, 146);
            this.agelabel.Name = "agelabel";
            this.agelabel.Size = new System.Drawing.Size(0, 19);
            this.agelabel.TabIndex = 5;
            // 
            // age
            // 
            this.age.AutoSize = true;
            this.age.Font = new System.Drawing.Font("幼圆", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.age.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.age.Location = new System.Drawing.Point(89, 146);
            this.age.Name = "age";
            this.age.Size = new System.Drawing.Size(49, 19);
            this.age.TabIndex = 4;
            this.age.Text = "年龄";
            // 
            // sexlabel
            // 
            this.sexlabel.AutoSize = true;
            this.sexlabel.Font = new System.Drawing.Font("幼圆", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.sexlabel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.sexlabel.Location = new System.Drawing.Point(194, 104);
            this.sexlabel.Name = "sexlabel";
            this.sexlabel.Size = new System.Drawing.Size(0, 19);
            this.sexlabel.TabIndex = 3;
            // 
            // sex
            // 
            this.sex.AutoSize = true;
            this.sex.Font = new System.Drawing.Font("幼圆", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.sex.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.sex.Location = new System.Drawing.Point(89, 106);
            this.sex.Name = "sex";
            this.sex.Size = new System.Drawing.Size(49, 19);
            this.sex.TabIndex = 2;
            this.sex.Text = "性别";
            // 
            // idLabel
            // 
            this.idLabel.AutoSize = true;
            this.idLabel.Font = new System.Drawing.Font("幼圆", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.idLabel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.idLabel.Location = new System.Drawing.Point(194, 66);
            this.idLabel.Name = "idLabel";
            this.idLabel.Size = new System.Drawing.Size(0, 19);
            this.idLabel.TabIndex = 1;
            // 
            // id
            // 
            this.id.AutoSize = true;
            this.id.Font = new System.Drawing.Font("幼圆", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.id.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.id.Location = new System.Drawing.Point(89, 66);
            this.id.Name = "id";
            this.id.Size = new System.Drawing.Size(49, 19);
            this.id.TabIndex = 0;
            this.id.Text = "账号";
            // 
            // touxiang
            // 
            this.touxiang.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.touxiang.Cursor = System.Windows.Forms.Cursors.Hand;
            this.touxiang.Image = global::QQ_piracy.Properties.Resources.Mask3;
            this.touxiang.Location = new System.Drawing.Point(28, 308);
            this.touxiang.Name = "touxiang";
            this.touxiang.Size = new System.Drawing.Size(60, 60);
            this.touxiang.TabIndex = 21;
            this.touxiang.TabStop = false;
            this.touxiang.Click += new System.EventHandler(this.touxiang_Click);
            // 
            // nickLabel
            // 
            this.nickLabel.AutoSize = true;
            this.nickLabel.Font = new System.Drawing.Font("幼圆", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.nickLabel.Location = new System.Drawing.Point(101, 315);
            this.nickLabel.MaximumSize = new System.Drawing.Size(130, 0);
            this.nickLabel.Name = "nickLabel";
            this.nickLabel.Size = new System.Drawing.Size(56, 16);
            this.nickLabel.TabIndex = 22;
            this.nickLabel.Text = "label4";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox2.BackgroundImage")));
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox2.Location = new System.Drawing.Point(215, 245);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(49, 45);
            this.pictureBox2.TabIndex = 23;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // PersonalInfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(645, 370);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.nickLabel);
            this.Controls.Add(this.touxiang);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.min);
            this.Controls.Add(this.close);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PersonalInfoForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PersonalInfoForm";
            this.TransparencyKey = System.Drawing.SystemColors.MenuHighlight;
            this.Load += new System.EventHandler(this.PersonalInfoForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.touxiang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        //this.pictureBox1.MouseMove += PictureBox1_MouseMove;
        //this.panel1.MouseMove += PictureBox1_MouseMove;

        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        [DllImport("user32.dll")]
        public static extern bool SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);

        private void PictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            //常量
            int WM_SYSCOMMAND = 0x0112;

            //窗体移动
            int SC_MOVE = 0xF010;
            int HTCAPTION = 0x0002;

            ReleaseCapture();
            SendMessage(this.Handle, WM_SYSCOMMAND, SC_MOVE + HTCAPTION, 0);
        }

        #endregion

        private System.Windows.Forms.Button min;
        private System.Windows.Forms.Button close;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label agelabel;
        private System.Windows.Forms.Label age;
        private System.Windows.Forms.Label sexlabel;
        private System.Windows.Forms.Label sex;
        private System.Windows.Forms.Label idLabel;
        private System.Windows.Forms.Label id;
        private System.Windows.Forms.Label bloodlabel;
        private System.Windows.Forms.Label blood;
        private System.Windows.Forms.Label startlabel;
        private System.Windows.Forms.Label start;
        private System.Windows.Forms.Label namelabel;
        private System.Windows.Forms.Label name;
        private System.Windows.Forms.Label xiugai;
        private System.Windows.Forms.PictureBox touxiang;
        private System.Windows.Forms.Label nickLabel;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}