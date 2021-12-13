using System;
using System.Text;
using System.IO.Ports;
using System.Windows.Forms;


namespace SerialPortComm.ClassesControl
{
    class CommunicationManager
    {
        #region Manager Enums
        /// <summary>
        /// enumeration to hold our transmission types
        /// </summary>
        public enum TransmissionType { Text, Hex }

        ///// <summary>
        ///// enumeration to hold our message types
        ///// </summary>
        //public enum MessageType { Incoming, Outgoing, Normal, Warning, Error };

        ///// <summary>
        /////  Указывает число стоповых битов.
        ///// </summary>
        //public enum StopBitsUsers
        //{
        //    //  Стоповые биты не используются. Это значение не поддерживается свойством System.IO.Ports.SerialPort.StopBits.
        //    Нет = 0,
        //    //  Используется один стоповый бит.
        //    Один = 1,
        //    //  Используются два стоповых бита.
        //    Два = 2,
        //    //  Используется 1,5 стоповых бита.
        //    Полтора = 3
        //}

        ///// <summary>
        /////  Задает бит четности для объекта System.IO.Ports.SerialPort.
        ///// </summary>
        //public enum ParityUsers
        //{            
        //    //  Контроль четности не осуществляется.
        //    Нет = 0,            
        //    //  Устанавливает бит четности так, чтобы число установленных битов всегда было нечетным.
        //    Один = 1,            
        //    //  Устанавливает бит четности так, чтобы число установленных битов всегда было четным.
        //    Два = 2,            
        //    //  Оставляет бит четности равным 1.
        //    Маркер = 3,
        //    //  Оставляет бит четности равным 0.
        //    Пробел = 4
        //}
        #endregion



        #region Manager Variables
        //property variables
        private string _baudRate = string.Empty;
        private string _parity = string.Empty;
        private string _stopBits = string.Empty;
        private string _dataBits = string.Empty;
        private string _portName = string.Empty;
        private TransmissionType _transType;
        private RichTextBox _displayWindow_Rch;
        private TextBox _displayWindow_Tb_Answer;
        private TextBox _displayWindow_Tb_Send;
        //global manager variables
        //private Color[] MessageColor = { Color.Blue, Color.Green, Color.Black, Color.Orange, Color.Red };
        private SerialPort comPort = new SerialPort();
        #endregion

        #region Manager Properties
        /// <summary>
        /// Property to hold the BaudRate
        /// of our manager class
        /// </summary>
        public string BaudRate
        {
            get { return _baudRate; }
            set { _baudRate = value; }
        }

        /// <summary>
        /// property to hold the Parity
        /// of our manager class
        /// </summary>
        public string Parity
        {
            get { return _parity; }
            set { _parity = value; }
        }

        /// <summary>
        /// property to hold the StopBits
        /// of our manager class
        /// </summary>
        public string StopBits
        {
            get { return _stopBits; }
            set { _stopBits = value; }
        }

        /// <summary>
        /// property to hold the DataBits
        /// of our manager class
        /// </summary>
        public string DataBits
        {
            get { return _dataBits; }
            set { _dataBits = value; }
        }

        /// <summary>
        /// property to hold the PortName
        /// of our manager class
        /// </summary>
        public string PortName
        {
            get { return _portName; }
            set { _portName = value; }
        }

        /// <summary>
        /// property to hold our TransmissionType
        /// of our manager class
        /// </summary>
        public TransmissionType CurrentTransmissionType
        {
            get { return _transType; }
            set { _transType = value; }
        }

        /// <summary>
        /// property to hold our display window
        /// value
        /// </summary>
        public RichTextBox DisplayWindow_Rch
        {
            get { return _displayWindow_Rch; }
            set { _displayWindow_Rch = value; }
        }
        public TextBox DisplayWindow_Tb_Answer
        {
            get { return _displayWindow_Tb_Answer; }
            set { _displayWindow_Tb_Answer = value; }
        }
        public TextBox DisplayWindow_TbSend
        {
            get { return _displayWindow_Tb_Send; }
            set { _displayWindow_Tb_Send = value; }
        }
        #endregion

