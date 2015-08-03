using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace CasebookAutomation
{
    public class RegisterPage
    {
        public static void GoTo()
        {
            Driver.Instance.Navigate().GoToUrl(Driver.BaseAddress + "subscription");
            //Driver.ChromeInstance.Navigate().GoToUrl(Driver.BaseAddress + "subscription");
        }

        public static RegisterCommand RegisterAs()
        {
            return new RegisterCommand();
        }
        public static string title
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
        public static string titleIncFields
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

        public static string titlePasswordsNotMatched
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

    public class RegisterCommand
    {
        private string firstName;
        private string lastName;
        private string emailAddress;
        private string birthday;
        private string userName;
        private string password;
        private string passretype;

        public RegisterCommand CreateAccountWithExistingGHAccount()
        {
            this.firstName = ConfigAndResource.GetResourceString("FirstName");
            this.lastName = ConfigAndResource.GetResourceString("LastName");
            this.emailAddress = ConfigAndResource.GetResourceString("ExistingEmailAddress");
            this.birthday = ConfigAndResource.GetResourceString("Birthday");
            this.userName = ConfigAndResource.GetResourceString("UserName");
            this.password = ConfigAndResource.GetResourceString("Password");
            this.passretype = ConfigAndResource.GetResourceString("RetypePassword");

            return this;
        }
        public RegisterCommand CreateAccountWOExistingGHAccount()
        {
            this.firstName = ConfigAndResource.GetResourceString("FirstName");
            this.lastName = ConfigAndResource.GetResourceString("LastName");
            this.emailAddress = ConfigAndResource.GetResourceString("NonExistingEmailAddress");
            this.birthday = ConfigAndResource.GetResourceString("Birthday");
            this.userName = ConfigAndResource.GetResourceString("UserName");
            this.password = ConfigAndResource.GetResourceString("Password");
            this.passretype = ConfigAndResource.GetResourceString("RetypePassword");

            return this;
        }
        public RegisterCommand CreateAccountWOFirstName()
        {
            this.firstName = "";
            this.lastName = ConfigAndResource.GetResourceString("LastName");
            this.emailAddress = ConfigAndResource.GetResourceString("ExistingEmailAddress");
            this.birthday = ConfigAndResource.GetResourceString("Birthday");
            this.userName = ConfigAndResource.GetResourceString("UserName");
            this.password = ConfigAndResource.GetResourceString("Password");
            this.passretype = ConfigAndResource.GetResourceString("RetypePassword");

            return this;
        }
        public RegisterCommand CreateAccountWOLastName()
        {
            this.firstName = ConfigAndResource.GetResourceString("FirstName");
            this.lastName = "";
            this.emailAddress = ConfigAndResource.GetResourceString("ExistingEmailAddress");
            this.birthday = ConfigAndResource.GetResourceString("Birthday");
            this.userName = ConfigAndResource.GetResourceString("UserName");
            this.password = ConfigAndResource.GetResourceString("Password");
            this.passretype = ConfigAndResource.GetResourceString("RetypePassword");

            return this;
        }
        public RegisterCommand CreateAccountWOEmailAddress()
        {
            this.firstName = ConfigAndResource.GetResourceString("FirstName");
            this.lastName = ConfigAndResource.GetResourceString("LastName");
            this.emailAddress = "";
            this.birthday = ConfigAndResource.GetResourceString("Birthday");
            this.userName = ConfigAndResource.GetResourceString("UserName");
            this.password = ConfigAndResource.GetResourceString("Password");
            this.passretype = ConfigAndResource.GetResourceString("RetypePassword");

            return this;
        }
        public RegisterCommand CreateAccountWIncEmailAddress()
        {
            this.firstName = ConfigAndResource.GetResourceString("FirstName");
            this.lastName = ConfigAndResource.GetResourceString("LastName");
            this.emailAddress = ConfigAndResource.GetResourceString("IncEmailAddress");
            this.birthday = ConfigAndResource.GetResourceString("Birthday");
            this.userName = ConfigAndResource.GetResourceString("UserName");
            this.password = ConfigAndResource.GetResourceString("Password");
            this.passretype = ConfigAndResource.GetResourceString("RetypePassword");

            return this;
        }
        public RegisterCommand CreateAccountWOBirthday()
        {
            this.firstName = ConfigAndResource.GetResourceString("FirstName");
            this.lastName = ConfigAndResource.GetResourceString("LastName");
            this.emailAddress = ConfigAndResource.GetResourceString("ExistingEmailAddress");
            this.birthday = "";
            this.userName = ConfigAndResource.GetResourceString("UserName");
            this.password = ConfigAndResource.GetResourceString("Password");
            this.passretype = ConfigAndResource.GetResourceString("RetypePassword");

            return this;
        }
        public RegisterCommand CreateAccountWOUserName()
        {
            this.firstName = ConfigAndResource.GetResourceString("FirstName");
            this.lastName = ConfigAndResource.GetResourceString("LastName");
            this.emailAddress = ConfigAndResource.GetResourceString("ExistingEmailAddress");
            this.birthday = ConfigAndResource.GetResourceString("Birthday");
            this.userName = "";
            this.password = ConfigAndResource.GetResourceString("Password");
            this.passretype = ConfigAndResource.GetResourceString("RetypePassword");

            return this;
        }
        public RegisterCommand CreateAccountWOPassword()
        {
            this.firstName = ConfigAndResource.GetResourceString("FirstName");
            this.lastName = ConfigAndResource.GetResourceString("LastName");
            this.emailAddress = ConfigAndResource.GetResourceString("ExistingEmailAddress");
            this.birthday = ConfigAndResource.GetResourceString("Birthday");
            this.userName = ConfigAndResource.GetResourceString("UserName");
            this.password = "";
            this.passretype = ConfigAndResource.GetResourceString("RetypePassword");

            return this;
        }
        public RegisterCommand CreateAccountWORTPassword()
        {
            this.firstName = ConfigAndResource.GetResourceString("FirstName");
            this.lastName = ConfigAndResource.GetResourceString("LastName");
            this.emailAddress = ConfigAndResource.GetResourceString("ExistingEmailAddress");
            this.birthday = ConfigAndResource.GetResourceString("Birthday");
            this.userName = ConfigAndResource.GetResourceString("UserName");
            this.password = ConfigAndResource.GetResourceString("Password");
            this.passretype = "";

            return this;
        }
        public RegisterCommand CreateAccountWPassUnmatched()
        {
            this.firstName = ConfigAndResource.GetResourceString("FirstName");
            this.lastName = ConfigAndResource.GetResourceString("LastName");
            this.emailAddress = ConfigAndResource.GetResourceString("ExistingEmailAddress");
            this.birthday = ConfigAndResource.GetResourceString("Birthday");
            this.userName = ConfigAndResource.GetResourceString("UserName");
            this.password = ConfigAndResource.GetResourceString("Password");
            this.passretype = ConfigAndResource.GetResourceString("RetypePassword");

            return this;
        }
        public RegisterCommand CreateAccountWIncBday()
        {
            this.firstName = ConfigAndResource.GetResourceString("FirstName");
            this.lastName = ConfigAndResource.GetResourceString("LastName");
            this.emailAddress = ConfigAndResource.GetResourceString("ExistingEmailAddress");
            this.birthday = ConfigAndResource.GetResourceString("IncBirthday");
            this.userName = ConfigAndResource.GetResourceString("UserName");
            this.password = ConfigAndResource.GetResourceString("Password");
            this.passretype = ConfigAndResource.GetResourceString("RetypePassword");

            return this;
        }

        public void Register()
        {
            var firstNameInput = Driver.Instance.FindElement(By.Id("fname"));
            firstNameInput.SendKeys(firstName);

            var lastNameInput = Driver.Instance.FindElement(By.Id("lname"));
            lastNameInput.SendKeys(lastName);

            var emailInput = Driver.Instance.FindElement(By.Id("emailadd"));
            emailInput.SendKeys(emailAddress);

            var bdayInput = Driver.Instance.FindElement(By.Id("bday"));
            bdayInput.SendKeys(birthday);

            var unameInput = Driver.Instance.FindElement(By.XPath(".//*[@id='promo']/div/div/div[3]/div[1]/form/div[4]/input"));
            unameInput.SendKeys(userName);

            var pwordInput = Driver.Instance.FindElement(By.Id("password"));
            pwordInput.SendKeys(password);

            var rtpwordInput = Driver.Instance.FindElement(By.Id("confirmPassword"));
            rtpwordInput.SendKeys(password);

            var chkboxClick = Driver.Instance.FindElement(By.XPath(".//*[@id='promo']/div/div/div[3]/div[1]/form/label/input"));
            chkboxClick.Click();

            var proceedButton = Driver.Instance.FindElement(By.XPath(".//*[@id='promo']/div/div/div[3]/div[1]/form/button"));
            proceedButton.Click();
        }
    }
}
