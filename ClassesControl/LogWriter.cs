using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerialPortComm.ClassesControl
{
    class LogWriter
    {
        string pathLogData = @ConfigurationManager.AppSettings["pathLogData"] + DateTime.Now.ToString("dd_MM_yyyy");
        string pathLogInformaiion = @ConfigurationManager.AppSettings["pathLogInfo"] + DateTime.Now.ToString("dd_MM_yyyy");

        public LogWriter()
        {
            if (!Directory.Exists(@ConfigurationManager.AppSettings["pathLogData"])) 
            {
                Directory.CreateDirectory(@ConfigurationManager.AppSettings["pathLogData"]);
            }
            if (!Directory.Exists(@ConfigurationManager.AppSettings["pathLogInfo"]))
            {
                Directory.CreateDirectory(@ConfigurationManager.AppSettings["pathLogInfo"]);
            }
        }

        public void TestOutConsole()
        {
            Console.WriteLine(pathLogData);
            Console.WriteLine(pathLogInformaiion);
        }

        public  void WriteData(string data, string nameFile)
        {
            try
            {
                if (!File.Exists(pathLogData + nameFile))
                {
                    using (StreamWriter sw = new StreamWriter(pathLogData + nameFile, false, Encoding.Default))
                    {
                         sw.WriteLineAsync(DateTime.Now.ToString() + "| " + data);
                    }
                }
                else
                {
                    using (StreamWriter sw = new StreamWriter(pathLogData + nameFile, true, Encoding.Default))
                    {
                         sw.WriteLineAsync(DateTime.Now.ToString() + "| " + data);
                    }
                }
            }
            catch (Exception ex)
            {
                if (!File.Exists(pathLogInformaiion))
                {
                    using (StreamWriter sw = new StreamWriter(pathLogInformaiion, false, Encoding.Default))
                    {
                         sw.WriteLineAsync(DateTime.Now.ToString() + "| " + ex.Message);
                    }
                }
                else 
                {
                    using (StreamWriter sw = new StreamWriter(pathLogInformaiion, true, Encoding.Default))
                    {
                         sw.WriteLineAsync(DateTime.Now.ToString() + "| " + ex.Message);
                    }
                }
            }
        }


    }
}
