using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace VitaeCalculator.Controls
{
    public class EqualsButton : CalcButton
    {
        private readonly DataTable _dt = new DataTable();

        private readonly Collection<char> _invalidCharacters = new Collection<char>(new [] { '+', '-', '/', '*'});

        public EqualsButton(string name, Point position, Size size) : base(name, position, size)
        {
        }

        public override void OnClick(CalcLayout box)
        {
            var textBox = (TextBox) box.GetRegisteredTextBoxes()["ioBox"].GetControl();
            switch (Form1.Mode)
            {
                case CalcMode.Regular:
                {
                    textBox.SelectionStart = textBox.Text.Length;
                    var lastChar = Utils.GetCharBeforeCaret(textBox);
                    if (_invalidCharacters.Contains(lastChar))
                    {
                        MessageBox.Show("Cannot place " + lastChar + " here");
                    }
                    else
                    {
                        try
                        {
                            var v = _dt.Compute(textBox.Text, "");
                            textBox.Text = v.ToString();
                            textBox.SelectionStart = textBox.Text.Length;
                        }
                        catch (SyntaxErrorException e)
                        {
                            MessageBox.Show("Invalid expression: " + e.Message);
                        }
                    }
                    break;
                }
                case CalcMode.Currencies:
                {
                    try
                    {
                        var exchangeFrom = Double.Parse(box.GetRegisteredTextBoxes()["currencyFrom"].GetControl().Text);
                        var exchangeTo = Double.Parse(box.GetRegisteredTextBoxes()["currencyTo"].GetControl().Text);
                        var multiplyBy = Double.Parse(textBox.Text);

                        var result = exchangeFrom * multiplyBy * exchangeTo;
                        textBox.Text = "" + result;
                        textBox.SelectionStart = textBox.Text.Length;
                    }
                    catch (FormatException)
                    {
                        MessageBox.Show("Invalid double value given");
                    }
                    break;
                }
                case CalcMode.Percentage:
                {
                    var input = textBox.Text.Replace(" ", "");
                    if (input.Contains("*"))
                    {
                        var args = input.Split('*');
                        if (args.Length != 2)
                        {
                            MessageBox.Show("For percentage mode a 'x * y' format is expected");
                            return;
                        }

                        try
                        {
                            var arg1 = Double.Parse(args[0]);
                            var arg2 = Double.Parse(args[1]);
                            var result = arg1 * (arg2 / 100);

                            textBox.Text = $"{arg2}% of {arg1} is {result}";
                        }
                        catch (FormatException)
                        {
                            MessageBox.Show("Invalid numbers entered");
                        }
                    } else if (input.Contains("+"))
                    {
                        var args = input.Split('+');
                        if (args.Length != 2)
                        {
                            MessageBox.Show("For percentage mode a 'x + y' format is expected");
                            return;
                        }

                        try
                        {
                            var arg1 = Double.Parse(args[0]);
                            var arg2 = Double.Parse(args[1]);
                            var result = arg1 * ((100 + arg2) / 100);

                            textBox.Text = $"{100 + arg2}% of {arg1} is {result}";
                        }
                        catch (FormatException)
                        {
                            MessageBox.Show("Invalid numbers entered");
                        }
                    } else if (input.Contains("-"))
                    {
                        var args = input.Split('-');
                        if (args.Length != 2)
                        {
                            MessageBox.Show("For percentage mode a 'x - y' format is expected");
                            return;
                        }

                        try
                        {
                            var arg1 = Double.Parse(args[0]);
                            var arg2 = Double.Parse(args[1]);
                            var result = arg1 * ((100 - arg2) / 100);

                            textBox.Text = $"{100 - arg2}% of {arg1} is {result}";
                        }
                        catch (FormatException)
                        {
                            MessageBox.Show("Invalid numbers entered");
                        }
                    } else if (input.Contains("/"))
                    {
                        var args = input.Split('/');
                        if (args.Length != 2)
                        {
                            MessageBox.Show("For percentage mode a 'x / y' format is expected");
                            return;
                        }

                        try
                        {
                            var arg1 = Double.Parse(args[0]);
                            var arg2 = Double.Parse(args[1]);
                            var result = arg1 / (arg2 / 100);

                            textBox.Text = $"{arg1} divided by {arg2}% is {result}";
                        }
                        catch (FormatException)
                        {
                            MessageBox.Show("Invalid numbers entered");
                        }
                    }
                    else
                    {
                        try
                        {
                            var arg = Double.Parse(input);
                            var result = 1 * (arg / 100);
                            
                            textBox.Text = $"{arg}% compared to 1 is {result}";
                        }
                        catch (FormatException)
                        {
                            MessageBox.Show("Invalid numbers entered");
                        }
                    }
                    break;
                }
            }
        }
    }
}