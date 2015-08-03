using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CasebookAutomation;

namespace SubscriptionTests
{
    [TestClass]
    public class RegisterTests : SubscriptionTest
    {

        private const int SecondsToWait = 3;


        [TestMethod]
        public void Register_WO_GHAccount()
        {
            RegisterPage.GoTo();
            RegisterPage.RegisterAs().CreateAccountWOExistingGHAccount().Register();

            Driver.Wait(TimeSpan.FromSeconds(SecondsToWait));
            var RegisterMsg = RegisterPage.title;
            if (string.IsNullOrEmpty(RegisterMsg))
            {
                ErrorLogs.SaveToErrorLog("RegisterWGHAccount", ConfigAndResource.GetResourceString("SuccessfullyRegisteredMsg"));
            }
        }
        [TestMethod]
        public void Register_W_GH_Account()
        {
            RegisterPage.GoTo();
            RegisterPage.RegisterAs().CreateAccountWithExistingGHAccount().Register();

            Driver.Wait(TimeSpan.FromSeconds(SecondsToWait));
            var ARegisteredMsg = RegisterPage.title;
            if (string.IsNullOrEmpty(ARegisteredMsg) || ConfigAndResource.GetResourceString("AlreadyRegisteredMsg") != ARegisteredMsg)
            {
                ErrorLogs.SaveToErrorLog("Register_W_GH_Account", ConfigAndResource.GetResourceString("AlreadyRegisteredMsg"));
            }
            Assert.AreEqual(RegisterPage.title, ConfigAndResource.GetResourceString("AlreadyRegisteredMsg"));
        }
        [TestMethod]
        public void Register_WO_FirstName()
        {
            RegisterPage.GoTo();
            RegisterPage.RegisterAs().CreateAccountWOFirstName().Register();

            Driver.Wait(TimeSpan.FromSeconds(SecondsToWait));
            var IncFields = RegisterPage.titleIncFields;
            if (string.IsNullOrEmpty(IncFields) || ConfigAndResource.GetResourceString("IncFieldsMsg") != IncFields)
            {
                ErrorLogs.SaveToErrorLog("Register_WO_Firstname", ConfigAndResource.GetResourceString("IncFieldsMsg"));
            }
            Assert.AreEqual(RegisterPage.titleIncFields, ConfigAndResource.GetResourceString("IncFieldsMsg"));
        }
        [TestMethod]
        public void Register_WO_LastName()
        {
            RegisterPage.GoTo();
            RegisterPage.RegisterAs().CreateAccountWOLastName().Register();

            Driver.Wait(TimeSpan.FromSeconds(SecondsToWait));
            var IncFields = RegisterPage.titleIncFields;
            if (string.IsNullOrEmpty(IncFields) || ConfigAndResource.GetResourceString("IncFieldsMsg") != IncFields)
            {
                ErrorLogs.SaveToErrorLog("Register_WO_Lastname", ConfigAndResource.GetResourceString("IncFieldsMsg"));
            }
            Assert.AreEqual(RegisterPage.titleIncFields, ConfigAndResource.GetResourceString("IncFieldsMsg"));
        }
        [TestMethod]
        public void Register_WO_EmailAddress()
        {
            RegisterPage.GoTo();
            RegisterPage.RegisterAs().CreateAccountWOEmailAddress().Register();

            Driver.Wait(TimeSpan.FromSeconds(SecondsToWait));
            var IncFields = RegisterPage.titleIncFields;
            if (string.IsNullOrEmpty(IncFields) || ConfigAndResource.GetResourceString("IncFieldsMsg") != IncFields)
            {
                ErrorLogs.SaveToErrorLog("Register_WO_EmailAddress", ConfigAndResource.GetResourceString("IncFieldsMsg"));
            }
            Assert.AreEqual(RegisterPage.titleIncFields, ConfigAndResource.GetResourceString("IncFieldsMsg"));
        }
        [TestMethod]
        public void Register_W_Inc_EmailAddress()
        {
            RegisterPage.GoTo();
            RegisterPage.RegisterAs().CreateAccountWIncEmailAddress().Register();

            Driver.Wait(TimeSpan.FromSeconds(SecondsToWait));
        }
        [TestMethod]
        public void Register_WO_Birthday()
        {
            RegisterPage.GoTo();
            RegisterPage.RegisterAs().CreateAccountWOBirthday().Register();

            Driver.Wait(TimeSpan.FromSeconds(SecondsToWait));
            var IncFields = RegisterPage.titleIncFields;
            if (string.IsNullOrEmpty(IncFields) || ConfigAndResource.GetResourceString("IncFieldsMsg") != IncFields)
            {
                ErrorLogs.SaveToErrorLog("Register_WO_Birthday", ConfigAndResource.GetResourceString("IncFieldsMsg"));
            }
            Assert.AreEqual(RegisterPage.titleIncFields, ConfigAndResource.GetResourceString("IncFieldsMsg"));
        }
        [TestMethod]
        public void Register_WO_UserName()
        {
            RegisterPage.GoTo();
            RegisterPage.RegisterAs().CreateAccountWOUserName().Register();

            Driver.Wait(TimeSpan.FromSeconds(SecondsToWait));
            var IncFields = RegisterPage.titleIncFields;
            if (string.IsNullOrEmpty(IncFields) || ConfigAndResource.GetResourceString("IncFieldsMsg") != IncFields)
            {
                ErrorLogs.SaveToErrorLog("Register_WO_UserName", ConfigAndResource.GetResourceString("IncFieldsMsg"));
            }
            Assert.AreEqual(RegisterPage.titleIncFields, ConfigAndResource.GetResourceString("IncFieldsMsg"));
        }
        [TestMethod]
        public void Register_WO_Password()
        {
            RegisterPage.GoTo();
            RegisterPage.RegisterAs().CreateAccountWOPassword().Register();

            Driver.Wait(TimeSpan.FromSeconds(SecondsToWait));
            var IncFields = RegisterPage.titleIncFields;
            if (string.IsNullOrEmpty(IncFields) || ConfigAndResource.GetResourceString("IncFieldsMsg") != IncFields)
            {
                ErrorLogs.SaveToErrorLog("Register_WO_Password", ConfigAndResource.GetResourceString("IncFieldsMsg"));
            }
            Assert.AreEqual(RegisterPage.titleIncFields, ConfigAndResource.GetResourceString("IncFieldsMsg"));
        }
        [TestMethod]
        public void Register_WO_RTPassword()
        {
            RegisterPage.GoTo();
            RegisterPage.RegisterAs().CreateAccountWORTPassword().Register();

            Driver.Wait(TimeSpan.FromSeconds(SecondsToWait));
            var IncFields = RegisterPage.titleIncFields;
            if (string.IsNullOrEmpty(IncFields) || ConfigAndResource.GetResourceString("IncFieldsMsg") != IncFields)
            {
                ErrorLogs.SaveToErrorLog("Register_WO_RTPassword", ConfigAndResource.GetResourceString("IncFieldsMsg"));
            }
            Assert.AreEqual(RegisterPage.titleIncFields, ConfigAndResource.GetResourceString("IncFieldsMsg"));
        }
        [TestMethod]
        public void Register_W_Passwords_NotIdentical()
        {
            RegisterPage.GoTo();
            RegisterPage.RegisterAs().CreateAccountWPassUnmatched().Register();

            Driver.Wait(TimeSpan.FromSeconds(SecondsToWait));
            var ARegisteredMsg = RegisterPage.title;
            if (string.IsNullOrEmpty(ARegisteredMsg) || ConfigAndResource.GetResourceString("AlreadyRegisteredMsg") != ARegisteredMsg)
            {
                ErrorLogs.SaveToErrorLog("Register_W_Passwords_NotIdentical", ConfigAndResource.GetResourceString("AlreadyRegisteredMsg"));
            }
            Assert.AreEqual(RegisterPage.title, ConfigAndResource.GetResourceString("AlreadyRegisteredMsg"));
        }
        [TestMethod]
        public void Register_W_IncBday()
        {
            RegisterPage.GoTo();
            RegisterPage.RegisterAs().CreateAccountWIncBday().Register();

            Driver.Wait(TimeSpan.FromSeconds(SecondsToWait));
            var ARegisteredMsg = RegisterPage.title;
            if (string.IsNullOrEmpty(ARegisteredMsg) || ConfigAndResource.GetResourceString("AlreadyRegisteredMsg") != ARegisteredMsg)
            {
                ErrorLogs.SaveToErrorLog("Register_W_IncBday", ConfigAndResource.GetResourceString("AlreadyRegisteredMsg"));
            }
            Assert.AreEqual(RegisterPage.title, ConfigAndResource.GetResourceString("AlreadyRegisteredMsg"));
        }


    }
}
