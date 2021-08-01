using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VitaeCalculator
{
    public partial class Form1 : Form
    {
        private Button[] buttons;

        public Form1()
        {
            buttons = new Button[] {
                createButton("1", 0, 0), createButton("2", 1, 0), createButton("3", 2, 0), createButton("+", 3, 0),
                createButton("4", 0, 1), createButton("5", 1, 1), createButton("6", 2, 1), createButton("-", 3, 1),
                createButton("7", 0, 2), createButton("8", 1, 2), createButton("9", 2, 2), createButton("%", 3, 2),
                createButton(",", 0, 3), createButton("0", 1, 3), createButton("*", 2, 3), createButton("€", 3, 3),
                                                                                           createButton("=", 3, 4)};
            InitializeComponent();

            this.Size = new Size(320, 425);
            this.Shown += CreateButtonDelegate;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Console.WriteLine();
        }

        private Button createButton(string name, int x, int y)
        {
            Button b = new Button();
            b.Name = name;
            b.Text = name;
            b.Location = new Point(x * 70 + 15, y * 70 + 60);
            b.Size = new Size(65, 35);
            return b;
        }

        private void CreateButtonDelegate(object sender, EventArgs e)
        {
            foreach (Button b in buttons)
            {
                this.Controls.Add(b);
            }
        }
    }
}
