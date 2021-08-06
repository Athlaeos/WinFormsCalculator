using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace VitaeCalculator.Buttons
{
    public class ClearButton : CalcButton
    {
        public ClearButton(string name, Point position, Size size) : base(name, position, size)
        {
            IllegalCharacters = new Collection<char>();
        }

        public override void OnClick(TextBox box)
        {
            box.Text = box.Text = "";
        }
    }
}