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
        private string _doza_2 = string.Empty;
        private string _temperature_2 = string.Empty;
        private string _massFlow_2 = string.Empty;
        private string _volumFlow_2 = string.Empty;
        private string _RoH2O_2 = string.Empty;
        private string pathDataFile = string.Empty;
        private string nameDataFile = "TestRSM.txt";

        // ------------------------------- Счетчик №1
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

        // ------------------------------- Счетчик №2
        public string Doza_2
        {
            get => _doza_2;
            set => _doza_2 = value;
        }
        public string Temperature_2
        {
            get => _temperature_2;
            set => _temperature_2 = value;
        }
        public string MassFlow_2
        {
            get => _massFlow_2;
            set => _massFlow_2 = value;
        }
        public string VolumFlow_2
        {
            get => _volumFlow_2;
            set => _volumFlow_2 = value;
        }
        public string RoH2O1_2
        {
            get => _RoH2O_2;
            set => _RoH2O_2 = value;
        }

        private bool flagWriteWithDot = false;

        public DataFileWriter(string doza, string temperature, string massFlow, string volumFlow, string RoH2O,
                            string doza_2, string temperature_2, string massFlow_2, string volumFlow_2, string RoH2O_2)
        {
            _doza = doza;
            _temperature = temperature;
            _massFlow = massFlow;
            _volumFlow = volumFlow;
            _RoH2O = RoH2O;
            _doza_2 = doza_2;
            _temperature_2 = temperature_2;
            _massFlow_2 = massFlow_2;
            _volumFlow_2 = volumFlow_2;
            _RoH2O_2 = RoH2O_2;
            pathDataFile = INI.ReadINI("PathFolderSaveData", "pathFolder") + nameDataFile;
            flagWriteWithDot = bool.Parse(INI.ReadINI("PathFolderSaveData", "writeWithDot"));
        }
        public DataFileWriter()
        {
            _doza = "-1";
            _temperature = "-1";
            _massFlow = "-1";
            _volumFlow = "-1";
            _RoH2O = "-1";
            _doza_2 = "-1";
            _temperature_2 = "-1";
            _massFlow_2 = "-1";
            _volumFlow_2 = "-1";
            _RoH2O_2 = "-1";
            pathDataFile = INI.ReadINI("PathFolderSaveData", "pathFolder") + nameDataFile;
            flagWriteWithDot = bool.Parse(INI.ReadINI("PathFolderSaveData", "writeWithDot"));
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
                        sw.WriteLine(ReturnFormatString(Temperature));
                        sw.WriteLine(ReturnFormatString(MassFlow));
                        sw.WriteLine(ReturnFormatString(VolumFlow));
                        sw.WriteLine(ReturnFormatString(Doza));
                        sw.WriteLine(ReturnFormatString(RoH2O1));
                        sw.WriteLine(ReturnFormatString(Temperature_2));
                        sw.WriteLine(ReturnFormatString(MassFlow_2));
                        sw.WriteLine(ReturnFormatString(VolumFlow_2));
                        sw.WriteLine(ReturnFormatString(Doza_2));
                        sw.WriteLine(ReturnFormatString(RoH2O1_2));
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
                        sw.WriteLine(Temperature_2 = "-1");
                        sw.WriteLine(MassFlow_2 = "-1");
                        sw.WriteLine(VolumFlow_2 = "-1");
                        sw.WriteLine(Doza_2 = "-1");
                        sw.WriteLine(RoH2O1_2 = "-1");
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