        #region Manager Constructors
        /// <summary>
        /// Constructor to set the properties of our Manager Class
        /// </summary>
        /// <param name="baud">Desired BaudRate</param>
        /// <param name="par">Desired Parity</param>
        /// <param name="sBits">Desired StopBits</param>
        /// <param name="dBits">Desired DataBits</param>
        /// <param name="name">Desired PortName</param>
        public CommunicationManager(string baud, string par, string sBits, string dBits, string name, RichTextBox rtb, TextBox tbAnswer, TextBox tbSend)
        {
            _baudRate = baud;
            _parity = par;
            _stopBits = sBits;
            _dataBits = dBits;
            _portName = name;
            _displayWindow_Rch = rtb;
            _displayWindow_Tb_Answer = tbAnswer;
            _displayWindow_Tb_Send = tbSend;
            //now add an event handler
            comPort.DataReceived += new SerialDataReceivedEventHandler(comPort_DataReceived);
        }

        /// <summary>
        /// Comstructor to set the properties of our
        /// serial port communicator to nothing
        /// </summary>
        public CommunicationManager()
        {
            _baudRate = string.Empty;
            _parity = string.Empty;
            _stopBits = string.Empty;
            _dataBits = string.Empty;
            _portName = "COM1";
            _displayWindow_Rch = null;
            _displayWindow_Tb_Answer = null;
            _displayWindow_Tb_Send = null;
            //add event handler
            comPort.DataReceived += new SerialDataReceivedEventHandler(comPort_DataReceived);
        }
        #endregion

        public bool ComPortIsOpen()
        {
            if (comPort.IsOpen)
                return true;
            else
                return false;
        }

        #region WriteData
        public void WriteData(string msg)
        {
            switch (CurrentTransmissionType)
            {
                case TransmissionType.Text:
                    //first make sure the port is open
                    //if its not open then open it
                    if (!(comPort.IsOpen == true)) comPort.Open();
                    //send the message to the port
                    comPort.Write(msg);
                    //display the message
                    //DisplayData_Rch(msg + "\n");
                    break;
                case TransmissionType.Hex:
                    try
                    {
                        //convert the message to byte array
                        byte[] newMsg = HexToByte(msg);
                        //send the message to the port
                        comPort.Write(newMsg, 0, newMsg.Length);
                        //convert back to hex and display
                        //DisplayData_Rch(ByteToHex(newMsg) + "\n");
                        DisplayData_Tb_Send(msg);
                    }
                    catch (FormatException ex)
                    {
                        //display error message
                        DisplayData_Rch(ex.Message);
                        //convert the message to byte array
                        byte[] newMsg = HexToByte(msg);
                        //send the message to the port
                        comPort.Write(newMsg, 0, newMsg.Length);
                        //convert back to hex and display
                        //DisplayData_Rch(ByteToHex(newMsg) + "\n");
                    }
                    finally
                    {
                        _displayWindow_Tb_Answer.SelectAll();
                    }
                    break;
                default:
                    //first make sure the port is open
                    //if its not open then open it
                    if (!(comPort.IsOpen == true)) comPort.Open();
                    //send the message to the port
                    comPort.Write(msg);
                    //display the message
                    //DisplayData_Rch(msg + "\n");
                    break;
            }
        }
        #endregion

        #region HexToByte
        /// <summary>
        /// method to convert hex string into a byte array
        /// </summary>
        /// <param name="msg">string to convert</param>
        /// <returns>a byte array</returns>
        private byte[] HexToByte(string msg)
        {
            //remove any spaces from the string
            msg = msg.Replace(" ", "");
            //create a byte array the length of the
            //divided by 2 (Hex is 2 characters in length)
            byte[] comBuffer = new byte[msg.Length / 2];
            //loop through the length of the provided string
            for (int i = 0; i < msg.Length; i += 2)
                //convert each set of 2 characters to a byte
                //and add to the array
                comBuffer[i / 2] = (byte)Convert.ToByte(msg.Substring(i, 2), 16);
            //return the array
            return comBuffer;
        }
        #endregion

        #region ByteToHex
        /// <summary>
        /// method to convert a byte array into a hex string
        /// </summary>
        /// <param name="comByte">byte array to convert</param>
        /// <returns>a hex string</returns>
        private string ByteToHex(byte[] comByte)
        {
            //create a new StringBuilder object
            StringBuilder builder = new StringBuilder(comByte.Length * 3);
            //loop through each byte in the array
            foreach (byte data in comByte)
                //convert the byte to a string and add to the stringbuilder
                builder.Append(Convert.ToString(data, 16).PadLeft(2, '0'));
            //return the converted value
            return builder.ToString().ToUpper();
        }
        #endregion

