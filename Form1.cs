using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VitaeCalculator.Buttons;
using VitaeCalculator.Layouts;

namespace VitaeCalculator
{
    public partial class Form1 : Form
    {
        private readonly Dictionary<CalcMode, CalcLayout> _layouts = new Dictionary<CalcMode, CalcLayout>();
        private static Form1 _form;

        public static CalcMode Mode { get; set; } = CalcMode.Regular;

        public Form1()
        {
            _layouts.Add(CalcMode.Regular, new RegularCalculatorLayout());
            _layouts.Add(CalcMode.Currencies, new CurrencyCalculatorLayout());
            _layouts.Add(CalcMode.Percentage, new PercentageCalculatorLayout());

            InitializeComponent();
            UpdateWindow();
            _form = this;
        }

        private void ResizeWindow(int margin)
        {
            int highestX = 0, highestY = 0;
            foreach (var b in _layouts[Mode].GetRegisteredButtons().Values)
            {
                var c = b.GetControl();
                if (c.Location.Y + c.Size.Height >= highestY) highestY = c.Location.Y + c.Size.Height;
                if (c.Location.X + c.Size.Width >= highestX) highestX = c.Location.X + c.Size.Width;
            }
            foreach (var b in _layouts[Mode].GetRegisteredTextBoxes().Values)
            {
                var c = b.GetControl();
                if (c.Location.Y + c.Size.Height >= highestY) highestY = c.Location.Y + c.Size.Height;
                if (c.Location.X + c.Size.Width >= highestX) highestX = c.Location.X + c.Size.Width;
            }
            AutoSize = true;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;

            Size = new Size(highestX + margin, highestY + margin);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        public void UpdateWindow()
        {
            Controls.Clear();

            // Shown += CreateControls;
            foreach (var b in _layouts[Mode].GetRegisteredButtons().Values)
            {
                Controls.Add(b.GetControl());
                b.GetControl().Click -= ButtonClick;
                b.GetControl().Click += ButtonClick;
            }
            foreach (var b in _layouts[Mode].GetRegisteredTextBoxes().Values)
            {
                Controls.Add(b.GetControl());
            }
            ResizeWindow(15);
        }

        private void ButtonClick(object sender, EventArgs args)
        {
            var b = (Button)sender;
            var buttonPressed = _layouts[Mode].GetRegisteredButtons()[b.Name];
            buttonPressed.OnClick(_layouts[Mode]);
        }
        
        public static Form1 GetForm(){
            return _form;
        }
    }
}
