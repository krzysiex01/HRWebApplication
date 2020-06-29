using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRWebApplication.UITests.Areas.User.Pages
{
    class IndexJobApplicationPage
    {
        private readonly IWebDriver _driver;
        private const string URI = "https://localhost:44342/User/JobApplication";

        private IWebElement SearchInput => _driver.FindElement(By.Id("Search"));
        private IWebElement SearchButton => _driver.FindElement(By.Id("SearchButton"));
        private IWebElement SortByNameButton => _driver.FindElement(By.Id("optionNameSort"));
        private IWebElement SortByNameDescButton => _driver.FindElement(By.Id("optionNameDescSort"));
        private IWebElement SortByDateButton => _driver.FindElement(By.Id("optionDateSort"));
        public IWebElement JobApplicationListDiv => _driver.FindElement(By.Id("JobApplicationList"));

        public string Title => _driver.Title;
        public string Source => _driver.PageSource;

        public IndexJobApplicationPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public void Navigate() => _driver.Navigate().GoToUrl(URI);

        public void PopulateSearchInput(string searchPhrase) => SearchInput.SendKeys(searchPhrase);
        public void ClickSearch() => SearchButton.Click();
        public void ClickSortName() => SortByNameButton.Click();
        public void ClickSortNameDesc() => SortByNameDescButton.Click();
        public void ClickSortDate() => SortByDateButton.Click();
    }
}
