using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Text;
using System.Reflection;
using SerialPortComm.Frames;
using System.Configuration;
using SerialPortComm.ClassesControl;
using System.Threading;
using System.Windows.Threading;

namespace SerialPortComm
{
    public partial class frmMain : Form
    {
        PrivateFontCollection fontCollection = new PrivateFontCollection();
        LogWriter logWriter = new LogWriter();
        CommunicationManager comm = new CommunicationManager();

        bool checkedViewDozaNow;
        bool checkedViewMassFlow;
        bool checkedViewVolumeFlow;
        bool checkedViewTemperature;
        bool checkedViewRoH2O;
        bool timeOut = true;
        //--------------------------
        string temp_PortName;
        string temp_BaudRate;
        string temp_Parity;
        string temp_StopBits;
        string temp_DataBits;
        //--------------------------
        string tempHex_Temperature;
        string tempHex_DozaNow;
        string tempHex_MassFlow;
        string tempHex_VolumeFlow;
        string tempHex_RoH2O;
        string hex_answer;
        //--------------------------
        string tempHex_Temperature_2;
        string tempHex_DozaNow_2;
        string tempHex_MassFlow_2;
        string tempHex_VolumeFlow_2;
        string tempHex_RoH2O_2;
        string hex_answer_2;
        //--------------------------

        int restart_TimeOut = 2500;
        int temp_Timeout = 500; 
        int coutData = 1;

        public frmMain()
        {
            InitializeComponent();
            try
            {
                fontCollection.AddFontFile(@ConfigurationManager.AppSettings["digital-7"]); // файл шрифта
                fontCollection.AddFontFile(@ConfigurationManager.AppSettings["digital-7_mono"]); // файл шрифта
                DataFileWriter dataFileWriter = new DataFileWriter();
                dataFileWriter.WriterDataFile_ExitOpen();
            }
            catch (Exception ex)
            {
                logWriter.WriteError(ex.Message);
                MessageBox.Show("Ошибка чтения шрифтов!\n" + ex,
                                "Ошибка !");
            }
            notifyIcon.Visible = false;
            // добавляем Эвент или событие по 2му клику мышки, 
            //вызывая функцию  notifyIcon1_MouseDoubleClick
            this.notifyIcon.MouseDoubleClick += new MouseEventHandler(notifyIcon_MouseDoubleClick);

            // добавляем событие на изменение окна
            this.Resize += new System.EventHandler(this.Form1_Resize);
        }



        #region All Method's (Методы формы)

        private void Form1_Resize(object sender, EventArgs e)
        {
            // проверяем наше окно, и если оно было свернуто, делаем событие        
            if (WindowState == FormWindowState.Minimized)
            {
                // прячем наше окно из панели
                this.ShowInTaskbar = false;
                // делаем нашу иконку в трее активной
                notifyIcon.Visible = true;
            }
        }

        // Инициализация шрифта для "цифровых" значений.
        private FontFamily fontFamilySelected(int index)
        {
            FontFamily family = fontCollection.Families[0];
            FontFamily familyMono = fontCollection.Families[1];

            if (index == 0)
                return family;
            else if (index == 1)
                return familyMono;
            else
                return family;
        }

