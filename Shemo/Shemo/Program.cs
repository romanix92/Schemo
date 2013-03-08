using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using SchemoCore;

namespace Shemo
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            InOutPort tst = new InOutPort();
            InOutPort tst2 = new InOutPort();
            tst.AddSubscriber(tst2);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
