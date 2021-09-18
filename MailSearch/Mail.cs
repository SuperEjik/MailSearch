using System;
using System.IO;

namespace MailSearch
{
    class Mail
    {
        string YourPassword = "";
        string YourMail = "";

        public void search()
        {

            bool found = false;
            DateTime dateTime;
            dateTime = DateTime.Today;
            //var client = new OpenPop.Pop3.Pop3Client();
            int i = 0;

            while (found == false)
            {
                i = 0;

                var client = new OpenPop.Pop3.Pop3Client();
                client.Connect("pop.gmail.com", 995, true);//для каждого электронного ящика своя информация (пример для гугл)
                client.Authenticate(YourMail, YourPassword, OpenPop.Pop3.AuthenticationMethod.UsernameAndPassword);

                while (i < client.GetMessageCount() && found == false)
                {

                        switch (client.GetMessage(client.GetMessageCount() - i).Headers.From.ToString())
                        {
                            case "\"Twitch\" <no-reply@twitch.tv>":
                                {
                                    if (client.GetMessage(client.GetMessageCount() - i).Headers.Subject.Contains("name_chanel") 
                                    && client.GetMessage(client.GetMessageCount() - i).Headers.DateSent.Date == dateTime
                                    && client.GetMessage(client.GetMessageCount() - i).Headers.DateSent.TimeOfDay > new TimeSpan(9, 30, 0))
                                    {
                                        System.Diagnostics.Process.Start(get_link_from_youtube_and_twich(client, i, 42));
                                        found = true;
                                    }

                                    break;
                                }

                            case "\"YouTube\" <noreply@youtube.com>":
                                {
                                    if (client.GetMessage(client.GetMessageCount() - i).Headers.Subject.Contains("name_chanel") && client.GetMessage(client.GetMessageCount() - i).Headers.DateSent.Date == dateTime
                                    && client.GetMessage(client.GetMessageCount() - i).Headers.DateSent.TimeOfDay > new TimeSpan(9, 30, 0))
                                    {
                                        System.Diagnostics.Process.Start(get_link_from_youtube_and_twich(client, i, 478));
                                        found = true;
                                    }

                                    break;
                                }
                        }

                    i++;
                }


            }
        }

        public string[] write_read(OpenPop.Pop3.Pop3Client client, int i)
        {
            //запись в файл
            using (FileStream fstream = new FileStream($"note.txt", FileMode.OpenOrCreate))
            {
                // преобразуем строку в байты
                byte[] array = System.Text.Encoding.Default.GetBytes(client.GetMessage(client.GetMessageCount() - i).FindFirstHtmlVersion().GetBodyAsText());
                // запись массива байтов в файл
                fstream.Write(array, 0, array.Length);
            }

            // чтение из файла
            string[] lines = File.ReadAllLines($"note.txt");

            return lines;
        }

        public void delete_file()
        {
            File.Delete($"note.txt");
        }

        public string get_link_from_youtube_and_twich(OpenPop.Pop3.Pop3Client client, int i, int numberOfStr)
        {
            string link = "";
            string linkFromFile = write_read(client, i)[numberOfStr];
            string https = "http";
            int indexOfhttps = linkFromFile.IndexOf(https);
            link = linkFromFile.Substring(indexOfhttps);
            link = link.Trim(new char[] { '>', '"' });

            return link;
        }
    }
}
