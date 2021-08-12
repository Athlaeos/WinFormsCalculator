using System.Drawing;

namespace VitaeCalculator.Controls
{
    public class PercentageButton : CalcButton
    {
        public PercentageButton(string name, Point position, Size size) : base(name, position, size)
        {
        }

        public override void OnClick(CalcLayout layout)
        {
            Form1.Mode = Form1.Mode.Equals(CalcMode.Regular) ? CalcMode.Percentage : CalcMode.Regular;
            Form1.GetForm().UpdateWindow();
        }
    }
}