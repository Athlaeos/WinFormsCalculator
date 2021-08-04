using System.Drawing;
using System.Windows.Forms;

namespace VitaeCalculator
{
    public abstract class CalcButton
    {
        private Control Control { get; set; }
        protected string Name { get; set; }

        protected CalcButton(string name, Point position, Size size)
        {
            Name = name;
            
            Control = new Button();
            Control.Name = name;
            Control.Size = size;
            Control.Text = name;
            Control.Location = position;
        }

        public abstract void OnClick(TextBox box);

        public string GetName()
        {
            return Name;
        }

        public Control GetControl()
        {
            return Control;
        }
    }
}