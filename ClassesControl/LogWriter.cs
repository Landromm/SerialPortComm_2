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

        public void WriteData(string data, string nameFile)
        {
            try
            {                
                using (StreamWriter sw = File.AppendText(pathLogData + nameFile))
                {
                    sw.WriteLine(DateTime.Now.ToString() + "| DATA | " + data);
                }                
            }
            catch (Exception ex)
            {                
                using (StreamWriter sw = File.AppendText(pathLogData + "_ErrorWrite.txt"))
                {
                    sw.WriteLine(DateTime.Now.ToString() + "| ERROR | " + ex.Message);
                }                
            }
        }

        public void WriteError(string error)
        {
            try
            {
                using (StreamWriter sw = File.AppendText(pathLogInformaiion + "_Error.txt"))
                {
                    sw.WriteLine(DateTime.Now.ToString() + "| ERROR | " + error);
                }
            }
            catch (Exception ex)
            {
                using (StreamWriter sw = File.AppendText(pathLogInformaiion + "_ErrorWrite.txt"))
                {
                    sw.WriteLine(DateTime.Now.ToString() + "| ERROR | " + ex.Message);
                }
            }
        }

        public void WriteInformation(string info)
        {
            try
            {
                using (StreamWriter sw = File.AppendText(pathLogInformaiion + ".txt"))
                {
                    sw.WriteLine(DateTime.Now.ToString() + "| INFO | " + info);
                }
            }
            catch (Exception ex)
            {
                using (StreamWriter sw = File.AppendText(pathLogInformaiion + "_ErrorWrite.txt"))
                {
                    sw.WriteLine(DateTime.Now.ToString() + "| INFO | " + ex.Message);
                }
            }
        }

    }
}
