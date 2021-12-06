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

namespace SerialPortComm
{
    public partial class frmMain : Form
    {
        PrivateFontCollection fontCollection = new PrivateFontCollection();

        public frmMain()
        {
            InitializeComponent();

            fontCollection.AddFontFile(@"..\..\Resources\digital-7.ttf"); // файл шрифта
            fontCollection.AddFontFile(@"..\..\Resources\digital-7 (mono).ttf"); // файл шрифта
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            //FontFamily family = fontCollection.Families[1];
            lbDataValue_DozaNow.Font = new Font(fontFamilySelected(1), 24);
            lbDataValue_VolumeFlow.Font = new Font(fontFamilySelected(1), 24);
            lbDataValue_Temperature.Font = new Font(fontFamilySelected(1), 24);
        }

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

        private void BtnStartSend_Click(object sender, EventArgs e)
        {

        }
    }
}
