using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VitaeCalculator.Buttons;

namespace VitaeCalculator
{
    public partial class Form1 : Form
    {
        private readonly Dictionary<string, CalcButton> _registeredButtons = new Dictionary<string, CalcButton>();
        private readonly TextBox _ioBox = new TextBox();

        public Form1()
        {
            _ioBox.Location = new Point(15, 15);
            _ioBox.Multiline = true;
            _ioBox.Size = new Size(280, 30);
            
            RegisterButton(new NumberButton(1, "1", new Point(15, 60), new Size(65, 35)));
            RegisterButton(new NumberButton(2, "2", new Point(85, 60), new Size(65, 35)));
            RegisterButton(new NumberButton(3, "3", new Point(155, 60), new Size(65, 35)));
            RegisterButton(new NumberButton(4, "4", new Point(15, 110), new Size(65, 35)));
            RegisterButton(new NumberButton(5, "5", new Point(85, 110), new Size(65, 35)));
            RegisterButton(new NumberButton(6, "6", new Point(155, 110), new Size(65, 35)));
            RegisterButton(new NumberButton(7, "7", new Point(15, 160), new Size(65, 35)));
            RegisterButton(new NumberButton(8, "8", new Point(85, 160), new Size(65, 35)));
            RegisterButton(new NumberButton(9, "9", new Point(155, 160), new Size(65, 35)));
            RegisterButton(new NumberButton(0, "0", new Point(85, 210), new Size(65, 35)));
            
            InitializeComponent();

            Size = new Size(320, 345);
            Shown += CreateButtonDelegate;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Console.WriteLine("aaaaa");
        }

        private void RegisterButton(CalcButton b)
        {
            _registeredButtons.Add(b.GetName(), b);
        }

        private void CreateButtonDelegate(object sender, EventArgs e)
        {
            foreach (CalcButton b in _registeredButtons.Values)
            {
                Controls.Add(b.GetControl());
                b.GetControl().Click += ButtonClick;
            }
            Controls.Add(_ioBox);
        }

        private void ButtonClick(object sender, EventArgs args)
        {
            if (sender.GetType() == typeof(Button))
            {
                Button b = (Button)sender;
                CalcButton buttonPressed = _registeredButtons[b.Name];
                if (buttonPressed != null)
                {
                    buttonPressed.OnClick(_ioBox);
                }
            }
        }
    }
}
