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
    public partial class FormLogger : Form
    {
        bool tempBoolDataLog;
        bool tempBoolInfoLog;
        bool tempBoolHexLog;

        public FormLogger()
        {
            InitializeComponent();
            LoadFlagLogger();
        }

        private void ChangedBackColorPanel(CheckBox checkBox, Panel panel)
        {
            if (checkBox.Checked)
                panel.BackColor = Color.FromArgb(128, 255, 128);
            else
                panel.BackColor = Color.FromName("ActiveCaption");
        }

        private void LoadFlagLogger()
        {
            try
            {
                IniFile INI = new IniFile(@ConfigurationManager.AppSettings["pathConfig"]);
                tempBoolDataLog = bool.Parse(INI.ReadINI("LogFlag", "logData"));
                tempBoolInfoLog = bool.Parse(INI.ReadINI("LogFlag", "logInfo"));
                tempBoolHexLog = bool.Parse(INI.ReadINI("LogFlag", "logHex"));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка чтения config.ini файла!\n" + ex,
                                "Ошибка !");
            }
        }

        private void LoadCheckedCheckBox(bool tempBool, CheckBox checkBox)
        {
            if (tempBool)
                checkBox.Checked = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                IniFile INI = new IniFile(@ConfigurationManager.AppSettings["pathConfig"]);
                INI.WriteINI("LogFlag", "logData", chb_LogData.Checked.ToString());
                INI.WriteINI("LogFlag", "logInfo", chb_LogInfo.Checked.ToString());
                INI.WriteINI("LogFlag", "logHex", chb_LogWriteReadHex.Checked.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка чтения config.ini файла, при записи!\n" + ex,
                                "Ошибка !");
            }
        }

        private void chb_LogData_CheckedChanged(object sender, EventArgs e)
        {
            ChangedBackColorPanel(chb_LogData, panel_LogData);
        }

        private void chb_LogInfo_CheckedChanged(object sender, EventArgs e)
        {
            ChangedBackColorPanel(chb_LogInfo, panel_LogInfo);
        }

        private void chb_LogWriteReadHex_CheckedChanged(object sender, EventArgs e)
        {
            ChangedBackColorPanel(chb_LogWriteReadHex, panel_LogWriteReadHex);

        }

        private void FormLogger_Load(object sender, EventArgs e)
        {
            LoadFlagLogger();
            LoadCheckedCheckBox(tempBoolDataLog, chb_LogData);
            LoadCheckedCheckBox(tempBoolInfoLog, chb_LogInfo);
            LoadCheckedCheckBox(tempBoolHexLog, chb_LogWriteReadHex);
        }

    }
}
