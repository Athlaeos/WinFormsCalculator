using System.Collections.ObjectModel;
using System.Drawing;
using System.Windows.Forms;

namespace VitaeCalculator.Controls
{
    public class MinusButton : CalcButton
    {
        public MinusButton(string name, Point position, Size size) : base(name, position, size)
        {
        }

        public override void OnClick(CalcLayout box)
        {
            var textBox = (TextBox) box.GetRegisteredTextBoxes()["ioBox"].GetControl();
            if (IllegalCharacters.Contains(Utils.GetCharBeforeCaret(textBox))) return;
            var selectionStartBefore = textBox.SelectionStart;
            textBox.Text = textBox.Text.Insert(textBox.SelectionStart, "-");
            textBox.SelectionStart = selectionStartBefore + 1;
        }
    }
}