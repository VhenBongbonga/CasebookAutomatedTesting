using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Resources;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CasebookAutomation;

namespace SubscriptionTests
{
    public class SubscriptionTest
    {
        [TestInitialize]
        public void Init()
        {
            Driver.Initialize();
            LoginPage.GoTo();
            LoginPage.LoginAs().LoginWithCorrectCredentials().Login();

            Driver.Wait(TimeSpan.FromSeconds(3));
            var msg = DashboardPage.DashboardPageTitle;
            if (string.IsNullOrEmpty(msg))
            { ErrorLogs.SaveToErrorLog("UserLoginCorrectCredentials", ConfigAndResource.GetResourceString("DashboardPageTitle")); }
            Assert.AreEqual(msg, ConfigAndResource.GetResourceString("DashboardPageTitle"));
            SubscriptionExpirationDate.Save(DashboardPage.GetExpirationDate);
        }

        //[TestCleanup]
        //public void Cleanup()
        //{
        //    Driver.Close();
        //}
    }
}
