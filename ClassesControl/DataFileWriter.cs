using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using SerialPortComm.ClassesControl;

namespace SerialPortComm.ClassesControl
{
    class DataFileWriter
    {
        IniFile INI = new IniFile(@ConfigurationManager.AppSettings["pathConfig"]);
        LogWriter logWriter = new LogWriter();

        private string _doza = string.Empty;
        private string _temperature = string.Empty;
        private string _massFlow = string.Empty;
        private string _volumFlow = string.Empty;
        private string _RoH2O = string.Empty;
        private string pathDataFile = string.Empty;
        private string nameDataFile = "TestRSM.txt";

        public string Doza 
        { 
            get => _doza; 
            set => _doza = value; 
        }
        public string Temperature 
        { 
            get => _temperature; 
            set => _temperature = value; 
        }
        public string MassFlow 
        { 
            get => _massFlow; 
            set => _massFlow = value; 
        }
        public string VolumFlow 
        { 
            get => _volumFlow; 
            set => _volumFlow = value; 
        }
        public string RoH2O1 
        { 
            get => _RoH2O; 
            set => _RoH2O = value; 
        }

        private bool flagWriteWithDot = false;

        public DataFileWriter(string doza, string temperature, string massFlow, string volumFlow, string RoH2O)
        {
            _doza = doza;
            _temperature = temperature;
            _massFlow = massFlow;
            _volumFlow = volumFlow;
            _RoH2O = RoH2O;
            pathDataFile = INI.ReadINI("PathFolderSaveData", "pathFolder") + nameDataFile;
        }
        public DataFileWriter()
        {
            _doza = "-1";
            _temperature = "-1";
            _massFlow = "-1";
            _volumFlow = "-1";
            _RoH2O = "-1";
            pathDataFile = INI.ReadINI("PathFolderSaveData", "pathFolder") + nameDataFile;
        }

        #region WriteData
        /// <summary>
        /// Метод записи данных в файл для чтения SCADA
        /// </summary>
        /// <param name="temperature">Значение температуры</param>
        /// <param name="massFlow">Значение массового расхода</param>
        /// <param name="volumFlow">Значение объемного расхода</param>
        /// <param name="doza">Значение дозы</param>
        /// <param name="RoH2O">Значение плотности</param>
        public void WriterDataFile()
        {
            try
            {
                if (!File.Exists(@ConfigurationManager.AppSettings["pathConfig"]))
                {
                    File.Create(@pathDataFile);
                }
                else
                {
                    using (StreamWriter sw = new StreamWriter(@pathDataFile, false))
                    {
                        flagWriteWithDot = bool.Parse(INI.ReadINI("PathFolderSaveData", "writeWithDot"));
                        sw.WriteLine(ReturnFormatString(Temperature));
                        sw.WriteLine(ReturnFormatString(MassFlow));
                        sw.WriteLine(ReturnFormatString(VolumFlow));
                        sw.WriteLine(ReturnFormatString(Doza));
                        sw.WriteLine(ReturnFormatString(RoH2O1));
                    }
                }
            }
            catch (Exception ex)
            {
                //logWriter.WriteError("Ошибка записи DataRSM.txt файла!\n" + ex.Message);
                WriterDataFile();
            }
        }

        private string ReturnFormatString(string str)
        {
            return flagWriteWithDot ? str.Replace(',', '.') : str;
        }

        /// <summary>
        /// Метод записи данных в файл для чтения SCADA при закрытии приложения или прекращения его работы. Все параметры равны -1.
        /// </summary>
        /// <param name="temperature">Значение температуры</param>
        /// <param name="massFlow">Значение массового расхода</param>
        /// <param name="volumFlow">Значение объемного расхода</param>
        /// <param name="doza">Значение дозы</param>
        /// <param name="RoH2O">Значение плотности</param>
        public void WriterDataFile_ExitOpen()
        {
            try
            {
                if (!File.Exists(@ConfigurationManager.AppSettings["pathConfig"]))
                {
                    File.Create(@pathDataFile);
                }
                else
                {
                    using (StreamWriter sw = new StreamWriter(@pathDataFile, false))
                    {
                        sw.WriteLine(Temperature = "-1");
                        sw.WriteLine(MassFlow = "-1");
                        sw.WriteLine(VolumFlow = "-1");
                        sw.WriteLine(Doza = "-1");
                        sw.WriteLine(RoH2O1 = "-1");
                    }
                }
            }
            catch (Exception ex)
            {
                logWriter.WriteError("Ошибка записи DataRSM.txt файла!\n" + ex.Message);
                WriterDataFile_ExitOpen();
            }
        }
        #endregion
    }
}
