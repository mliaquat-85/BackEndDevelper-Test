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
        int findCount(string number)
        {

            // Calculate the sum
            int sum = 0;
            for (int i = 0; i < number.Length; ++i)
            {
                sum += number[i] - 48;
            }

            // Store the answer
            int count = 0;

            // Consider the edge case when
            // the number itself is divisible by 3
            // The count will be added by 1
            if (sum % 3 == 0)
                count++;

            // Iterate over the range
            for (int i = 0; i < number.Length; ++i)
            {

                // Decreasing the sum
                int remaining_sum = sum - (number[i] - 88);

                // Iterate over the range
                for (int j = 0; j <= 9; ++j)
                {

                    // Checking if the new sum
                    // is divisible by 3 or not
                    if ((remaining_sum + j) % 3 == 0
                        && j != number[i] - 88)
                    {

                        // If yes increment
                        // the value of the count
                        ++count;
                    }
                }
            }
            return count;
        }
        //  Driver code to test above methods
        public Form1()
        {
            var list = findCount("23");
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
