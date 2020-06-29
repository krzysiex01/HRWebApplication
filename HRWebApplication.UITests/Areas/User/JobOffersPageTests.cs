using HRWebApplication.UITests.Areas.User.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Xunit;

namespace HRWebApplication.UITests.Areas.User
{
    public class JobOffersPageTests : IDisposable
    {
        private readonly IWebDriver _driver;
        private readonly IndexJobOfferPage _page;
        public JobOffersPageTests()
        {
            var options = new ChromeOptions();
            options.AddArguments("--incognito");
            _driver = new ChromeDriver(options);
            _page = new IndexJobOfferPage(_driver);
            _driver.Manage().Cookies.DeleteAllCookies();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
        }

        /// <summary>
        /// Preforms whole sign-in procedure.
        /// </summary>
        private void Authenticate()
        {
            var loginPage = new LoginPage(_driver);
            loginPage.Navigate();
            loginPage.EnterLogin("hrwebapplication.user@wp.pl");
            loginPage.EnterPassword("123456789");
            Thread.Sleep(500);
            loginPage.ClickLoginButton();
            loginPage.WaitForSuccessfullSignIn();
        }

        [Fact]
        public void Index_WhenExecuted_ReturnsJobOfferIndexView()
        {
            Authenticate();
            _page.Navigate();
            Assert.Equal("Job Offers - HRWebApplication", _page.Title);
        }

        [Fact]
        public void Index_SearchFowNonExistingOffer_ReturnsEmptyList()
        {
            Authenticate();
            _page.Navigate();
            _page.PopulateSearchInput("Non-existing offer title");
            _page.ClickSearch();

            Assert.Contains("No offers found!",_page.JobOfferListDiv.Text);
        }
       
        public void Dispose()
        {
            _driver.Quit();
            _driver.Dispose();
        }
    }
}
