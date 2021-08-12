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

        public override void OnClick(CalcLayout box)
        {
            var textBox = (TextBox) box.GetRegisteredTextBoxes()["ioBox"].GetControl();
            textBox.Text = textBox.Text = "";
        }
    }
}