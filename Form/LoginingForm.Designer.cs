using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace QQ_piracy
{
    partial class LoginingForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginingForm));
            this.giveupButton = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.min = new System.Windows.Forms.Button();
            this.close = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // giveupButton
            // 
            this.giveupButton.BackColor = System.Drawing.Color.Transparent;
            this.giveupButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("giveupButton.BackgroundImage")));
            this.giveupButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.giveupButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.giveupButton.Font = new System.Drawing.Font("方正舒体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.giveupButton.ForeColor = System.Drawing.Color.White;
            this.giveupButton.Location = new System.Drawing.Point(153, 265);
            this.giveupButton.Name = "giveupButton";
            this.giveupButton.Size = new System.Drawing.Size(125, 37);
            this.giveupButton.TabIndex = 13;
            this.giveupButton.Text = "取消";
            this.giveupButton.UseVisualStyleBackColor = false;
            this.giveupButton.Click += new System.EventHandler(this.giveupButton_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(-1, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(427, 328);
            this.pictureBox1.TabIndex = 14;
            this.pictureBox1.TabStop = false;
            // 
            // min
            // 
            this.min.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.min.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.min.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.min.FlatAppearance.BorderSize = 0;
            this.min.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.min.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.min.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.min.Font = new System.Drawing.Font("方正舒体", 15F);
            this.min.ForeColor = System.Drawing.Color.White;
            this.min.Location = new System.Drawing.Point(355, 0);
            this.min.Name = "min";
            this.min.Size = new System.Drawing.Size(35, 33);
            this.min.TabIndex = 12;
            this.min.Text = "-";
            this.min.UseVisualStyleBackColor = false;
            this.min.Click += new System.EventHandler(this.min_Click);
            // 
            // close
            // 
            this.close.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.close.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.close.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.close.FlatAppearance.BorderSize = 0;
            this.close.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.close.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.close.Font = new System.Drawing.Font("方正舒体", 15F);
            this.close.ForeColor = System.Drawing.Color.Transparent;
            this.close.Location = new System.Drawing.Point(391, 0);
            this.close.Name = "close";
            this.close.Size = new System.Drawing.Size(35, 33);
            this.close.TabIndex = 11;
            this.close.Text = "×";
            this.close.UseVisualStyleBackColor = false;
            this.close.Click += new System.EventHandler(this.close_Click);
            // 
            // LoginingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(426, 327);
            this.Controls.Add(this.close);
            this.Controls.Add(this.min);
            this.Controls.Add(this.giveupButton);
            this.Controls.Add(this.pictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LoginingForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LoginingForm";
            this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.Load += new System.EventHandler(this.LoginingForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button giveupButton;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button min;
        private System.Windows.Forms.Button close;
    }
}