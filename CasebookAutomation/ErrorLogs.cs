using System;
using System.Reflection;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasebookAutomation
{
    public class ErrorLogs
    {
        public static void SaveToErrorLog(string testcase, string expectedvalue)
        {
            string path = System.IO.Path.GetDirectoryName(System.IO.Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory())) + "\\Test Case Log\\";            
            string filename = "Error Logs.txt";
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
                using (StreamWriter sw = System.IO.File.AppendText(document))
                {
                    string errordata = string.Format("{0}{1}{2}{3}", "Date Time:" + DateTime.Now.ToString(), " - Test Case:" + testcase, " - Expected Value: ", expectedvalue);
                    sw.WriteLine(errordata);
                }
            }
            else
            {
                using (StreamWriter sw = System.IO.File.CreateText(document))
                {
                    string errordata = string.Format("{0}{1}{2}{3}", "Date Time:" + DateTime.Now.ToString(), " - Test Case:" + testcase, " - Expected Value: ", expectedvalue);
                    sw.WriteLine(errordata);
                }
            }
            #endregion
        }
    }
}