        // Считываем параметры COM порта с файла конфигурации.
        private void ParamFromConfiguration_Load()
        {
            try
            {
                IniFile INI = new IniFile(@ConfigurationManager.AppSettings["pathConfig"]);
                temp_PortName = INI.ReadINI("COMportSettings", "PortName");
                temp_BaudRate = INI.ReadINI("COMportSettings", "BaudRate");
                temp_Parity = INI.ReadINI("COMportSettings", "Parity");
                temp_StopBits = INI.ReadINI("COMportSettings", "StopBits");
                temp_DataBits = INI.ReadINI("COMportSettings", "DataBits");
                temp_Timeout = int.Parse(INI.ReadINI("COMportSettings", "Timeout"));
                tempHex_Temperature = INI.ReadINI("HexStringToSend", "hex_Temperature");
                tempHex_DozaNow = INI.ReadINI("HexStringToSend", "hex_DozaNow");
                tempHex_MassFlow = INI.ReadINI("HexStringToSend", "hex_MassFlow");
                tempHex_VolumeFlow = INI.ReadINI("HexStringToSend", "hex_VolumeFlow");
                tempHex_RoH2O = INI.ReadINI("HexStringToSend", "hex_RoH2O");
                tempHex_Temperature_2 = INI.ReadINI("HexStringToSend", "hex_Temperature_2");
                tempHex_DozaNow_2 = INI.ReadINI("HexStringToSend", "hex_DozaNow_2");
                tempHex_MassFlow_2 = INI.ReadINI("HexStringToSend", "hex_MassFlow_2");
                tempHex_VolumeFlow_2 = INI.ReadINI("HexStringToSend", "hex_VolumeFlow_2");
                tempHex_RoH2O_2 = INI.ReadINI("HexStringToSend", "hex_RoH2O_2");
                hex_answer = INI.ReadINI("HexStringToSend", "hex_answer");
                hex_answer_2 = INI.ReadINI("HexStringToSend", "hex_answer_2");
            }
            catch (Exception ex)
            {
                logWriter.WriteError(ex.Message);
                MessageBox.Show("Ошибка чтения config.ini файла!\n" + ex,
                                "Ошибка !");
            }
        }

        #region FlafRestartApp
        /// <summary>
        /// Метод определения флага рестарта программы.
        /// </summary>
        private bool FlagRestartBool()
        {
            IniFile INI = new IniFile(@ConfigurationManager.AppSettings["pathConfig"]);
            return bool.Parse(INI.ReadINI("RestartFlag", "flag"));
        }
        /// <summary>
        /// Метод чтение флага рестарта программы.
        /// </summary>
        private void FlagRestartON()
        {
            IniFile INI = new IniFile(@ConfigurationManager.AppSettings["pathConfig"]);
            INI.WriteINI("RestartFlag", "flag", "true");
        }
        /// <summary>
        /// Метод записи флага рестарта программы.
        /// </summary>
        private void FlagRestartOFF()
        {
            IniFile INI = new IniFile(@ConfigurationManager.AppSettings["pathConfig"]);
            INI.WriteINI("RestartFlag", "flag", "false");
        }
        #endregion

        #region ConverterToFlout
        // Метод считывания текста с поля вывода результата
        private string FilterString(String text)
        {
            if ((text.Contains(hex_answer) || text.Contains(hex_answer_2)) && text.Length <= 23)
                return text.Trim()
                            .Replace(".", "")
                            .Replace("\n", "")
                            .Replace(" ", "");
            else
                return string.Empty;
        }
        // Метод конвертации полученного ответа из COM-порта (4 байта) в значение с плавающей запятой.
        private void FloutConverter(string str, Label labelResult)
        {
            string strTempHex = FilterString(str);
            if ((strTempHex.Contains(hex_answer) || strTempHex.Contains(hex_answer_2)) && (strTempHex.Length == 22))
            {
                strTempHex = strTempHex.Replace(hex_answer, "").Replace(hex_answer_2, "");
                int j = 3;
                byte[] byteOrigin = ToByteArray(strTempHex.Substring(0, 8));
                byte[] byteReverce = new byte[4];

                for (int i = 0; i < byteOrigin.Length; i++)
                {
                    byteReverce[i] = byteOrigin[j];
                    j--;
                }
                labelResult.Text = BitConverter.ToSingle(byteReverce, 0).ToString();
            }
        }
        #endregion

        #region ToByteArray Convert.
        // Метод конвертации 4-ых полученных hex в байты.
        public static byte[] ToByteArray(String HexString)
        {
            int NumberChars = HexString.Length;
            byte[] bytes = new byte[NumberChars / 2];
            for (int i = 0; i < NumberChars; i += 2)
            {
                bytes[i / 2] = Convert.ToByte(HexString.Substring(i, 2), 16);
            }
            return bytes;
        }
        #endregion

        #region Wait TimeOut
        // Методы реализации задержки отображения без блокировки потока пользовательского интерфейса.
        public static void Wait(int interval)
        {
            ExecuteWait(() => Thread.Sleep(interval));
        }
        public static void ExecuteWait(Action action)
        {
            var waitFrame = new DispatcherFrame();
            // Use callback to "pop" dispatcher frame
            IAsyncResult op = action.BeginInvoke(dummy => waitFrame.Continue = false, null);
            // this method will block here but window messages are pumped
            Dispatcher.PushFrame(waitFrame);
            // this method may throw if the action threw. caller responsibility to handle.
            action.EndInvoke(op);
        }
        #endregion

