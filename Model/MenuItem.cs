namespace QQ_piracy.Model
{
    using System;
    using System.Drawing;

    public class MenuItem
    {
        private Image img;
        private string text;

        public MenuItem(Image img, string text)
        {
            this.img = img;
            this.text = text;
        }

        public Image Img { get => img; set => img = value; }

        public string Text { get => text; set => text = value; }
    }
}
