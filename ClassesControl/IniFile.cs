using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SerialPortComm.ClassesControl
{
    class IniFile
    {
        // Путь файла.
        string Path; 

        // С помощью конструктора записываем путь до файла и его имя.
        public IniFile(string IniPath)
        {
            Path = new FileInfo(IniPath).FullName.ToString();
        }

        public void WriteINI(string section, string key, string value)
        {
            if (NativeMethods.WritePrivateProfileString(section, key, value, Path) == false)
            {
                throw new Win32Exception(Marshal.GetLastWin32Error());
            }
        }

        public string ReadINI(string section, string key)
        {
            uint maxLength = 32;
            string value = new string(' ', (int)maxLength);
            NativeMethods.GetPrivateProfileString(section, key, "", value, maxLength, Path);
            return value.Split('\0')[0];
        }

        public string[] ReadSections()
        {
            string value = new string(' ', 65535);
            NativeMethods.GetPrivateProfileString(null, null, "\0", value, 65535, Path);
            return SplitNullTerminatedStrings(value);
        }

        private static string[] SplitNullTerminatedStrings(string value)
        {
            string[] raw = value.Split('\0');
            int itemCount = raw.Length - 2;
            string[] items = new string[itemCount];
            Array.Copy(raw, items, itemCount);
            return items;
        }

        public string[] ReadKeysInSection(string section)
        {
            string value = new string(' ', 65535);
            NativeMethods.GetPrivateProfileString(section, null, "\0", value, 65535, Path);
            return SplitNullTerminatedStrings(value);
        }

    }
}
