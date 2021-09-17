using Microsoft.Win32;
using System.Windows.Forms;

namespace MailSearch
{
    class Autoran
    {
        public void autoran()
        {
            string apEx = Application.ExecutablePath;

            RegistryKey saveKey = Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Run\\",true);
            //var saveKey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run\", true);

            //RegistryKey saveKey = Registry.LocalMachine.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run", true);

            if (saveKey.GetValue(System.IO.Path.GetFileName(apEx)) == null)
            {
                saveKey.SetValue(System.IO.Path.GetFileName(apEx), apEx);
                //saveKey.DeleteValue(System.IO.Path.GetFileName(apEx));
                saveKey.Close();
            }
        }
    }
}
