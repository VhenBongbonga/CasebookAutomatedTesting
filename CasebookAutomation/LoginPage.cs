using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace CasebookAutomation
{
    public class LoginPage
    {

        public static void GoTo()
        {
            Driver.Instance.Navigate().GoToUrl("https://cbwebqa.basecamptech.ph/subscription");
            //var wait = new WebDriverWait(Driver.Instance, TimeSpan.FromSeconds(10));
            //wait.Until(d => d.SwitchTo().ActiveElement().GetAttribute("id") == "email");
        }
        public static LoginCommand LoginAs()
        {
            return new LoginCommand();
        }
        public static string LoginSuccess
        {
            get
            {
                var message = Driver.Instance.FindElement(By.XPath("//*[@id='promo']/div/div/div[4]/div[1]/h3/span"));
                if (message != null)
                    return message.Text;
                return string.Empty;
            }
        }
        public static string LoginFailedMessage
        {
            get
            {
                var message = Driver.Instance.FindElement(By.XPath("/html/body/div[3]/div/div/div[2]/div/div[2]/div/strong"));
                if (message != null)
                    return message.Text;
                return string.Empty;
            }
        }
        public static string LogoutMessage
        {
            get
            {
                var span = Driver.Instance.FindElement(By.XPath("//*[@id='promo']/div/div/div[3]/div[1]/div[1]/h3/span"));
                if (span != null)
                    return span.Text;
                return string.Empty;
            }
        }

    }
    public class LoginCommand 
    {
        private string rollNumber;
        private string password;
        public LoginCommand LoginWithCorrectCredentials ()
        {
            this.rollNumber = ConfigAndResource.GetResourceString("RollNumber");
            this.password = ConfigAndResource.GetResourceString("Password");

            return this;
        }
        public LoginCommand LoginWithWrongCredentials()
        {
            this.rollNumber = ConfigAndResource.GetResourceString("RollNumber") + "15";
            this.password = ConfigAndResource.GetResourceString("Password") + "15";

            return this;
        }
        public LoginCommand LoginWithPasswordOnly()
        {
            this.rollNumber = string.Empty;
            this.password = ConfigAndResource.GetResourceString("Password");

            return this;
        }
        public LoginCommand LoginWithRollNumberOnly()
        {
            this.rollNumber = ConfigAndResource.GetResourceString("RollNumber");
            this.password = string.Empty;

            return this;
        }
        public LoginCommand LoginWitBlankCredentials()
        {
            this.rollNumber = string.Empty;
            this.password = string.Empty;

            return this;
        }
        public void Login()
        {
            var clickSignin = Driver.Instance.FindElement(By.XPath(".//*[@id='navbar-collapse']/ul/li[5]/a"));
            clickSignin.Click();

            var rollNumberInput = Driver.Instance.FindElement(By.XPath(".//*[@id='email']"));
            rollNumberInput.SendKeys(rollNumber);

            var passwordInput = Driver.Instance.FindElement(By.XPath("html/body/div[3]/div/div/div[2]/div/div[2]/form/div[2]/input"));
            passwordInput.SendKeys(password);

            var submitButton = Driver.Instance.FindElement(By.XPath("html/body/div[3]/div/div/div[2]/div/div[2]/form/button"));
            submitButton.Click();

            //var wait = new WebDriverWait(Driver.Instance, TimeSpan.FromSeconds(10));
            //wait.Until(drv => drv.FindElement(By.XPath("//*[@id='promo']/div/div/div[4]/div[1]/h3/span")));

        }
    }
}
