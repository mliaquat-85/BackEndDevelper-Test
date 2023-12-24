using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{

    public partial class Form1 : Form
    {
        //  Driver code to test above methods
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            var chr = ((char)e.KeyCode).ToString().ToLower();
            if (chr == "r" && e.Control)
            {
                textBox1.Text = textBox1.Text.Replace("\n", "");
                textBox1.Text = textBox1.Text.Replace("\r", "");
                textBox1.Text = textBox1.Text.Replace("\t", " ");

                while (textBox1.Text.Contains("  ")) textBox1.Text = textBox1.Text.Replace("  ", " ");

            }
        }
    }
}
