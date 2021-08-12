using System.Collections.ObjectModel;
using System.Drawing;
using System.Windows.Forms;

namespace VitaeCalculator
{
    public class CalcTextBox
    {
        private Control Control { get; }
        private string Name { get; }
        protected readonly Collection<char> LegalCharacters = new Collection<char>();

        public CalcTextBox(string name, Point position, Size size)
        {
            Name = name;
            
            Control = new TextBox();
            Control.Name = name;
            Control.Size = size;
            Control.Location = position;
        }
        
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