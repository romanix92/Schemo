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
            And2 tst = new And2("1");
            tst.InitPorts();
            tst.in1.AcceptSignal(Signal.HIGH);
            tst.in2.AcceptSignal(Signal.LOW);
            Scheduler.Instance.Execute();
            Console.WriteLine(tst.out1.Signal.ToString());
            Scheduler.Instance.Execute();
            Console.WriteLine(tst.out1.Signal.ToString());
            Scheduler.Instance.Execute();
            Console.WriteLine(tst.out1.Signal.ToString());
            Scheduler.Instance.Execute();
            Console.WriteLine(tst.out1.Signal.ToString());
            Scheduler.Instance.Execute();
            Console.WriteLine(tst.out1.Signal.ToString());
            Scheduler.Instance.Execute();
            Console.WriteLine(tst.out1.Signal.ToString());
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
