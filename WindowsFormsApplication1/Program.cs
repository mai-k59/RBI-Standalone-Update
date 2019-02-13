using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

using RBI.PRE.subForm;
using RBI.PRE.subForm.InputDataForm;
using DevExpress.XtraSplashScreen;

namespace RBI
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
            //Application.Run(new test());
            Application.Run(new RibbonForm1());
        }
    }
}
