using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using CasebookAutomation;

namespace CasebookAutomation
{
    public class SubscriptionExpirationDate
    {
        public static void Save(string expirationdate)
        {
            string path = System.IO.Path.GetDirectoryName(System.IO.Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory())) + "\\Subscription Expiration\\";
            string filename = "SubscriptionExpiration.txt";
            string document = string.Format("{0}{1}", path, filename);
            if (System.IO.Directory.Exists(path))
            {
                goto checkfile;
            }
            else
            {
                System.IO.Directory.CreateDirectory(path);
                goto checkfile;
            }

        checkfile:
            #region check and create error logs
            if (System.IO.File.Exists(document))
            {
                using (StreamWriter sw = System.IO.File.CreateText(document))
                {
                    sw.Write(expirationdate);
                }
            }
            else
            {
                using (StreamWriter sw = System.IO.File.CreateText(document))
                {

                    sw.Write(expirationdate);
                }
            }
            #endregion
        }
        public static string Get()
        {
            string path = System.IO.Path.GetDirectoryName(System.IO.Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory())) + "\\Subscription Expiration\\";
            string filename = "SubscriptionExpiration.txt";
            string document = string.Format("{0}{1}", path, filename);

            System.IO.StreamReader file = new System.IO.StreamReader(document);
            return file.ReadLine();

        }
    }
}
