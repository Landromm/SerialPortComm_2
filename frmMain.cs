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


        //[System.Runtime.InteropServices.DllImport("gdi32.dll")]
        //private static extern IntPtr AddFontMemResourceEx(IntPtr pbFont, uint cbFont,
        //    IntPtr pdv, [System.Runtime.InteropServices.In] ref uint pcFonts);

        //private PrivateFontCollection fonts = new PrivateFontCollection();

        //Font myFont;

        public frmMain()
        {
            InitializeComponent();

            //byte[] fontData = Properties.Resources.POCKC___;
            //IntPtr fontPtr = System.Runtime.InteropServices.Marshal.AllocCoTaskMem(fontData.Length);
            //System.Runtime.InteropServices.Marshal.Copy(fontData, 0, fontPtr, fontData.Length);
            //uint dummy = 0;
            //fonts.AddMemoryFont(fontPtr, Properties.Resources.POCKC___.Length);
            //AddFontMemResourceEx(fontPtr, (uint)Properties.Resources.POCKC___.Length, IntPtr.Zero, ref dummy);
            //System.Runtime.InteropServices.Marshal.FreeCoTaskMem(fontPtr);

            //myFont = new Font(fonts.Families[0], 14.0F);

            // Устанавливаем нужный шрифт

        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            PrivateFontCollection fontCollection = new PrivateFontCollection();
            fontCollection.AddFontFile(@"..\..\Resources\Upsilon.ttf"); // файл шрифта
            FontFamily family = fontCollection.Families[0];
            // Создаём шрифт и используем далее
            Font font = new Font(family, 15);
            rchbDataValue1.Font = font;
        }

        private void BtnStartSend_Click(object sender, EventArgs e)
        {

        }
    }
}
