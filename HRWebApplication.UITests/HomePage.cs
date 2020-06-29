using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRWebApplication.UITests
{
    class HomePage
    {
        private readonly IWebDriver _driver;
        private const string URI = "https://localhost:44342/";

        public HomePage(IWebDriver webDriver)
        {
            _driver = webDriver;
        }

        public void Navigate() => _driver.Navigate().GoToUrl(URI);
        public void ClickSignInButton() => SignInButton.Click();

        private IWebElement SignInButton => _driver.FindElement(By.Id("SignInButton"));

    }
}
