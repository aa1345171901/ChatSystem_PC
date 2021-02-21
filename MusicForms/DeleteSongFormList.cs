namespace QQ_piracy.MusicForms
{
    using System;
    using System.IO;
    using System.Windows.Forms;
    using Microsoft.VisualBasic.FileIO;

    public partial class DeleteSongFormList : Form
    {
        private string filePath;

        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteSongFormList"/> class.
        /// 设置删除的路径，确定是否删除本地文件
        /// </summary>
        public DeleteSongFormList(string path)
        {
            InitializeComponent();
            filePath = path;
        }

        public bool ReturnIsDelete { get; set; }

        private void btnYes_Click(object sender, EventArgs e)
        {
            ReturnIsDelete = true;
            if (cbIsDeleteLocalFile.Checked == true)
            {
                // 删除本地文件
                DeleteLocalFile();
            }

            DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ReturnIsDelete = false;
            DialogResult = DialogResult.Cancel;
        }

        private void DeleteLocalFile()
        {
            try
            {
                if (File.Exists(filePath))
                {
                    FileSystem.DeleteFile(filePath, UIOption.OnlyErrorDialogs, RecycleOption.SendToRecycleBin);
                }
                else
                {
                    MessageBox.Show("文件不存在");
                }
            }
            catch (Exception)
            {
            }
        }
    }
}
