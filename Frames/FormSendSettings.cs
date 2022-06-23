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
    public partial class FormSendSettings : Form
    {
        public FormSendSettings()
        {
            InitializeComponent();
        }

        private void FormSendSettings_Load(object sender, EventArgs e)
        {
            try
            {
                IniFile INI = new IniFile(@ConfigurationManager.AppSettings["pathConfig"]);
                tb_DozaNow.Text = INI.ReadINI("HexStringToSend", "hex_DozaNow");
                tb_MassFlow.Text = INI.ReadINI("HexStringToSend", "hex_MassFlow");
                tb_VolumeFlow.Text = INI.ReadINI("HexStringToSend", "hex_VolumeFlow");
                tb_Temperature.Text = INI.ReadINI("HexStringToSend", "hex_Temperature");
                tb_RoH2O.Text = INI.ReadINI("HexStringToSend", "hex_RoH2O");
                tb_DozaNow_2.Text = INI.ReadINI("HexStringToSend", "hex_DozaNow_2");
                tb_MassFlow_2.Text = INI.ReadINI("HexStringToSend", "hex_MassFlow_2");
                tb_VolumeFlow_2.Text = INI.ReadINI("HexStringToSend", "hex_VolumeFlow_2");
                tb_Temperature_2.Text = INI.ReadINI("HexStringToSend", "hex_Temperature_2");
                tb_RoH2O_2.Text = INI.ReadINI("HexStringToSend", "hex_RoH2O_2");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка чтения config.ini файла!\n" + ex,
                                "Ошибка !");
            }
        }

        private void BtnResetTextBox_Click(object sender, EventArgs e)
        {
            tb_DozaNow.Clear();
            tb_MassFlow.Clear();
            tb_VolumeFlow.Clear();
            tb_Temperature.Clear();
            tb_RoH2O.Clear();
            tb_DozaNow_2.Clear();
            tb_MassFlow_2.Clear();
            tb_VolumeFlow_2.Clear();
            tb_Temperature_2.Clear();
            tb_RoH2O_2.Clear();
        }

        private void BtnSaveTextBox_Click(object sender, EventArgs e)
        {
            try
            {
                IniFile INI = new IniFile(@ConfigurationManager.AppSettings["pathConfig"]);
                INI.WriteINI("HexStringToSend", "hex_DozaNow", tb_DozaNow.Text);
                INI.WriteINI("HexStringToSend", "hex_MassFlow", tb_MassFlow.Text);
                INI.WriteINI("HexStringToSend", "hex_VolumeFlow", tb_VolumeFlow.Text);
                INI.WriteINI("HexStringToSend", "hex_Temperature", tb_Temperature.Text);
                INI.WriteINI("HexStringToSend", "hex_RoH2O", tb_RoH2O.Text);
                INI.WriteINI("HexStringToSend", "hex_DozaNow_2", tb_DozaNow_2.Text);
                INI.WriteINI("HexStringToSend", "hex_MassFlow_2", tb_MassFlow_2.Text);
                INI.WriteINI("HexStringToSend", "hex_VolumeFlow_2", tb_VolumeFlow_2.Text);
                INI.WriteINI("HexStringToSend", "hex_Temperature_2", tb_Temperature_2.Text);
                INI.WriteINI("HexStringToSend", "hex_RoH2O_2", tb_RoH2O_2.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка чтения config.ini файла, при записи!\n" + ex,
                                "Ошибка !");
            }
        }
    }
}
