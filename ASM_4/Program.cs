using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ASM_4
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            frmMaintainBooks form1 = new frmMaintainBooks();
            Color slateBlue = Color.FromName("SlateBlue");
            form1.BackColor = slateBlue;
            Application.Run(new frmMaintainBooks());
        }
    }
}
