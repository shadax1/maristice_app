using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace maristice_app
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Process[] pname = Process.GetProcessesByName("Maristice");
            //Process[] pname2 = Process.GetProcessesByName("Maristice_e");
            if (pname.Length == 0 /*|| pname2.Length == 0*/)
            {
                try
                {
                    /*DialogResult dialogResult = MessageBox.Show("Launch the game in English?", "Language", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        Process.Start("Maristice_e.exe");
                    }
                    else if (dialogResult == DialogResult.No)
                    {
                        Process.Start("Maristice.exe");
                    }*/
                    Process.Start("Maristice.exe");
                }
                catch (Exception)
                {
                    MessageBox.Show("Maristice.exe wasn't found, make sure the maristice_app.exe AND the 'saves' folder are both in the same location as Maristice.exe.");
                    Environment.Exit(1);
                }
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Mari());
        }
    }
}
