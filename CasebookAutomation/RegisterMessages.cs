using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenQA.Selenium;

namespace CasebookAutomation
{
    public class RegisterMessages
    {
        public static object title
        {
            get
            {
                var RegMsgfail = Driver.Instance.FindElement(By.XPath(".//*[@id='promo']/div/div/div[3]/div[1]/form/div[2]/div/p"));
                if (RegMsgfail != null)
                {
                    return RegMsgfail.Text;
                }
                return string.Empty;
            }
        }
        public static object titleIncFields
        {
            get
            {
                var incFields = Driver.Instance.FindElement(By.XPath(".//*[@id='promo']/div/div/div[3]/div[1]/form/div[7]/span"));
                if (incFields != null)
                {
                    return incFields.Text;
                }
                return string.Empty;
            }       
        }
        public static object titlePasswordsNotMatched
        {
            get
            {
                var PasswordNotMatched = Driver.Instance.FindElement(By.XPath(".//*[@id='promo']/div/div/div[3]/div[1]/form/div[7]/span"));
                if (PasswordNotMatched != null)
                {
                    return PasswordNotMatched.Text;
                }
                return string.Empty;
            }
        }
    }
}
