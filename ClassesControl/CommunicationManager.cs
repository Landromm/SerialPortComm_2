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
            if (comPort.IsOpen && !comPort.BreakState)
                return true;
            else
                return false;
        }

        #region HexToByte
        /// <summary>
        /// method to convert hex string into a byte array
        /// </summary>
        /// <param name="msg">string to convert</param>
        /// <returns>a byte array</returns>
        private byte[] HexToByte(string msg)
        {
            msg = msg.Replace(" ", "");
            byte[] comBuffer = new byte[msg.Length / 2];
            for (int i = 0; i < msg.Length; i += 2)
                comBuffer[i / 2] = (byte)Convert.ToByte(msg.Substring(i, 2), 16);
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
                _displayWindow_Rch.AppendText(msg);
                _displayWindow_Rch.ScrollToCaret();
            }));
        }

        [STAThread]
        private void DisplayData_Tb(string msg)
        {
            _displayWindow_Tb_Answer.Invoke(new EventHandler(delegate
            {
                _displayWindow_Tb_Answer.Text = msg;
                _displayWindow_Tb_Answer.ScrollToCaret();
            }));
        }
        [STAThread]
        private void DisplayData_Tb_Send(string msg)
        {
            _displayWindow_Tb_Send.Invoke(new EventHandler(delegate
            {
                _displayWindow_Tb_Send.Text = msg;
                _displayWindow_Tb_Send.ScrollToCaret();
            }));
        }
        #endregion

        public string ErrorBreakState()
        {
            return comPort.BreakState.ToString();
        }

        #region OpenPort
        public bool OpenPort()
        {
            try
            {                
                if (comPort.IsOpen) comPort.Close();
                comPort.BaudRate = int.Parse(_baudRate);    //BaudRate
                comPort.DataBits = int.Parse(_dataBits);    //DataBits
                comPort.StopBits = (StopBits)Enum.Parse(typeof(StopBits), _stopBits);    //StopBits
                comPort.Parity = (Parity)Enum.Parse(typeof(Parity), _parity);    //Parity
                comPort.PortName = _portName;   //PortName
                comPort.ReadTimeout = 500;
                comPort.Open();

                DisplayData_Rch("COM-порт открыт в |" + DateTime.Now + "|\n");
                return true;
            }
            catch (Exception ex)
            {
                DisplayData_Rch(ex.Message + "\n");
                return false;
            }
        }
        #endregion

        public bool ClosePort()
        {
            try
            {
                if (comPort.IsOpen == true || comPort.BreakState)
                {
                    comPort.BreakState = false;
                    comPort.Close();
                }
                DisplayData_Rch("COM-порт закрыт в |" + DateTime.Now + "|\n");
                //return true
                return true;
            }
            catch (Exception ex)
            {
                DisplayData_Rch(ex.Message + "\n");
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

        #region WriteData
        public void WriteData(string msg)
        {
            switch (CurrentTransmissionType)
            {
                case TransmissionType.Text:
                    if (!(comPort.IsOpen == true)) comPort.Open();
                    comPort.Write(msg);
                    DisplayData_Rch(msg + "\n");
                    break;
                case TransmissionType.Hex:
                    try
                    {  
                        if (!(comPort.IsOpen == true)) comPort.Open();
                        byte[] newMsg = HexToByte(msg);
                        comPort.Write(newMsg, 0, newMsg.Length);
                        DisplayData_Tb_Send(msg);
                    }
                    catch (FormatException ex)
                    {
                        DisplayData_Rch(ex.Message);
                        byte[] newMsg = HexToByte(msg);
                        DisplayData_Rch(ByteToHex(newMsg) + "\n");
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
                    DisplayData_Tb(msg);
                    break;
                //user chose binary
                case TransmissionType.Hex:
                    if (!comPort.BreakState)
                    {
                        int bytes = comPort.BytesToRead;
                        byte[] comBuffer = new byte[bytes];
                        comPort.Read(comBuffer, 0, bytes);
                        DisplayData_Tb(ByteToHex(comBuffer) + "\n");
                    }
                    break;
                default:
                    string str = comPort.ReadExisting();
                    DisplayData_Tb(str);
                    break;
            }
        }
        #endregion
    }
}
