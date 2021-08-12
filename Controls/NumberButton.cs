using System;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Windows.Forms;

namespace VitaeCalculator.Controls
{
    public class NumberButton : CalcButton
    {
        private readonly int _number;
        
        public NumberButton(int number, string name, Point position, Size size) : base(name, position, size)
        {
            _number = number;
        }

        public override void OnClick(CalcLayout box)
        {
            var textBox = (TextBox) box.GetRegisteredTextBoxes()["ioBox"].GetControl();
            var selectionStartBefore = textBox.SelectionStart;
            textBox.Text = textBox.Text.Insert(textBox.SelectionStart, _number.ToString());
            textBox.SelectionStart = selectionStartBefore + 1;
        }
    }
}