using System;
using System.Windows.Forms;

namespace VitaeCalculator
{
    public class Utils
    {
        public static char GetCharBeforeCaret(TextBox b)
        {
            if (b == null) return ' ';
            var lastChar = ' ';
            if (b.Text.Length > 0) lastChar = b.Text.ToCharArray()[Math.Max(0, b.SelectionStart - 1)];
            return lastChar;
        }
        
        
    }
}