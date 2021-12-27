using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SerialPortComm.ClassesControl;

namespace SerialPortComm.Frames
{
    public partial class FormComSettings : Form
    {
        CommunicationManager comm = new CommunicationManager();

        public FormComSettings()
        {
            InitializeComponent();
        }

        private void LoadValues()
        {
            comm.SetPortNameValues(cbPortName);
            comm.SetParityValues(cbParity);
            comm.SetStopBitValues(cbStopBits);
        }

        private void FormComSettings_Load(object sender, EventArgs e)
        {
            LoadValues();
            InitializeValues();
        }

        private void InitializeValues()
        {
            try
            {
                IniFile INI = new IniFile(@ConfigurationManager.AppSettings["pathConfig"]);
                ComplianceCheck(INI.ReadINI("COMportSettings", "PortName"), cbPortName);
                //cbPortName.SelectedIndex = 0;
                ComplianceCheck(INI.ReadINI("COMportSettings", "BaudRate"), cbBaudRate);
                ComplianceCheck(INI.ReadINI("COMportSettings", "Parity"), cbParity);
                ComplianceCheck(INI.ReadINI("COMportSettings", "StopBits"), cbStopBits);
                ComplianceCheck(INI.ReadINI("COMportSettings", "DataBits"), cbDataBits);
                tbTimeout.Text = INI.ReadINI("COMportSettings", "Timeout");
                rbHex.Checked = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка чтения config.ini файла!\n" + ex,
                                "Ошибка !");                
            }
        }
        private void ComplianceCheck(string param, ComboBox comboBox)
        {
            foreach (string str in comboBox.Items)
            {
                if (param.Equals(str))
                    comboBox.SelectedItem = param;
                else
                    comboBox.SelectedItem = "";
            }
        }

        private void BtnSaveTextBox_Click(object sender, EventArgs e)
        {
            try
            {
                IniFile INI = new IniFile(@ConfigurationManager.AppSettings["pathConfig"]);
                INI.WriteINI("COMportSettings", "PortName", cbPortName.SelectedItem.ToString());
                INI.WriteINI("COMportSettings", "BaudRate", cbBaudRate.SelectedItem.ToString());
                INI.WriteINI("COMportSettings", "Parity", cbParity.SelectedItem.ToString());
                INI.WriteINI("COMportSettings", "StopBits", cbStopBits.SelectedItem.ToString());
                INI.WriteINI("COMportSettings", "DataBits", cbDataBits.SelectedItem.ToString());
                INI.WriteINI("COMportSettings", "Timeout", tbTimeout.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка чтения config.ini файла, при записи!\n" + ex,
                                "Ошибка !");
            }
        }

        private void btnResetTextBox_Click(object sender, EventArgs e)
        {
            cbPortName.SelectedIndex = 0;
            cbBaudRate.SelectedIndex = 0;
            cbParity.SelectedIndex = 0;
            cbStopBits.SelectedIndex = 1;
            cbDataBits.SelectedIndex = 3;
            tbTimeout.Text = "500";
        }
    }
}
