using System.Drawing;
using System.Windows.Forms;

namespace VitaeCalculator.Controls
{
    public class CalculatorTextBox : CalcTextBox
    {
        public CalculatorTextBox(string name, Point position, Size size) : base(name, position, size)
        {
            ((TextBox)GetControl()).Multiline = true;
        }
    }
}