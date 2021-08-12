using System;
using System.Data;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace VitaeCalculator.Controls
{
    public class BracketButton : CalcButton
    {
        public BracketButton(string name, Point position, Size size) : base(name, position, size)
        {
        }

        public override void OnClick(CalcLayout box)
        {
            var textBox = (TextBox) box.GetRegisteredTextBoxes()["ioBox"].GetControl();
            var selectionStartBefore = textBox.SelectionStart;
            textBox.Text = textBox.Text.Insert(textBox.SelectionStart, "()");
            textBox.SelectionStart = selectionStartBefore + 1;
        }
    }
}