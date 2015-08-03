using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CasebookAutomation;
namespace SubscriptionTests
{
    [TestClass]
    public class DashboardTests : SubscriptionTest
    {
        private const int secondstowait = 3;

        [TestMethod]
        public void UserCanLogout()
        {
            DashboardPage.UserLogout();
            Driver.Wait(TimeSpan.FromSeconds(secondstowait));
            var msg = LoginPage.LogoutMessage;
            if (string.IsNullOrEmpty(msg))
            { ErrorLogs.SaveToErrorLog("UserCanLogout", ConfigAndResource.GetResourceString("LandingPageTitle")); }
            Assert.AreEqual(msg, ConfigAndResource.GetResourceString("LandingPageTitle"));
        }
        [TestMethod]
        public void UserCanBuy6monthsSubscription()
        {
            DashboardPage.GoTo6monthsSubscription();
            Driver.Wait(TimeSpan.FromSeconds(secondstowait));
            var msg = CheckoutPage.TotalAmount;
            if (string.IsNullOrEmpty(msg))
            { ErrorLogs.SaveToErrorLog("UserCanBuy6monthsSubscription", ConfigAndResource.GetResourceString("TotalAmount6Months")); }
            Assert.AreEqual(msg, ConfigAndResource.GetResourceString("TotalAmount6Months"));
        }
        [TestMethod]
        public void UserCanBuy12monthsSubscription()
        {

            DashboardPage.GoTo12monthsSubscription();
            Driver.Wait(TimeSpan.FromSeconds(secondstowait));
            var msg = CheckoutPage.TotalAmount;
            if (string.IsNullOrEmpty(msg))
            { ErrorLogs.SaveToErrorLog("UserCanBuy12monthsSubscription", ConfigAndResource.GetResourceString("TotalAmount12Months")); }
            Assert.AreEqual(msg, ConfigAndResource.GetResourceString("TotalAmount12Months"));
        }

        //[TestMethod]
        //public void New_User_Can_Buy_6months_Subscription()
        //{
        //    LoginPage.GoTo();
        //    LoginPage.RollNumber("041514").WithPassword("nllnlf41514").Login();
        //    DashboardPage.GoTo6monthsSubscription();
        //    System.Threading.Thread.Sleep(5000);
        //    Assert.AreEqual(CheckoutPage.total, "₱500.00");
        //}
        //[TestMethod]
        //public void New_User_Can_Buy_12months_Subscription()
        //{
        //    LoginPage.GoTo();
        //    LoginPage.RollNumber("041514").WithPassword("nllnlf41514").Login();
        //    DashboardPage.GoTo12monthsSubscription();
        //    System.Threading.Thread.Sleep(5000);
        //    Assert.AreEqual(CheckoutPage.total, "₱1,000.00");
        //}
    }
}
