
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

            Mail m = new Mail();
            m.search();

            //while (true)
            //{
            //    try
            //    {


            //    }
            //    catch (System.IO.IOException e)
            //    {
            //        //MessageBox.Show(e.Message);
            //    }
            //}
        }
    }
}
