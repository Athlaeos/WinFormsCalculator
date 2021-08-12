using System.Drawing;
using VitaeCalculator.Buttons;
using VitaeCalculator.Controls;

namespace VitaeCalculator.Layouts
{
    public class RegularCalculatorLayout : CalcLayout
    {
        public RegularCalculatorLayout()
        {
            RegisterButton(new NumberButton(1, "1", new Point(15, 75), new Size(65, 35)));
            RegisterButton(new NumberButton(2, "2", new Point(85, 75), new Size(65, 35)));
            RegisterButton(new NumberButton(3, "3", new Point(155, 75), new Size(65, 35)));
            RegisterButton(new NumberButton(4, "4", new Point(15, 115), new Size(65, 35)));
            RegisterButton(new NumberButton(5, "5", new Point(85, 115), new Size(65, 35)));
            RegisterButton(new NumberButton(6, "6", new Point(155, 115), new Size(65, 35)));
            RegisterButton(new NumberButton(7, "7", new Point(15, 155), new Size(65, 35)));
            RegisterButton(new NumberButton(8, "8", new Point(85, 155), new Size(65, 35)));
            RegisterButton(new NumberButton(9, "9", new Point(155, 155), new Size(65, 35)));
            RegisterButton(new NumberButton(0, "0", new Point(85, 195), new Size(65, 35)));
            RegisterButton(new AddButton("+", new Point(225, 75), new Size(45, 35)));
            RegisterButton(new MinusButton("-", new Point(275, 75), new Size(45, 35)));
            RegisterButton(new TimesButton("x", new Point(225, 115), new Size(45, 35)));
            RegisterButton(new DivisionButton("/", new Point(275, 115), new Size(45, 35)));
            RegisterButton(new EqualsButton("=", new Point(225, 235), new Size(100, 35)));
            RegisterButton(new BracketButton("()", new Point(225, 155), new Size(45, 35)));
            RegisterButton(new ClearButton("C", new Point(275, 155), new Size(45, 35)));
            RegisterButton(new CurrencyButton("€",new Point(15, 235), new Size(65, 35)));
            RegisterButton(new PercentageButton("%",new Point(155, 235), new Size(65, 35)));

            RegisterTextBox(new CalculatorTextBox("ioBox", new Point(15, 15), new Size(305, 45)));
        }
    }
}