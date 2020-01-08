using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace WellspringTestCase.Tests
{
    public class TestBase
    {
        public IWebDriver driver;

        public void Initialize()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(15);
        }

        public void OpenPage(string url)
        {
            driver.Url = url;
            driver.Navigate();
        }

    }
}
