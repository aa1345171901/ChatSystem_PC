namespace QQ_piracy
{
    partial class RequestForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RequestForm));
            this.pbFace = new System.Windows.Forms.PictureBox();
            this.systemMsg = new System.Windows.Forms.Label();
            this.userMsg = new System.Windows.Forms.Label();
            this.btnAllow = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SyncTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pbFace)).BeginInit();
            this.SuspendLayout();
            // 
            // pbFace
            // 
            this.pbFace.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbFace.Image = global::QQ_piracy.Properties.Resources.Mask3;
            this.pbFace.Location = new System.Drawing.Point(42, 42);
            this.pbFace.Name = "pbFace";
            this.pbFace.Size = new System.Drawing.Size(60, 60);
            this.pbFace.TabIndex = 0;
            this.pbFace.TabStop = false;
            // 
            // systemMsg
            // 
            this.systemMsg.AutoSize = true;
            this.systemMsg.BackColor = System.Drawing.Color.Transparent;
            this.systemMsg.Font = new System.Drawing.Font("幼圆", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.systemMsg.ForeColor = System.Drawing.Color.DarkSlateBlue;
            this.systemMsg.Location = new System.Drawing.Point(142, 86);
            this.systemMsg.Name = "systemMsg";
            this.systemMsg.Size = new System.Drawing.Size(0, 21);
            this.systemMsg.TabIndex = 1;
            // 
            // userMsg
            // 
            this.userMsg.AutoSize = true;
            this.userMsg.BackColor = System.Drawing.Color.Transparent;
            this.userMsg.Font = new System.Drawing.Font("幼圆", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.userMsg.ForeColor = System.Drawing.SystemColors.ControlText;
            this.userMsg.Location = new System.Drawing.Point(141, 42);
            this.userMsg.Name = "userMsg";
            this.userMsg.Size = new System.Drawing.Size(0, 27);
            this.userMsg.TabIndex = 2;
            // 
            // btnAllow
            // 
            this.btnAllow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAllow.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAllow.BackgroundImage")));
            this.btnAllow.Location = new System.Drawing.Point(300, 153);
            this.btnAllow.Name = "btnAllow";
            this.btnAllow.Size = new System.Drawing.Size(70, 23);
            this.btnAllow.TabIndex = 4;
            this.btnAllow.Text = "同意";
            this.btnAllow.UseVisualStyleBackColor = true;
            this.btnAllow.Click += new System.EventHandler(this.btnAllow_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancel.BackgroundImage")));
            this.btnCancel.Location = new System.Drawing.Point(388, 153);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(70, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // SyncTimer
            // 
            this.SyncTimer.Tick += new System.EventHandler(this.SyncTimer_Tick);
            // 
            // RequestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(468, 188);
            this.Controls.Add(this.btnAllow);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.userMsg);
            this.Controls.Add(this.systemMsg);
            this.Controls.Add(this.pbFace);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "RequestForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "系统消息";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.RequestForm_FormClosed);
            this.Load += new System.EventHandler(this.RequestForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbFace)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pbFace;
        private System.Windows.Forms.Label systemMsg;
        private System.Windows.Forms.Label userMsg;
        private System.Windows.Forms.Button btnAllow;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Timer SyncTimer;
    }
}