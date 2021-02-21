namespace QQ_piracy.Model
{
    using System.Drawing;
    using System.Windows.Forms;

    public class MyColorTable : ProfessionalColorTable
    {
        public override Color MenuItemSelected
        {
            get { return Color.FromArgb(59, 58, 61); }
        }

        public override Color MenuItemBorder
        {
            get { return Color.FromArgb(59, 58, 61); }
        }

        public override Color MenuBorder
        {
            get { return Color.FromArgb(59, 58, 61); }
        }
    }
}
