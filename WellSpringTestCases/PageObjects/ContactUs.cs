using OpenQA.Selenium;

namespace WellSpringTestCases.PageObjects
{
    public static class ContactUs
    {
        public static string BaseUrl = @"https://forms.gle/U82EZX49B1qM1emdA";

        public static string GetUrl()
        {
            return BaseUrl;
        }

        public static IWebElement GetRadioByLabel(IWebDriver driver, string radio)
        {
            return driver.FindElement(By.XPath($"//*[@class='freebirdFormviewerViewItemsRadioChoicesContainer']//descendant::div[@data-value='{radio}']"));
        }

        public static IWebElement GetTextboxByHeader(IWebDriver driver, string headerName)
        {
            return driver.FindElement(By.XPath($"//*[@class='freebirdFormviewerViewNumberedItemContainer']//descendant::div[@class='quantumWizTextinputPaperinputInputArea']/input[@aria-label='{headerName}']"));
        }

        public static IWebElement GetMessageTextbox(IWebDriver driver)
        {
            return driver.FindElement(By.XPath($"//*[@class='freebirdFormviewerViewNumberedItemContainer']//descendant::div[@class='quantumWizTextinputPapertextareaContentArea exportContentArea']/textarea[@aria-label='Message']"));
        }

        public static IWebElement GetCheckboxbyLabel(IWebDriver driver, string label)
        {
            return driver.FindElement(By.XPath($"//*[@class='freebirdFormviewerViewNumberedItemContainer']//descendant::div[@aria-label='{label}']"));
        }

        public static IWebElement GetSubmitButton(IWebDriver driver)
        {
            return driver.FindElement(By.XPath($"//*[@class='appsMaterialWizButtonPaperbuttonContent exportButtonContent']/span[contains(text(), 'Submit')]"));
        }
    }
}