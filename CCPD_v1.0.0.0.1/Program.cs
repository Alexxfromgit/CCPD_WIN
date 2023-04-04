using System;
using System.Windows.Forms;

namespace CCPD_v1._0._0._0._1
{
    static class Program
    {
        /// <summary>
        /// Main app entry
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
