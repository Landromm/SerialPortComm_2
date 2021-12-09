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
        CommunicationManager comm = new CommunicationManager();

        bool checkedViewDozaNow;
        bool checkedViewMassFlow;
        bool checkedViewVolumeFlow;
        bool checkedViewTemperature;
        bool checkedViewRoH2O;

        string temp_PortName;
        string temp_BaudRate;
        string temp_Parity;
        string temp_StopBits;
        string temp_DataBits;
        string temp_Timeout;
        string tempHex_Temperature;
        string tempHex_DozaNow;
        string tempHex_MassFlow;
        string tempHex_VolumeFlow;
        string tempHex_RoH2O;

        bool timeOut = true;

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

        private void frmMain_Load(object sender, EventArgs e)
        {
            // Присвоение шрифта для "цифровых" значений.
            lbDataValue_DozaNow.Font = new Font(fontFamilySelected(1), 24);
            lbDataValue_VolumeFlow.Font = new Font(fontFamilySelected(1), 24);
            lbDataValue_Temperature.Font = new Font(fontFamilySelected(1), 24);
            lbDataValue_MassFlow.Font = new Font(fontFamilySelected(1), 24);
            lbDataValue_RoH2O.Font = new Font(fontFamilySelected(1), 24);
        }

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
                temp_Timeout = INI.ReadINI("COMportSettings", "Timeout");
                tempHex_Temperature = INI.ReadINI("HexStringToSend", "hex_Temperature");
                tempHex_DozaNow = INI.ReadINI("HexStringToSend", "hex_DozaNow"); ;
                tempHex_MassFlow = INI.ReadINI("HexStringToSend", "hex_MassFlow"); ;
                tempHex_VolumeFlow = INI.ReadINI("HexStringToSend", "hex_VolumeFlow"); ;
                tempHex_RoH2O = INI.ReadINI("HexStringToSend", "hex_RoH2O"); ;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка чтения config.ini файла!\n" + ex,
                                "Ошибка !");
            }
        }

        // Метод кнопки "Menu".
        private void btnMenu_Click(object sender, EventArgs e)
        {
            MainForm mainForm = new MainForm();
            mainForm.ShowDialog();
        }

        private void frmMain_Activated(object sender, EventArgs e)
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

        private void LoadCheckedViewData(bool tempBool, Panel panel)
        {
            if (tempBool)
                panel.Visible = true;
            else
                panel.Visible = false;
        }

        #region ConverterToFlout
        // Метод считывания текста с поля вывода результата
        private string FilterString(String text)
        {
            string result = "";
            //if (testTextFromDisplay.TextLength != 0)
            //    testTextFromDisplay.Clear();
            if (text.Contains("AA01FE0C0104") && text.Length <= 23)
                return result = text.Trim()
                                    .Replace(".", "")
                                    .Replace("\n", "")
                                    .Replace(" ", "");
            else
                return result = string.Empty;
        }
        // Метод конвертации полученного ответа из COM-порта (4 байта) в значение с плавающей запятой.
        private void FloutConverter(string str, Label labelResult)
        {
            string strTempHex = FilterString(str);
            if (strTempHex.Contains("AA01FE0C0104") && (strTempHex.Length == 22))
            {
                strTempHex = strTempHex.Replace("AA01FE0C0104", "");
                Console.WriteLine(strTempHex);

                Console.WriteLine(new string('-', 15));
                Console.WriteLine(strTempHex.Substring(0, 2));
                Console.WriteLine(strTempHex.Substring(2, 2));
                Console.WriteLine(strTempHex.Substring(4, 2));
                Console.WriteLine(strTempHex.Substring(6, 2));
                Console.WriteLine(new string('-', 15));

                int j = 3;
                byte[] byteOrigin = ToByteArray(strTempHex.Substring(0, 8));
                byte[] byteReverce = new byte[4];

                for (int i = 0; i < byteOrigin.Length; i++)
                {
                    byteReverce[i] = byteOrigin[j];
                    j--;
                }

                Console.WriteLine(BitConverter.ToSingle(byteReverce, 0));
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
        public static void ExecuteWait(System.Action action)
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

        private void BtnOpenPort_Click(object sender, EventArgs e)
        {
            comm.Parity = temp_Parity;
            comm.StopBits = temp_StopBits;
            comm.DataBits = temp_DataBits;
            comm.BaudRate = temp_BaudRate;
            comm.PortName = temp_PortName;
            comm.CurrentTransmissionType = CommunicationManager.TransmissionType.Hex;
            comm.DisplayWindow_Rch = rchbLogInfo;
            comm.DisplayWindow_Tb = tbAnswerData;
            comm.DisplayWindow_TbSend = tbSendHex;
            comm.OpenPort();
        }

        private void BtnClosePort_Click(object sender, EventArgs e)
        {
            timeOut = false;
            comm.ClosePort();
        }

        // Метод кнопки "Start Send".
        private void BtnStartSend_Click(object sender, EventArgs e)
        {
            while (timeOut)
            {
                comm.WriteData(tempHex_Temperature);
                Wait(500);

                comm.WriteData(tempHex_DozaNow);
                Wait(500);

                comm.WriteData(tempHex_MassFlow);
                Wait(500);

                comm.WriteData(tempHex_VolumeFlow);
                Wait(500);

                comm.WriteData(tempHex_RoH2O);
                Wait(500);
            }
        }

        private void TbAnswerData_TextChanged(object sender, EventArgs e)
        {
            if(tbSendHex.Text.Equals(tempHex_DozaNow))
                FloutConverter(tbAnswerData.Text, lbDataValue_DozaNow);
            else if(tbSendHex.Text.Equals(tempHex_MassFlow))
                FloutConverter(tbAnswerData.Text, lbDataValue_MassFlow);
            else if(tbSendHex.Text.Equals(tempHex_Temperature))
                FloutConverter(tbAnswerData.Text, lbDataValue_Temperature);
            else if (tbSendHex.Text.Equals(tempHex_VolumeFlow))
                FloutConverter(tbAnswerData.Text, lbDataValue_VolumeFlow);
            else if (tbSendHex.Text.Equals(tempHex_RoH2O))
                FloutConverter(tbAnswerData.Text, lbDataValue_RoH2O);
        }
    }
}
