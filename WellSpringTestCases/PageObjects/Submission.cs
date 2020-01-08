using OpenQA.Selenium;

namespace WellSpringTestCases.PageObjects
{
    public static class Submission
    {

        public static IWebElement GetConfirmation(IWebDriver driver)
        {
            return driver.FindElement(By.XPath($"//*[@class='freebirdFormviewerViewResponseConfirmContentContainer']/div[contains(text(), 'Your response has been recorded.')]"));
        }

        public static IWebElement GetLink(IWebDriver driver)
        {
            return driver.FindElement(By.XPath($"//*[@class='freebirdFormviewerViewResponseConfirmContentContainer']/div/a[contains(text(), 'Submit another response')]"));
        }
    }
}
