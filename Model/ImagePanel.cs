using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QQ_piracy.Model
{
    public class ImagePanel : Panel
    {
        public List<PictureBox> imageList = new List<PictureBox>();
        public List<Label> labelList = new List<Label>();

        public ImagePanel()
        {
            this.DoubleBuffered = true;//设置本窗体
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true); // 禁止擦除背景.
            SetStyle(ControlStyles.DoubleBuffer, true); // 双缓冲
        }

        public ImagePanel(IContainer container)
        {
            container.Add(this);

            this.DoubleBuffered = true;//设置本窗体
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true); // 禁止擦除背景.
            SetStyle(ControlStyles.DoubleBuffer, true); // 双缓冲
        }

        // 到界面再显示，否则只是容器
        public void AddImage(Image img)
        {
            PictureBox pb = new PictureBox();
            pb.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pb).BeginInit();
            pb.Size = new Size(400, 200);
            pb.Padding = new Padding(8);
            pb.Image = img.GetThumbnailImage(400, 200, null, IntPtr.Zero);
            pb.Visible = false;
            imageList.Add(pb);
            // AddLabel();
        }

        /// <summary>
        /// 添加图片时，就添加图片下面的横线，这个需要直接显示，设计时改颜色即可,添加n个图
        /// </summary>
        public void AddLabel(ImagePanel ip, int n)
        {
            int i = n % 2 == 1 ? -(n / 2) - 1 : -(n / 2);
            for (; i < n / 2; i++)
            {
                Label l = new Label();
                l.SuspendLayout();
                l.Size = new Size(20, 2);
                l.Visible = true;
                l.BackColor = Color.Gray;
                int x = 330;
                x += i * 30;
                l.Location = new Point(x, 210);
                ip.Controls.Add(l);
                labelList.Add(l);
            }
        }

        /// <summary>
        /// 给label添加事件
        /// </summary>
        /// <param name="mouseLeave"></param>
        public void AddEvent(EventHandler mouseLeave)
        {
            foreach (var item in labelList)
            {
                item.MouseLeave += mouseLeave;
            }
        }

        /// <summary>
        /// 返回点击的是第几个label
        /// </summary>
        public int GetIndexOfLabel(Label label)
        {
            return labelList.IndexOf(label);
        }

        public void SetBackColor(int index)
        {
            for(int i = 0;i < labelList.Count; i++)
            {
                if (index == i)
                {
                    labelList[i].BackColor = Color.CornflowerBlue;
                }
                else
                {
                    labelList[i].BackColor = Color.Gray;
                }
            }
        }
    }
}
