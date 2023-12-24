using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ArrayList a = new ArrayList();
            a.Add("A"); a.Add("B");
            a.Reverse();

            var files=new System.IO.DirectoryInfo(@"C:\Users\Liaquat\Documents\Resume").GetFiles("*.pdf");


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
