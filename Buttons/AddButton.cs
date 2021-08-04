using System.Drawing;
using System.Windows.Forms;

namespace VitaeCalculator.Buttons
{
    public class AddButton : CalcButton
    {
        public AddButton(string name, Point position, Size size) : base(name, position, size)
        {
        }

        public override void OnClick(TextBox box)
        {
            box.Text = box.Text.Insert(box.SelectionStart, "+");
        }
    }
}