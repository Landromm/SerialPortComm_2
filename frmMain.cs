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

namespace SerialPortComm
{
    public partial class frmMain : Form
    {
        PrivateFontCollection fontCollection = new PrivateFontCollection();


        public frmMain()
        {
            InitializeComponent();

            fontCollection.AddFontFile(@ConfigurationManager.AppSettings["digital-7"]); // файл шрифта
            fontCollection.AddFontFile(@ConfigurationManager.AppSettings["digital-7_mono"]); // файл шрифта
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            // Присвоение шрифта для цифровых данных.
            lbDataValue_DozaNow.Font = new Font(fontFamilySelected(1), 24);
            lbDataValue_VolumeFlow.Font = new Font(fontFamilySelected(1), 24);
            lbDataValue_Temperature.Font = new Font(fontFamilySelected(1), 24);
            lbDataValue_MassFlow.Font = new Font(fontFamilySelected(1), 24);
            lbDataValue_RoH2O.Font = new Font(fontFamilySelected(1), 24);
        }

        // Инициализация шррифта для цифровых значений.
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
    }
}
