using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasebookAutomation
{
    public class CheckoutPage
    {
        public static void GoTo()
        {
            Driver.Instance.Navigate().GoToUrl("https://cbwebqa.basecamptech.ph/subscription/home/cop");
        }
        public static void GoBack()
        {
           //var wait = new WebDriverWait(Driver.Instance, TimeSpan.FromSeconds(10));
           //wait.Until(drv => drv.FindElement(By.XPath("//*[@id='Cart']")));
           Driver.Instance.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));

           var gobackButton = Driver.Instance.FindElement(By.XPath(".//*[@id='Cart']/div/div/div/div/a[1]"));
           gobackButton.Click();
        }
        public static void Purchase()
        {
            var purchaseButton = Driver.Instance.FindElement(By.XPath("//*[@id='Cart']/div/div/div/div/a[2]"));
            purchaseButton.Click();
        }
        public static CheckoutCommand CheckoutAs()
        {
            return new CheckoutCommand();
        }
        public static string TotalAmount 
        {
            get
            {
                var tds = Driver.Instance.FindElement(By.XPath("//*[@id='Cart']/div/div/div/table/tbody/tr[1]/td[2]"));
                if (tds != null)
                    return tds.Text;
                return string.Empty;
            }
        }
        public static string PurchaseModal
        {
            get
            {
                var modalmessage = Driver.Instance.SwitchTo().ActiveElement().FindElement(By.XPath("/html/body/div[3]/div/div/div[2]/div/div[1]/div/span"));
                if (modalmessage != null)
                    return modalmessage.Text;
                return string.Empty;
            }
        }     
        public static string SubscriptionExpiration
        {
            get
            {
                var userMenu = Driver.Instance.FindElement(By.XPath(".//*[@id='navbar-collapse']/ul/li[6]/a/span/span[3]"));
                userMenu.Click();
                System.Threading.Thread.Sleep(500);
                var span = Driver.Instance.FindElement(By.XPath("//*[@id='navbar-collapse']/ul/li[6]/ul/li[3]/div/small"));
                if (span != null)
                    return span.Text;
                return string.Empty;
            }
        }
        public static string CheckoutFailedMessage
        {
            get
            {
                var span = Driver.Instance.FindElement(By.XPath("/html/body/div[3]/div/div/div[2]/div/div[1]/form/div[3]/strong"));
                if (span != null)
                    return span.Text;
                return string.Empty;
            }
        }
       
    }
    public class CheckoutCommand
    {
        private string contactNumber;
        private string password;
        public CheckoutCommand Buy6monthsSubscriptionWithCorrectPassword()
        {
            this.contactNumber = ConfigAndResource.GetResourceString("ContactNumber");
            this.password = ConfigAndResource.GetResourceString("Password");

            return this;
        }
        public CheckoutCommand Buy6monthsSubscriptionWithWrongPassword()
        {
            this.contactNumber = ConfigAndResource.GetResourceString("ContactNumber");
            this.password = ConfigAndResource.GetResourceString("Password") + "15";

            return this;
        }
        public void Checkout()
        {
            var inputPassword = Driver.Instance.FindElement(By.Id("logPassword"));
            inputPassword.SendKeys(password);
            var inputContact = Driver.Instance.FindElement(By.Id("ContactNumber"));
            inputContact.SendKeys(contactNumber);
            var submitButton = Driver.Instance.FindElement(By.XPath("html/body/div/div/div/div[2]/div/div/form/button"));
            submitButton.Click();
        }
    }
}
