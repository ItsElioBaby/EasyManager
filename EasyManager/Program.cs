using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace EasyManager
{
    public static class Program
    {
         public static Form1 fm1;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            fm1 = new Form1();
            Application.Run(fm1);
        }
    }
}
