using Microsoft.Win32;
using System.Windows.Forms;

namespace MailSearch
{
    class Autorun
    {
        public void add_autorun()
        {
            string apEx = Application.ExecutablePath;

            //RegistryKey saveKey = Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Run\\",true);
            //var saveKey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run\", true);

            RegistryKey saveKey = Registry.LocalMachine.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run", true);

            if (saveKey.GetValue(System.IO.Path.GetFileName(apEx)) == null)
            {
                saveKey.SetValue(System.IO.Path.GetFileName(apEx), apEx);
                //saveKey.DeleteValue(System.IO.Path.GetFileName(apEx));
                saveKey.Close();
            }
        }

        public void delete_autorun()
        {
            string apEx = Application.ExecutablePath;

            //RegistryKey saveKey = Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Run\\", true);
            //var saveKey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run\", true);

            RegistryKey saveKey = Registry.LocalMachine.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run", true);

            if (saveKey.GetValue(System.IO.Path.GetFileName(apEx)) != null)
            {
                saveKey.DeleteValue(System.IO.Path.GetFileName(apEx));
                saveKey.Close();
            }
        }
    }
}
