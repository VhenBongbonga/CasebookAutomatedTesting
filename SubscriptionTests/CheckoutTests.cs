using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CasebookAutomation;

namespace SubscriptionTests
{
    [TestClass]
    public class CheckoutTests : SubscriptionTest
    {
        private const int secondstowait = 2;
        [TestMethod]
        public void UserCanGoBack()
        {
            DashboardPage.GoTo6monthsSubscription();
            CheckoutPage.GoBack();
            Driver.Wait(TimeSpan.FromSeconds(secondstowait));
            var msg = DashboardPage.DashboardPageTitle;
            if (string.IsNullOrEmpty(msg) || msg != ConfigAndResource.GetResourceString("DashboardPageTitle"))
            { ErrorLogs.SaveToErrorLog("GoTo6monthsSubscription", ConfigAndResource.GetResourceString("DashboardPageTitle")); }
            Assert.AreEqual(msg, ConfigAndResource.GetResourceString("DashboardPageTitle"));
        }
        [TestMethod]
        public void UserCanPurchase()
        {
            DashboardPage.GoTo6monthsSubscription();
            CheckoutPage.Purchase();
            Driver.Wait(TimeSpan.FromSeconds(secondstowait));
            var msg = CheckoutPage.PurchaseModal;
            if (string.IsNullOrEmpty(msg) || msg != ConfigAndResource.GetResourceString("PurchaseModal"))
            { ErrorLogs.SaveToErrorLog("UserCanPurchase", ConfigAndResource.GetResourceString("PurchaseModal")); }
            Assert.AreEqual(msg, ConfigAndResource.GetResourceString("PurchaseModal"));
        }
        [TestMethod]
        public void UserBuy6monthsSubscriptionWithCorrectCNPW()
        {
            DashboardPage.GoTo6monthsSubscription();
            CheckoutPage.Purchase();
            Driver.Wait(TimeSpan.FromSeconds(secondstowait));
            Assert.AreEqual(CheckoutPage.PurchaseModal, ConfigAndResource.GetResourceString("PurchaseModal"));
            CheckoutPage.CheckoutAs().Buy6monthsSubscriptionWithCorrectPassword().Checkout();
            Driver.Wait(TimeSpan.FromSeconds(secondstowait));
            var msg = DashboardPage.GetExpirationDate;

            DateTime previousexpdate = Convert.ToDateTime(SubscriptionExpirationDate.Get()).Date;
            DateTime actualdate = Convert.ToDateTime(msg).Date;
            var datespan = actualdate.Subtract(previousexpdate).Days / (365 / 12);
            if (string.IsNullOrEmpty(msg) || datespan != 6)
            { ErrorLogs.SaveToErrorLog("UserBuy6monthsSubscriptionWithCorrectCNPW", actualdate.ToString()); }
            Assert.AreEqual(datespan, 6);
        }
        [TestMethod]
        public void UserBuy6monthsSubscriptionWithCorrectCNIncorrectPW()
        {
            DashboardPage.GoTo6monthsSubscription();
            CheckoutPage.Purchase();
            Driver.Wait(TimeSpan.FromSeconds(secondstowait));
            Assert.AreEqual(CheckoutPage.PurchaseModal, ConfigAndResource.GetResourceString("PurchaseModal"));
            CheckoutPage.CheckoutAs().Buy6monthsSubscriptionWithWrongPassword().Checkout();
            Driver.Wait(TimeSpan.FromSeconds(secondstowait));
            var msg = CheckoutPage.CheckoutFailedMessage;
            if (string.IsNullOrEmpty(msg) || msg != ConfigAndResource.GetResourceString("CheckoutFailedMessage"))
            { ErrorLogs.SaveToErrorLog("UserBuy6monthsSubscriptionWithCorrectCNIncorrectPW", ConfigAndResource.GetResourceString("CheckoutFailedMessage")); }
            Assert.AreEqual(msg, ConfigAndResource.GetResourceString("CheckoutFailedMessage"));
        }
        
    }
}
