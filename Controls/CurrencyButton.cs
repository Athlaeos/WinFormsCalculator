using System.Drawing;

namespace VitaeCalculator.Controls
{
    public class CurrencyButton : CalcButton
    {
        public CurrencyButton(string name, Point position, Size size) : base(name, position, size)
        {
        }

        public override void OnClick(CalcLayout layout)
        {
            Form1.Mode = Form1.Mode.Equals(CalcMode.Regular) ? CalcMode.Currencies : CalcMode.Regular;
            Form1.GetForm().UpdateWindow();
        }
    }
}