        // Метод инициализации элементов на форме.
        private void AutoActivate()
        {
            ParamFromConfiguration_Load();

            lbValuePort.Text = temp_PortName;
            lbValueBaudRate.Text = temp_BaudRate;
            lbValueParity.Text = temp_Parity;
            lbValueStopBits.Text = temp_StopBits;
            lbValueDataBits.Text = temp_DataBits;

            try
            {
                IniFile INI = new IniFile(@ConfigurationManager.AppSettings["pathConfig"]);
                checkedViewDozaNow = bool.Parse(INI.ReadINI("CheckedViewDataValue", "DozaNow"));
                checkedViewMassFlow = bool.Parse(INI.ReadINI("CheckedViewDataValue", "MassFlow"));
                checkedViewVolumeFlow = bool.Parse(INI.ReadINI("CheckedViewDataValue", "VolumeFlow"));
                checkedViewTemperature = bool.Parse(INI.ReadINI("CheckedViewDataValue", "Temperature"));
                checkedViewRoH2O = bool.Parse(INI.ReadINI("CheckedViewDataValue", "RoH2O"));
                restart_TimeOut = int.Parse(INI.ReadINI("RestartFlag", "timeOutRestart"));
            }
            catch (Exception ex)
            {
                logWriter.WriteError(ex.Message);
                MessageBox.Show("Ошибка чтения config.ini файла!\n" + ex,
                                "Ошибка !");
            }
            LoadCheckedViewData(checkedViewDozaNow, panel_DozaNow);
            LoadCheckedViewData(checkedViewMassFlow, panel_MassFlow);
            LoadCheckedViewData(checkedViewVolumeFlow, panel_VolumeFlow);
            LoadCheckedViewData(checkedViewTemperature, panel_Temperature);
            LoadCheckedViewData(checkedViewRoH2O, panel_RoH2O);
            LoadCheckedViewData(checkedViewDozaNow, panel_DozaNow_2);
            LoadCheckedViewData(checkedViewMassFlow, panel_MassFlow_2);
            LoadCheckedViewData(checkedViewVolumeFlow, panel_VolumeFlow_2);
            LoadCheckedViewData(checkedViewTemperature, panel_Temperature_2);
            LoadCheckedViewData(checkedViewRoH2O, panel_RoH2O_2);

            Console.WriteLine("Обновление главного экрана!");
        }

        // Метод проверки отображения панели.
        private void LoadCheckedViewData(bool tempBool, Panel panel)
        {
            if (tempBool)
                panel.Visible = true;
            else
                panel.Visible = false;
        }

        // Метод открытия COM-порта.
        private void OpenComPort()
        {
            timeOut = true;
            comm.Parity = temp_Parity;
            comm.StopBits = temp_StopBits;
            comm.DataBits = temp_DataBits;
            comm.BaudRate = temp_BaudRate;
            comm.PortName = temp_PortName;
            comm.CurrentTransmissionType = CommunicationManager.TransmissionType.Hex;
            comm.DisplayWindow_Rch = rchbLogInfo;
            comm.DisplayWindow_Tb_Answer = tbAnswerData;
            comm.DisplayWindow_TbSend = tbSendHex;
            comm.OpenPort();
            if (comm.ComPortIsOpen())
            {
                BtnOpenPort.Visible = false;
                btnStartSend.Visible = true;
                btnClosePort.Visible = true;
                btnMenu.Enabled = false;
                logWriter.WriteInformation("Параметры COM-порта:\n" +
                     "Четность: " + temp_Parity + "\n" +
                     "Стоповые биты: " + temp_StopBits + "\n" +
                     "Биты данных: " + temp_DataBits + "\n" +
                     "Бит в секунду: " + temp_BaudRate + "\n" +
                     "Таймаут: " + temp_Timeout + "\n");
            }
        }

