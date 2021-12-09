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
        string Path; //Имя файла.

        //[DllImport("kernel32", CharSet = CharSet.Unicode)] // Подключаем kernel32.dll и описываем его функцию WritePrivateProfilesString
        //static extern long WritePrivateProfileString(string Section, string Key, string Value, string FilePath);

        //[DllImport("kernel32", CharSet = CharSet.Unicode)] // Еще раз подключаем kernel32.dll, а теперь описываем функцию GetPrivateProfileString
        //static extern int GetPrivateProfileString(string Section, string Key, string Default, StringBuilder RetVal, int Size, string FilePath);

        //[DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        //static extern uint GetPrivateProfileSection(string lpAppName, IntPtr lpReturnedString, uint nSize, string lpFileName);


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

        ////Читаем ini-файл и возвращаем значение указного ключа из заданной секции.
        //public string ReadINI(string Section, string Key)
        //{
        //    var RetVal = new StringBuilder(255);
        //    GetPrivateProfileString(Section, Key, "", RetVal, 255, Path);
        //    return RetVal.ToString();
        //}
        ////Записываем в ini-файл. Запись происходит в выбранную секцию в выбранный ключ.
        //public void WriteINI(string Section, string Key, string Value)
        //{
        //    WritePrivateProfileString(Section, Key, Value, Path);
        //}

        ////Удаляем ключ из выбранной секции.
        //public void DeleteKey(string Key, string Section = null)
        //{
        //    WriteINI(Section, Key, null);
        //}
        ////Удаляем выбранную секцию
        //public void DeleteSection(string Section = null)
        //{
        //    WriteINI(Section, null, null);
        //}
        ////Проверяем, есть ли такой ключ, в этой секции
        //public bool KeyExists(string Key, string Section = null)
        //{
        //    return ReadINI(Section, Key).Length > 0;
        //}
    }
}
