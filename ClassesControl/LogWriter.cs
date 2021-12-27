using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SerialPortComm.ClassesControl
{
    class LogWriter
    {
        string pathLogData = @ConfigurationManager.AppSettings["pathLogData"] + DateTime.Now.ToString("dd_MM_yyyy");
        string pathLogInformaiion = @ConfigurationManager.AppSettings["pathLogInfo"] + DateTime.Now.ToString("dd_MM_yyyy");

        bool tempBoolLogData;
        bool tempBoolLogInfo;
        bool tempBoolHexWriteRead;

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

        public void LoadFlagLog()
        {
            try
            {
                IniFile INI = new IniFile(@ConfigurationManager.AppSettings["pathConfig"]);
                tempBoolLogData = bool.Parse(INI.ReadINI("LogFlag", "logData"));
                tempBoolLogInfo = bool.Parse(INI.ReadINI("LogFlag", "logInfo"));
                tempBoolHexWriteRead = bool.Parse(INI.ReadINI("LogFlag", "logHex"));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка чтения config.ini файла!\n" + ex,
                                "Ошибка !");
            }
        }

        public void HexWriteRead(string data, string nameFile)
        {
            if (tempBoolHexWriteRead)
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
                    WriteData(data, nameFile);
                }
            }
        }

        public void WriteData(string data, string nameFile)
        {
            if (tempBoolLogData)
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
                    WriteData(data, nameFile);
                }
            }
        }

        public void WriteError(string error)
        {
            if (tempBoolLogInfo)
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
                    WriteError(error);
                }
            }
        }

        public void WriteInformation(string info)
        {
            if (tempBoolLogInfo)
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
                    WriteInformation(info);
                }
            }
        }
    }
}