        // Метод закрытия COM-порта.
        private void CloseComPort()
        {
            timeOut = false;
            Wait(1500);
            comm.ClosePort();

            if (!comm.ComPortIsOpen())
            {
                DataFileWriter dataFileWriter = new DataFileWriter();
                BtnOpenPort.Visible = true;
                btnStartSend.Visible = false;
                btnClosePort.Visible = false;
                btnMenu.Enabled = true;
                Console.WriteLine("Закрытие COM-порта!!!");
                dataFileWriter.WriterDataFile_ExitOpen();                
            }
        }

        // Метод рестарта приложения.
        private void RestartApp()
        {
            FlagRestartON();
            System.Diagnostics.Process.Start(Application.ExecutablePath); // to start new instance of application
            logWriter.WriteInformation("----------РЕСТАРТ ПРИЛОЖЕНИЯ!----------");
            this.Close(); //to turn off current app
        }

        // Метод отправки запроса и чтение параметра, отображаеммого элемента данных.
        private void SendSingleDataCOM(string tempHex, Label lbDataValue)
        {
            tbAnswerData.Clear();
            comm.WriteData(tempHex);
            Wait(temp_Timeout);
            //Console.Write(coutData + ". " + lbDataValue.Text + " Package: " + tbAnswerData.Text);
            //rchbLogInfo.AppendText(coutData + ". Температура: " + lbDataValue.Text + " Package: " + tbAnswerData.Text);
            coutData++;
        }

        // Метод отправки запросов и чтение ответа от счетчика РСМ по COM-порту.
        private void SendDataCOM()
        {
            btnStartSend.Visible = false;
            rchbLogInfo.AppendText("Начата отправка запросов на получение данных от счетчика РСМ-05. |" + DateTime.Now + "|\n");
            while (timeOut)
            {
                // --------------------------------------------- Счетчик №1
                if (panel_Temperature.Visible && timeOut)
                {
                    if (comm.ComPortIsOpen() && timeOut)
                    {
                        SendSingleDataCOM(tempHex_Temperature, lbDataValue_Temperature);
                    }
                    else
                    {
                        RestartApp();
                        break;
                    }
                }
                if (panel_DozaNow.Visible && timeOut)
                {
                    if (comm.ComPortIsOpen() && timeOut)
                    {
                        SendSingleDataCOM(tempHex_DozaNow, lbDataValue_DozaNow);
                    }
                    else
                    {
                        RestartApp();
                        break;
                    }
                }
                if (panel_MassFlow.Visible && timeOut)
                {
                    if (comm.ComPortIsOpen() && timeOut)
                    {
                        SendSingleDataCOM(tempHex_MassFlow, lbDataValue_MassFlow);
                    }
                    else
                    {
                        RestartApp();
                        break;
                    }
                }
                if (panel_VolumeFlow.Visible && timeOut)
                {
                    if (comm.ComPortIsOpen() && timeOut)
                    {
                        SendSingleDataCOM(tempHex_VolumeFlow, lbDataValue_VolumeFlow);
                    }
                    else
                    {
                        RestartApp();
                        break;
                    }
                }
                if (panel_RoH2O.Visible && timeOut)
                {
                    if (comm.ComPortIsOpen() && timeOut)
                    {
                        SendSingleDataCOM(tempHex_RoH2O, lbDataValue_RoH2O);
                    }
                    else
                    {
                        RestartApp();
                        break;
                    }
                }

                // --------------------------------------------- Счетчик №2
                if (panel_Temperature_2.Visible && timeOut)
                {
                    if (comm.ComPortIsOpen() && timeOut)
                    {
                        SendSingleDataCOM(tempHex_Temperature_2, lbDataValue_Temperature_2);
                    }
                    else
                    {
                        RestartApp();
                        break;
                    }
                }
                if (panel_DozaNow_2.Visible && timeOut)
                {
                    if (comm.ComPortIsOpen() && timeOut)
                    {
                        SendSingleDataCOM(tempHex_DozaNow_2, lbDataValue_DozaNow_2);
                    }
                    else
                    {
                        RestartApp();
                        break;
                    }
                }
                if (panel_MassFlow_2.Visible && timeOut)
                {
                    if (comm.ComPortIsOpen() && timeOut)
                    {
                        SendSingleDataCOM(tempHex_MassFlow_2, lbDataValue_MassFlow_2);
                    }
                    else
                    {
                        RestartApp();
                        break;
                    }
                }
                if (panel_VolumeFlow_2.Visible && timeOut)
                {
                    if (comm.ComPortIsOpen() && timeOut)
                    {
                        SendSingleDataCOM(tempHex_VolumeFlow_2, lbDataValue_VolumeFlow_2);
                    }
                    else
                    {
                        RestartApp();
                        break;
                    }
                }
                if (panel_RoH2O_2.Visible && timeOut)
                {
                    if (comm.ComPortIsOpen() && timeOut)
                    {
                        SendSingleDataCOM(tempHex_RoH2O_2, lbDataValue_RoH2O_2);
                    }
                    else
                    {
                        RestartApp();
                        break;
                    }
                }
            }
        }

