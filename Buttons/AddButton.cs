﻿using System.Collections.ObjectModel;
using System.Drawing;
using System.Windows.Forms;

namespace VitaeCalculator.Buttons
{
    public class AddButton : CalcButton
    {
        public AddButton(string name, Point position, Size size) : base(name, position, size)
        {
            IllegalCharacters = new Collection<char>(new []{ '/', '*', '(', '+'});
        }

        public override void OnClick(TextBox box)
        {
            var selectionStartBefore = box.SelectionStart;
            box.Text = box.Text.Insert(box.SelectionStart, "+");
            box.SelectionStart = selectionStartBefore + 1;
        }
    }
}