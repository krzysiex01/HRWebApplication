using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium.Support.UI;

namespace HRWebApplication.UITests
{
    class LoginPage
    {
        private readonly IWebDriver _driver;
        private const string URI = "https://localhost:44342/auth/login";
        private IWebElement LoginInput => _driver.FindElement(By.Id("logonIdentifier"));
        private IWebElement PasswordInput => _driver.FindElement(By.Id("password"));
        private IWebElement LoginButton => _driver.FindElement(By.Id("next"));

        public LoginPage(IWebDriver webDriver)
        {
            _driver = webDriver;
        }

        public void Navigate()
        {
            _driver.Navigate().GoToUrl(URI);
            _driver.FindElement(By.Id("logonIdentifier"), 5);
            _driver.FindElement(By.Id("password"), 5);
            _driver.FindElement(By.Id("next"), 5);
        }

        public void EnterPassword(string password) { PasswordInput.Clear(); PasswordInput.SendKeys(password); }
        public void EnterLogin(string login) { LoginInput.Clear(); LoginInput.SendKeys(login); }
        public void ClickLoginButton() => LoginButton.Click();
        public void WaitForSuccessfullSignIn()
        {
            _driver.FindElement(By.Id("signOut"), 5);
        }
    }
}
