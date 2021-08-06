using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace VitaeCalculator.Buttons
{
    public class EqualsButton : CalcButton
    {
        private readonly DataTable _dt = new DataTable();

        private Collection<char> _invalidCharacters = new Collection<char>(new [] { '+', '-', '/', '*'});

        public EqualsButton(string name, Point position, Size size) : base(name, position, size)
        {
        }

        public override void OnClick(TextBox box)
        {
            var lastChar = box.Text.ToCharArray()[box.Text.Length - 1];
            if (_invalidCharacters.Contains(lastChar))
            {
                MessageBox.Show("Expression cannot end with " + lastChar);
            }
            else
            {
                try
                {
                    var v = _dt.Compute(box.Text, "");
                    box.Text = v.ToString();
                    box.SelectionStart = box.Text.Length;
                }
                catch (SyntaxErrorException e)
                {
                    MessageBox.Show("Invalid expression: " + e.Message);
                }
            }
        }
    }
}