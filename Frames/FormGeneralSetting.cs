﻿using System;
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

        private void BtnSaveCheckBox_Click(object sender, EventArgs e)
        {
            try
            {
                IniFile INI = new IniFile(@ConfigurationManager.AppSettings["pathConfig"]);
                INI.WriteINI("CheckedViewDataValue", "DozaNow", chb_DozaNow.Checked.ToString());
                INI.WriteINI("CheckedViewDataValue", "MassFlow", chb_MassFlow.Checked.ToString());
                INI.WriteINI("CheckedViewDataValue", "VolumeFlow", chb_VolumeFlow.Checked.ToString());
                INI.WriteINI("CheckedViewDataValue", "Temperature", chb_Temperature.Checked.ToString());
                INI.WriteINI("CheckedViewDataValue", "RoH2O", chb_RoH2O.Checked.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка чтения config.ini файла, при записи!\n" + ex,
                                "Ошибка !");
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
    }
}
