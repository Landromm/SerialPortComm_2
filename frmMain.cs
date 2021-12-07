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

namespace SerialPortComm
{
    public partial class frmMain : Form
    {
        PrivateFontCollection fontCollection = new PrivateFontCollection();
        bool checkedViewDozaNow;
        bool checkedViewMassFlow;
        bool checkedViewVolumeFlow;
        bool checkedViewTemperature;
        bool checkedViewRoH2O;

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

        // Метод кнопки "Start Send".
        private void BtnStartSend_Click(object sender, EventArgs e)
        {

        }

        // Метод кнопки "Menu".
        private void btnMenu_Click(object sender, EventArgs e)
        {
            MainForm mainForm = new MainForm();
            mainForm.ShowDialog();
        }

        private void frmMain_Activated(object sender, EventArgs e)
        {
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
    }
}
