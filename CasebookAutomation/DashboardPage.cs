using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace CasebookAutomation
{
    public class DashboardPage
    {
        public static void GoTo6monthsSubscription()
        {
            //Driver.Wait(TimeSpan.FromSeconds(3));
            var navigatePricing = Driver.Instance.FindElement(By.XPath(".//*[@id='pricing']/div/div/div/div[1]/div/div[2]/button"));
            navigatePricing.Click();
        }
        public static void GoTo12monthsSubscription()
        {
            Driver.Wait(TimeSpan.FromSeconds(3));
            var navigatePricing = Driver.Instance.FindElement(By.XPath("//*[@id='pricing']/div/div/div/div[2]/div/div[2]/button"));
            navigatePricing.Click();
        }
        public static void UserLogout()
        {
            var userMenu = Driver.Instance.FindElement(By.XPath(".//*[@id='navbar-collapse']/ul/li[6]/a/span/span[3]"));
            userMenu.Click();
            var logoutLink = Driver.Instance.FindElement(By.XPath("//*[@id='navbar-collapse']/ul/li[6]/ul/li[5]/a"));
            logoutLink.Click();
        }
        public static string DashboardPageTitle
        {
            get
            {
                var span = Driver.Instance.FindElement(By.XPath("//*[@id='promo']/div/div/div[4]/div[1]/h3/span"));
                if (span != null)
                    return span.Text;
                return string.Empty;
            }
        }
        public static string GetExpirationDate
        {
            get
            {
               var expiration = Driver.Instance.FindElement(By.XPath("//*[@id='promo']/div/div/div[4]/div[1]/p/span[2]"));
               string expdate = expiration.Text;
               string trimdate = expdate.Trim().Remove(0, 42);
               if (expiration != null)
                   return trimdate;
                return string.Empty;
            }
        }
    }
}