        private void WriterEnableDataSCADA()
        {
            DataFileWriter dataFileWriter = new DataFileWriter();
            if (tbAnswerData.Text != string.Empty)
            {
                //------------------------------- Счетчик №1
                if (checkedViewTemperature)
                    dataFileWriter.Temperature = lbDataValue_Temperature.Text;
                if (checkedViewMassFlow)
                    dataFileWriter.MassFlow = lbDataValue_MassFlow.Text;
                if (checkedViewVolumeFlow)
                    dataFileWriter.VolumFlow = lbDataValue_VolumeFlow.Text;
                if (checkedViewDozaNow)
                    dataFileWriter.Doza = lbDataValue_DozaNow.Text;
                if (checkedViewRoH2O)
                    dataFileWriter.RoH2O1 = lbDataValue_RoH2O.Text;
                //------------------------------- Счетчик №2
                if (checkedViewTemperature)
                    dataFileWriter.Temperature_2 = lbDataValue_Temperature_2.Text;
                if (checkedViewMassFlow)
                    dataFileWriter.MassFlow_2 = lbDataValue_MassFlow_2.Text;
                if (checkedViewVolumeFlow)
                    dataFileWriter.VolumFlow_2 = lbDataValue_VolumeFlow_2.Text;
                if (checkedViewDozaNow)
                    dataFileWriter.Doza_2 = lbDataValue_DozaNow_2.Text;
                if (checkedViewRoH2O)
                    dataFileWriter.RoH2O1_2 = lbDataValue_RoH2O_2.Text;

                dataFileWriter.WriterDataFile();
            }
        }
        #endregion

        //----------------↑--------------
        //------------- МЕТОДЫ ----------
        //-------------------------------
        //------------ СОБЫТИЯ ----------
        //----------------↓--------------

        #region Evant's (Событие формы)

        // Событие нициализации элементов и автоматического запуска запрос\чтение параметров.
        private void frmMain_Activated(object sender, EventArgs e)
        {
            AutoActivate();
            logWriter.LoadFlagLog();
            if (FlagRestartBool())
            {
                FlagRestartOFF();
                Wait(restart_TimeOut);
                OpenComPort();
                SendDataCOM();
            }
        }

        // Событие загрузки формы.
        private void frmMain_Load(object sender, EventArgs e)
        {
            // Присвоение шрифта для "цифровых" значений.
            lbDataValue_DozaNow.Font = new Font(fontFamilySelected(1), 24);
            lbDataValue_VolumeFlow.Font = new Font(fontFamilySelected(1), 24);
            lbDataValue_Temperature.Font = new Font(fontFamilySelected(1), 24);
            lbDataValue_MassFlow.Font = new Font(fontFamilySelected(1), 24);
            lbDataValue_RoH2O.Font = new Font(fontFamilySelected(1), 24);
            lbDataValue_DozaNow_2.Font = new Font(fontFamilySelected(1), 24);
            lbDataValue_VolumeFlow_2.Font = new Font(fontFamilySelected(1), 24);
            lbDataValue_Temperature_2.Font = new Font(fontFamilySelected(1), 24);
            lbDataValue_MassFlow_2.Font = new Font(fontFamilySelected(1), 24);
            lbDataValue_RoH2O_2.Font = new Font(fontFamilySelected(1), 24);
            rchbLogInfo.Clear();
            logWriter.WriteInformation("Запуск приложения!");
        }

        // Событие кнопки "Menu".
        private void btnMenu_Click(object sender, EventArgs e)
        {
            MainForm mainForm = new MainForm();
            logWriter.WriteInformation("Вход в меню приложения.");
            mainForm.ShowDialog();
        }

