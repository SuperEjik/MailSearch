using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;

namespace TestForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            using (Imap imap = new Imap())
            {
                imap.Connect(_server);
                imap.Login(_user, _password);
                imap.SelectInbox();

                SimpleImapQuery query = new SimpleImapQuery();
                query.Subject = textBox3.Text;
                query.Unseen = true;
                List<long> uids = imap.Search(query);
                //if (uids.Count > 0)
                //{
                //    label10.Text = ((int.Parse((string)label10.Text) + 1)).ToString();
                //}
                //else
                //{
                //    label12.Text = ((int.Parse((string)label12.Text) + 1)).ToString();
                //}

                imap.Close();
            }
        }



    }
}
