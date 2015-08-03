using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CasebookAutomation;
namespace SubscriptionTests
{
    [TestClass]
    public class LoginTests
    {
        private const int secondstowait = 3;

        [TestInitialize]
        public void Init() 
        {
            Driver.Initialize();
        }

        [TestMethod]
        public void UserLoginCorrectCredentials()
        {
            LoginPage.GoTo();
            LoginPage.LoginAs().LoginWithCorrectCredentials().Login();
            Driver.Wait(TimeSpan.FromSeconds(secondstowait));
            var msg = DashboardPage.DashboardPageTitle;
            if (string.IsNullOrEmpty(msg))
            { ErrorLogs.SaveToErrorLog("UserLoginCorrectCredentials", ConfigAndResource.GetResourceString("DashboardPageTitle")); }
            Assert.AreEqual(msg, ConfigAndResource.GetResourceString("DashboardPageTitle"));

        }
        [TestMethod]
        public void UserLoginWrongCredentials()
        {
            LoginPage.GoTo();
            LoginPage.LoginAs().LoginWithWrongCredentials().Login();
            Driver.Wait(TimeSpan.FromSeconds(secondstowait));
            var msg = LoginPage.LoginFailedMessage;
            if (string.IsNullOrEmpty(msg))
            { ErrorLogs.SaveToErrorLog("UserLoginCorrectCredentials", ConfigAndResource.GetResourceString("LoginFailedMessage")); }
            Assert.AreEqual(msg, ConfigAndResource.GetResourceString("LoginFailedMessage"));
        }
        [TestMethod]
        public void UserLoginPasswordOnly()
        {
            LoginPage.GoTo();
            LoginPage.LoginAs().LoginWithPasswordOnly().Login();
            Driver.Wait(TimeSpan.FromSeconds(secondstowait));
            var msg = LoginPage.LoginFailedMessage;
            if (string.IsNullOrEmpty(msg))
            { ErrorLogs.SaveToErrorLog("UserLoginCorrectCredentials", ConfigAndResource.GetResourceString("LoginFailedMessage")); }
            Assert.AreEqual(msg, ConfigAndResource.GetResourceString("LoginFailedMessage"));
        }
        [TestMethod]
        public void UserLoginRNOnly()
        {
            LoginPage.GoTo();
            LoginPage.LoginAs().LoginWithRollNumberOnly().Login();
            Driver.Wait(TimeSpan.FromSeconds(secondstowait));
            var msg = LoginPage.LoginFailedMessage;
            if (string.IsNullOrEmpty(msg))
            { ErrorLogs.SaveToErrorLog("UserLoginCorrectCredentials", ConfigAndResource.GetResourceString("LoginFailedMessage")); }
            Assert.AreEqual(msg, ConfigAndResource.GetResourceString("LoginFailedMessage"));
        }
        [TestMethod]
        public void UserLoginBlankCredentials()
        {
            LoginPage.GoTo();
            LoginPage.LoginAs().LoginWitBlankCredentials().Login();
            Driver.Wait(TimeSpan.FromSeconds(secondstowait));
            var msg = LoginPage.LoginFailedMessage;
           if (string.IsNullOrEmpty(msg))
            { ErrorLogs.SaveToErrorLog("UserLoginCorrectCredentials", ConfigAndResource.GetResourceString("LoginFailedMessage")); }
            Assert.AreEqual(msg, ConfigAndResource.GetResourceString("LoginFailedMessage"));
        }


        //[TestCleanup]
        //public void Cleanup() 
        //{
        //    Driver.Close();
        //}
    }
}