        // Событие кнопки "Open Port"
        private void BtnOpenPort_Click(object sender, EventArgs e)
        {
            OpenComPort();
        }

        // Событие кнопки "Close Port"
        private void BtnClosePort_Click(object sender, EventArgs e)
        {
            CloseComPort();
        }

        // Собыите кнопки "Start Send".
        private void BtnStartSend_Click(object sender, EventArgs e)
        {
            logWriter.WriteInformation("Инициализирована отправка запросов к счетчику.");
            SendDataCOM();
        }

        // Событие изменения TexBox, который получает ответ из COM-порта.
        // Производит запись преобразованных ответов в Label's на форме.
        private void TbAnswerData_TextChanged(object sender, EventArgs e)
        {
            //------------------------------- Счетчик №1
            if (tbSendHex.Text.Equals(tempHex_DozaNow))
            {
                FloutConverter(tbAnswerData.Text, lbDataValue_DozaNow);
                logWriter.WriteData(lbDataValue_DozaNow.Text, "_Doza.txt");
            }
            else if (tbSendHex.Text.Equals(tempHex_MassFlow))
            {
                FloutConverter(tbAnswerData.Text, lbDataValue_MassFlow);
                logWriter.WriteData(lbDataValue_MassFlow.Text, "_MassFlow.txt");
            }
            else if (tbSendHex.Text.Equals(tempHex_Temperature))
            {            
                FloutConverter(tbAnswerData.Text, lbDataValue_Temperature);
                logWriter.WriteData(lbDataValue_Temperature.Text, "_Temperature.txt");
            }
            else if (tbSendHex.Text.Equals(tempHex_VolumeFlow))
            {
                FloutConverter(tbAnswerData.Text, lbDataValue_VolumeFlow);
                logWriter.WriteData(lbDataValue_VolumeFlow.Text, "_VolumeFlow.txt");
            }

            else if (tbSendHex.Text.Equals(tempHex_RoH2O))
            {
                FloutConverter(tbAnswerData.Text, lbDataValue_RoH2O);
                logWriter.WriteData(lbDataValue_RoH2O.Text, "_RoH2O.txt");
            }

            //------------------------------- Счетчик №1
            if (tbSendHex.Text.Equals(tempHex_DozaNow_2))
            {
                FloutConverter(tbAnswerData.Text, lbDataValue_DozaNow_2);
                logWriter.WriteData(lbDataValue_DozaNow_2.Text, "_Doza_2.txt");
            }
            else if (tbSendHex.Text.Equals(tempHex_MassFlow_2))
            {
                FloutConverter(tbAnswerData.Text, lbDataValue_MassFlow_2);
                logWriter.WriteData(lbDataValue_MassFlow_2.Text, "_MassFlow_2.txt");
            }
            else if (tbSendHex.Text.Equals(tempHex_Temperature_2))
            {
                FloutConverter(tbAnswerData.Text, lbDataValue_Temperature_2);
                logWriter.WriteData(lbDataValue_Temperature_2.Text, "_Temperature_2.txt");
            }
            else if (tbSendHex.Text.Equals(tempHex_VolumeFlow_2))
            {
                FloutConverter(tbAnswerData.Text, lbDataValue_VolumeFlow_2);
                logWriter.WriteData(lbDataValue_VolumeFlow_2.Text, "_VolumeFlow_2.txt");
            }

            else if (tbSendHex.Text.Equals(tempHex_RoH2O_2))
            {
                FloutConverter(tbAnswerData.Text, lbDataValue_RoH2O_2);
                logWriter.WriteData(lbDataValue_RoH2O_2.Text, "_RoH2O_2.txt");
            }

            WriterEnableDataSCADA();
        }

        // Событие закрытия главной формы.
        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            DataFileWriter dataFileWriter = new DataFileWriter();
            dataFileWriter.WriterDataFile_ExitOpen();
            logWriter.WriteInformation("ЗАКРЫТИЕ приложения.");
        }

        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            // делаем нашу иконку скрытой
            notifyIcon.Visible = false;
            // возвращаем отображение окна в панели
            this.ShowInTaskbar = true;
            //разворачиваем окно
            WindowState = FormWindowState.Normal;
        }

        #endregion

    }
}
