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
    public partial class FormGeneralSetting : Form
    {
        bool tempBoolDozaNow;
        bool tempBoolMassFlow;
        bool tempBoolVolumeFlow;
        bool tempBoolTemperature;
        bool tempBoolRoH2O;

        public FormGeneralSetting()
        {
            InitializeComponent();
        }

        private void BtnResetCheckBox_Click(object sender, EventArgs e)
        {
            chb_DozaNow.Checked = false;
            chb_MassFlow.Checked = false;
            chb_VolumeFlow.Checked = false;
            chb_Temperature.Checked = false;
            chb_RoH2O.Checked = false;
        }

        private void BtnSelectAll_Click(object sender, EventArgs e)
        {
            chb_DozaNow.Checked = true;
            chb_MassFlow.Checked = true;
            chb_VolumeFlow.Checked = true;
            chb_Temperature.Checked = true;
            chb_RoH2O.Checked = true;
        }

        private void ChangedBackColorPanel(CheckBox checkBox, Panel panel)
        {
            if (checkBox.Checked)
                panel.BackColor = Color.FromArgb(128, 255, 128);
            else
                panel.BackColor = Color.FromName("ActiveCaption");
        }

        private void Chb_DozaNow_CheckedChanged(object sender, EventArgs e)
        {
            ChangedBackColorPanel(chb_DozaNow, panel_DozaNow);
        }

        private void Chb_Temperature_CheckedChanged(object sender, EventArgs e)
        {
            ChangedBackColorPanel(chb_Temperature, panel_Temperature);
        }

        private void Chb_VolumeFlow_CheckedChanged(object sender, EventArgs e)
        {
            ChangedBackColorPanel(chb_VolumeFlow, panel_VolumeFlow);
        }

        private void Chb_RoH2O_CheckedChanged(object sender, EventArgs e)
        {
            ChangedBackColorPanel(chb_RoH2O, panel_RoH2O);
        }

        private void Chb_MassFlow_CheckedChanged(object sender, EventArgs e)
        {
            ChangedBackColorPanel(chb_MassFlow, panel_MassFlow);
        }

        private void BtnSaveAll_Click(object sender, EventArgs e)
        {
            try
            {
                IniFile INI = new IniFile(@ConfigurationManager.AppSettings["pathConfig"]);
                INI.WriteINI("CheckedViewDataValue", "DozaNow", chb_DozaNow.Checked.ToString());
                INI.WriteINI("CheckedViewDataValue", "MassFlow", chb_MassFlow.Checked.ToString());
                INI.WriteINI("CheckedViewDataValue", "VolumeFlow", chb_VolumeFlow.Checked.ToString());
                INI.WriteINI("CheckedViewDataValue", "Temperature", chb_Temperature.Checked.ToString());
                INI.WriteINI("CheckedViewDataValue", "RoH2O", chb_RoH2O.Checked.ToString());
                INI.WriteINI("RestartFlag", "timeOutRestart", tbTimeRestartApp.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка чтения config.ini файла, при записи!\n" + ex,
                                "Ошибка !");
            }

            if (!string.IsNullOrEmpty(tbPathFileSaveData.Text))
            {
                IniFile INI = new IniFile(@ConfigurationManager.AppSettings["pathConfig"]);
                INI.WriteINI("PathFolderSaveData", "pathFolder", tbPathFileSaveData.Text);
            }
            else 
            {
                MessageBox.Show("Вы не указали путь к папке для записи данных.",
                                 "Внимание!",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Exclamation);
            }
        }

        private void FormGeneralSetting_Load(object sender, EventArgs e)
        {
            try
            {
                IniFile INI = new IniFile(@ConfigurationManager.AppSettings["pathConfig"]);
                tempBoolDozaNow = bool.Parse(INI.ReadINI("CheckedViewDataValue", "DozaNow"));
                tempBoolMassFlow = bool.Parse(INI.ReadINI("CheckedViewDataValue", "MassFlow"));
                tempBoolVolumeFlow = bool.Parse(INI.ReadINI("CheckedViewDataValue", "VolumeFlow"));
                tempBoolTemperature = bool.Parse(INI.ReadINI("CheckedViewDataValue", "Temperature"));
                tempBoolRoH2O = bool.Parse(INI.ReadINI("CheckedViewDataValue", "RoH2O"));
                tbPathFileSaveData.Text = INI.ReadINI("PathFolderSaveData", "pathFolder");
                tbTimeRestartApp.Text = INI.ReadINI("RestartFlag", "timeOutRestart");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка чтения config.ini файла!\n" + ex,
                                "Ошибка !");
            }

            LoadCheckedCheckBox(tempBoolDozaNow, chb_DozaNow);
            LoadCheckedCheckBox(tempBoolMassFlow, chb_MassFlow);
            LoadCheckedCheckBox(tempBoolVolumeFlow, chb_VolumeFlow);
            LoadCheckedCheckBox(tempBoolTemperature, chb_Temperature);
            LoadCheckedCheckBox(tempBoolRoH2O, chb_RoH2O);
        }

        private void LoadCheckedCheckBox(bool tempBool, CheckBox checkBox)
        {
            if (tempBool)
                checkBox.Checked = true;
        }

        private void BtnFolderBrowserDialog_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog DirDialog = new FolderBrowserDialog();
            DirDialog.Description = "Выбор директории";
            DirDialog.SelectedPath = @"C:\";

            if (DirDialog.ShowDialog() == DialogResult.OK)
            {
                tbPathFileSaveData.Text = DirDialog.SelectedPath + @"\";
            }
        }


    }
}
