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

namespace SerialPortComm
{
    public partial class frmMain : Form
    {
        //PrivateFontCollection fontCollection = new PrivateFontCollection();

        [System.Runtime.InteropServices.DllImport("gdi32.dll")]
        private static extern IntPtr AddFontMemResourceEx(IntPtr pbFont, uint cbFont,
            IntPtr pdv, [System.Runtime.InteropServices.In] ref uint pcFonts);

        private PrivateFontCollection fonts = new PrivateFontCollection();

        Font myFont;

        public frmMain()
        {
            InitializeComponent();

            
            myFont = fontFamily(Properties.Resources.digital_7__mono_);
        }

        private Font fontFamily(byte[] resources)
        {
            byte[] fontData = resources;
            IntPtr fontPtr = System.Runtime.InteropServices.Marshal.AllocCoTaskMem(fontData.Length);
            System.Runtime.InteropServices.Marshal.Copy(fontData, 0, fontPtr, fontData.Length);
            uint dummy = 0;
            fonts.AddMemoryFont(fontPtr, resources.Length);
            AddFontMemResourceEx(fontPtr, (uint)resources.Length, IntPtr.Zero, ref dummy);
            System.Runtime.InteropServices.Marshal.FreeCoTaskMem(fontPtr);
            Font family = new Font(fonts.Families[0], 20.0F);
            return family;
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            //Присвоение шрифта для цифровых данных.
            //lbDataValue_DozaNow.Font = new Font(fontFamilySelected(1), 24);
            //lbDataValue_VolumeFlow.Font = new Font(fontFamilySelected(1), 24);
            //lbDataValue_Temperature.Font = new Font(fontFamilySelected(1), 24);
            //lbDataValue_MassFlow.Font = new Font(fontFamilySelected(1), 24);
            //lbDataValue_RoH2O.Font = new Font(fontFamilySelected(1), 24);
            lbDataValue_DozaNow.Font = myFont;
            lbDataValue_VolumeFlow.Font = myFont;
            lbDataValue_Temperature.Font = myFont;
            lbDataValue_MassFlow.Font = myFont;
            lbDataValue_RoH2O.Font = myFont;
        }

        // Инициализация шррифта для цифровых значений.
        //private FontFamily fontFamilySelected(int index)
        //{
            //fontCollection.AddFontFile(@"..\..\Resources\digital-7.ttf"); // файл шрифта
            //fontCollection.AddFontFile(@"..\..\Resources\digital-7 (mono).ttf"); // файл шрифта
            //FontFamily family = fontCollection.Families[0];
            //FontFamily familyMono = fontCollection.Families[1];

            //if (index == 0)
            //    return family;
            //else if (index == 1)
            //    return familyMono;
            //else
            //    return family;
        //}

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
