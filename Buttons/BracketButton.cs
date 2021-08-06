using System;
using System.Data;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace VitaeCalculator.Buttons
{
    public class BracketButton : CalcButton
    {
        public BracketButton(string name, Point position, Size size) : base(name, position, size)
        {
        }

        public override void OnClick(TextBox box)
        {
            var selectionStartBefore = box.SelectionStart;
            box.Text = box.Text.Insert(box.SelectionStart, "()");
            box.SelectionStart = selectionStartBefore + 1;
        }
    }
}