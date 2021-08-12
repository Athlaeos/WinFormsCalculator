using System.Collections.Generic;
using System.Windows.Forms;

namespace VitaeCalculator
{
    public abstract class CalcLayout
    {
        private Dictionary<string, CalcButton> RegisteredButtons { get; } = new Dictionary<string, CalcButton>();
        private Dictionary<string, CalcTextBox> RegisteredTextBoxes { get; } = new Dictionary<string, CalcTextBox>();

        protected void RegisterButton(CalcButton b)
        {
            RegisteredButtons.Add(b.GetName(), b);
        }
        
        protected void RegisterTextBox(CalcTextBox b)
        {
            RegisteredTextBoxes.Add(b.GetName(), b);
        }

        public Dictionary<string, CalcButton> GetRegisteredButtons()
        {
            return RegisteredButtons;
        }
        
        public Dictionary<string, CalcTextBox> GetRegisteredTextBoxes()
        {
            return RegisteredTextBoxes;
        }
    }
}