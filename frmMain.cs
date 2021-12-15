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

        string temp_PortName;
        string temp_BaudRate;
        string temp_Parity;
        string temp_StopBits;
        string temp_DataBits;
        string tempHex_Temperature;
        string tempHex_DozaNow;
        string tempHex_MassFlow;
        string tempHex_VolumeFlow;
        string tempHex_RoH2O;

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
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка чтения шрифтов!\n" + ex,
                                "Ошибка !");
            }
        }

        #region All Method's (Методы формы)

        // Инициализация шррифта для "цифровых" значений.
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
            }
            catch (Exception ex)
            {
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
            if (text.Contains("AA01FE0C0104") && text.Length <= 23)
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
            if (strTempHex.Contains("AA01FE0C0104") && (strTempHex.Length == 22))
            {
                strTempHex = strTempHex.Replace("AA01FE0C0104", "");
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
                MessageBox.Show("Ошибка чтения config.ini файла!\n" + ex,
                                "Ошибка !");
            }
            LoadCheckedViewData(checkedViewDozaNow, panel_DozaNow);
            LoadCheckedViewData(checkedViewMassFlow, panel_MassFlow);
            LoadCheckedViewData(checkedViewVolumeFlow, panel_VolumeFlow);
            LoadCheckedViewData(checkedViewTemperature, panel_Temperature);
            LoadCheckedViewData(checkedViewRoH2O, panel_RoH2O);

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
            }
        }

        // Метод закрытия COM-порта.
        private void CloseComPort()
        {
            timeOut = false;
            comm.ClosePort();

            if (!comm.ComPortIsOpen())
            {
                BtnOpenPort.Visible = true;
                btnStartSend.Visible = false;
                btnClosePort.Visible = false;
                btnMenu.Enabled = true;
                Console.WriteLine("Закрытие COM-порта!!!");
            }
        }

        // Метод рестарта приложения.
        private void RestartApp()
        {
            FlagRestartON();
            System.Diagnostics.Process.Start(Application.ExecutablePath); // to start new instance of application
            this.Close(); //to turn off current app
        }

        // Метод отправки запроса и чтение параметра, отображаеммого элемента данных.
        private void SendSingleDataCOM(string tempHex, Label lbDataValue)
        {
            comm.WriteData(tempHex);
            Wait(temp_Timeout);
            Console.Write(coutData + ". " + lbDataValue.Text + " Package: " + tbAnswerData.Text);
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
            rchbLogInfo.Clear();
        }

        // Событие кнопки "Menu".
        private void btnMenu_Click(object sender, EventArgs e)
        {
            MainForm mainForm = new MainForm();
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
            SendDataCOM();
        }

        // Событие изменения TexBox, который получает ответ из COM-порта.
        // Производит запись преобразованных ответов в Label's на форме.
        private void TbAnswerData_TextChanged(object sender, EventArgs e)
        {
            if (tbSendHex.Text.Equals(tempHex_DozaNow))
            {
                FloutConverter(tbAnswerData.Text, lbDataValue_DozaNow);
                logWriter.WriteData("Data |" + lbDataValue_DozaNow.Text, "_Doza.txt");
            }
            else if (tbSendHex.Text.Equals(tempHex_MassFlow))
            {
                FloutConverter(tbAnswerData.Text, lbDataValue_MassFlow);
                logWriter.WriteData("Data |" + lbDataValue_MassFlow.Text, "_MassFlow.txt");
            }
            else if (tbSendHex.Text.Equals(tempHex_Temperature))
            {            
                FloutConverter(tbAnswerData.Text, lbDataValue_Temperature);
                logWriter.WriteData("Data |" + lbDataValue_Temperature.Text, "_Temperature.txt");
            }
            else if (tbSendHex.Text.Equals(tempHex_VolumeFlow))
            {
                FloutConverter(tbAnswerData.Text, lbDataValue_VolumeFlow);
                logWriter.WriteData("Data |" + lbDataValue_VolumeFlow.Text, "_VolumeFlow.txt");
            }

            else if (tbSendHex.Text.Equals(tempHex_RoH2O))
            {
                FloutConverter(tbAnswerData.Text, lbDataValue_RoH2O);
                logWriter.WriteData("Data |" + lbDataValue_RoH2O.Text, "_RoH2O.txt");
            }

        }

        #endregion

        private void LbDataValue_DozaNow_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
