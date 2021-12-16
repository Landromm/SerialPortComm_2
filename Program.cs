using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using SerialPortComm.ClassesControl;

namespace SerialPortComm
{
    static class Program
    {


        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmMain());

            //AppDomain.CurrentDomain.ProcessExit += new EventHandler(CurrentDomain_ProcessExit);
            // do some work
        }

        // Событие закрытия приложения.
        static void CurrentDomain_ProcessExit(object sender, EventArgs e)
        {
            LogWriter logWriter = new LogWriter();
            logWriter.WriteInformation("ЗАКРЫТИЕ приложения.");
        }
    }
}
