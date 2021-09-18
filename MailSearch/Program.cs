
using Microsoft.Win32;
using System.Windows.Forms;

namespace MailSearch
{
    class Program
    {
        static void Main(string[] args)
        {

            Autorun a = new Autorun();
            a.add_autorun();
            //a.delete_autorun();

            try
            {
                Mail m = new Mail();
                m.search();
            }
            catch (System.Exception)
            {

                MessageBox.Show("Приложение завершило работу");
            }


        }
    }
}
