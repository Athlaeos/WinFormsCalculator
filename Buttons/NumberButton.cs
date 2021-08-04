using System;
using System.Drawing;
using System.Windows.Forms;

namespace VitaeCalculator.Buttons
{
    public class NumberButton : CalcButton
    {
        private readonly int _number;
        
        public NumberButton(int number, string name, Point position, Size size) : base(name, position, size)
        {
            _number = number;
        }

        public override void OnClick(TextBox box)
        {
            var selectionStartBefore = box.SelectionStart;
            box.Text = box.Text.Insert(box.SelectionStart, "" + _number);
            box.SelectionStart = selectionStartBefore + 1;
        }
    }
}