        #region DisplayData
        /// <summary>
        /// method to display the data to & from the port
        /// on the screen
        /// </summary>
        /// <param name="type">MessageType of the message</param>
        /// <param name="msg">Message to display</param>
        [STAThread]
        private void DisplayData_Rch(string msg)
        {
            _displayWindow_Rch.Invoke(new EventHandler(delegate
            {
                //_displayWindow.SelectedText = string.Empty;
                //_displayWindow.SelectionFont = new Font(_displayWindow.SelectionFont, FontStyle.Bold);
                //_displayWindow.SelectionColor = MessageColor[(int)type];
                _displayWindow_Rch.Text = msg;
                _displayWindow_Rch.ScrollToCaret();
            }));
        }

        [STAThread]
        private void DisplayData_Tb(string msg)
        {
            _displayWindow_Tb_Answer.Invoke(new EventHandler(delegate
            {
                //_displayWindow.SelectedText = string.Empty;
                //_displayWindow.SelectionFont = new Font(_displayWindow.SelectionFont, FontStyle.Bold);
                //_displayWindow.SelectionColor = MessageColor[(int)type];
                _displayWindow_Tb_Answer.Text = msg;
                _displayWindow_Tb_Answer.ScrollToCaret();
            }));
        }
        [STAThread]
        private void DisplayData_Tb_Send(string msg)
        {
            _displayWindow_Tb_Send.Invoke(new EventHandler(delegate
            {
                //_displayWindow.SelectedText = string.Empty;
                //_displayWindow.SelectionFont = new Font(_displayWindow.SelectionFont, FontStyle.Bold);
                //_displayWindow.SelectionColor = MessageColor[(int)type];
                _displayWindow_Tb_Send.Text = msg;
                _displayWindow_Tb_Send.ScrollToCaret();
            }));
        }
        #endregion

        #region OpenPort
        public bool OpenPort()
        {
            try
            {
                //first check if the port is already open
                //if its open then close it
                if (comPort.IsOpen == true) comPort.Close();

                //set the properties of our SerialPort Object
                comPort.BaudRate = int.Parse(_baudRate);    //BaudRate
                comPort.DataBits = int.Parse(_dataBits);    //DataBits
                comPort.StopBits = (StopBits)Enum.Parse(typeof(StopBits), _stopBits);    //StopBits
                comPort.Parity = (Parity)Enum.Parse(typeof(Parity), _parity);    //Parity
                comPort.PortName = _portName;   //PortName
                //comPort.ReadTimeout = 500;
                //now open the port
                comPort.Open();
                //display message
                DisplayData_Rch("Port opened at " + DateTime.Now + "\n");
                //return true
                return true;
            }
            catch (Exception ex)
            {
                DisplayData_Rch(ex.Message);
                return false;
            }
        }
        #endregion

        public bool ClosePort()
        {
            try
            {
                if (comPort.IsOpen == true)
                    comPort.Close();
                DisplayData_Rch("Port closed at " + DateTime.Now + "\n");
                //return true
                return true;
            }
            catch (Exception ex)
            {
                DisplayData_Rch(ex.Message);
                return false;
            }
        }

        #region SetParityValues
        public void SetParityValues(object obj)
        {
            foreach (string str in Enum.GetNames(typeof(Parity)))
            {
                ((ComboBox)obj).Items.Add(str);
            }
        }
        #endregion

        #region SetStopBitValues
        public void SetStopBitValues(object obj)
        {
            foreach (string str in Enum.GetNames(typeof(StopBits)))
            {
                ((ComboBox)obj).Items.Add(str);
            }
        }
        #endregion

        #region SetPortNameValues
        public void SetPortNameValues(object obj)
        {

            foreach (string str in SerialPort.GetPortNames())
            {
                ((ComboBox)obj).Items.Add(str);
            }
        }
        #endregion

        #region comPort_DataReceived
        /// <summary>
        /// method that will be called when theres data waiting in the buffer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void comPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            //determine the mode the user selected (binary/string)
            switch (CurrentTransmissionType)
            {
                //user chose string
                case TransmissionType.Text:
                    string msg = comPort.ReadExisting();
                    DisplayData_Tb(msg + "\n");
                    break;
                //user chose binary
                case TransmissionType.Hex:
                    int bytes = comPort.BytesToRead;
                    byte[] comBuffer = new byte[bytes];
                    comPort.Read(comBuffer, 0, bytes);
                    DisplayData_Tb(ByteToHex(comBuffer) + "\n");
                    break;
                default:
                    string str = comPort.ReadExisting();
                    DisplayData_Tb(str + "\n");
                    break;
            }
        }
        #endregion

    }
}
