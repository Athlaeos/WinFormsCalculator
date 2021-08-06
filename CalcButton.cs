using System.Collections.ObjectModel;
using System.Drawing;
using System.Windows.Forms;

namespace VitaeCalculator
{
    public abstract class CalcButton
    {
        private Control Control { get; }
        private string Name { get; }
        protected Collection<char> IllegalCharacters { get; set; } = new Collection<char>();

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

        public Collection<char> GetIllegalCharacters()
        {
            return IllegalCharacters;
        }
    }
}