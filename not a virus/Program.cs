using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace not_a_virus
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);

            /*DialogResult dialogResult = MessageBox.Show(null, "Don't worry, this does not do any harm. But you might wanna save everything in case you need to restart your computer. DO YOU WANT TO CONTINUE?", "Note", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.No)
            {
                Environment.Exit(0);
            }*/

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
