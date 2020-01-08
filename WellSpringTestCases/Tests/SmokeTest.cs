using System;
using NUnit.Framework;
using OpenQA.Selenium;
using WellSpringTestCases.PageObjects;

namespace WellspringTestCase.Tests
{
    public class SmokeTest : TestBase
    {

        [OneTimeSetUp]
        public void FirstTimeSetup()
        {
            Initialize();
            OpenPage(ContactUs.GetUrl());
        }

        [OneTimeTearDown]
        public void SuiteTeardown()
        {
            driver.Close();
            driver.Dispose();
        }

        [SetUp]
        public void ReloadPage()
        {
            OpenPage(ContactUs.GetUrl());

            try
            {
                IAlert alert = driver.SwitchTo().Alert();
                alert.Accept();
            }
            catch(NoAlertPresentException)
            {
                //Do nothing because there is no alert to accept, required to accept for tests past the first one
            }
            
        }

        [TestCase]
        [Description("Selecting a radio item based on label")]
        public void SelectRadioButton()
        {
            string label = "Tech Scouting";

            IWebElement button = ContactUs.GetRadioByLabel(driver, label);
            button.Click();

            Assert.That(Convert.ToBoolean(button.GetAttribute("aria-checked")), $"The radio button with label, {label}, was not selected on the page.");
        }

        [TestCase]
        [Description("Selecting the check box on the page to verify its functionality")]
        public void SelectCheckbox()
        {
            string label = "Include me in future mailings";

            IWebElement checkbox = ContactUs.GetCheckboxbyLabel(driver, label);
            checkbox.Click();

            Assert.That(Convert.ToBoolean(checkbox.GetAttribute("aria-checked")), $"The checkbox button with label, {label}, was not selected on the page.");
        }

        [TestCase]
        [Description("Enter text into the First Name section and verify text was entered.")]
        public void AddingFirstName()
        {
            string name = "Jack";

            IWebElement firstNameTextBox = ContactUs.GetTextboxByHeader(driver, "First Name");
            firstNameTextBox.SendKeys(name);

            string text = firstNameTextBox.GetAttribute("data-initial-value");
            Assert.That(name.Equals(text), $"The text entered did not equal the expected text, {name}, instead, {text}, was entered.");
        }

        [TestCase]
        [Description("Enter all info and Submit to verify submission works.")]
        public void SmokeTestofPage()
        {
            string radio = "Corporate Relations";

            IWebElement button = ContactUs.GetRadioByLabel(driver, radio);
            button.Click();

            string header = "First Name";
            string firstName = "Peter";

            IWebElement firstNameTextBox = ContactUs.GetTextboxByHeader(driver, header);
            firstNameTextBox.SendKeys(firstName);

            header = "Last Name";
            string lastName = "Parker";

            IWebElement lastNameTextBox = ContactUs.GetTextboxByHeader(driver, header);
            lastNameTextBox.SendKeys(lastName);

            header = "Email";
            string email = "spidermanrules@dailybugle.com";

            IWebElement emailTextBox = ContactUs.GetTextboxByHeader(driver, header);
            emailTextBox.SendKeys(email);

            string checkbox = "Include me in future mailings";

            IWebElement box = ContactUs.GetCheckboxbyLabel(driver, checkbox);
            box.Click();

            header = "Phone (Optional)";
            string phone = "(123)456-7890";

            IWebElement phoneTextBox = ContactUs.GetTextboxByHeader(driver, header);
            phoneTextBox.SendKeys(phone);

            string message = "Please stop hating on spidey, hes trying his best.";

            IWebElement messageTextBox = ContactUs.GetMessageTextbox(driver);
            messageTextBox.SendKeys(message);

            IWebElement submit = ContactUs.GetSubmitButton(driver);
            submit.Click();

            try
            {
                IWebElement confirm = Submission.GetConfirmation(driver);
            }
            catch(NoSuchElementException e)
            {
                Assert.Fail($"The confirmation element and text was not on the page and therefore the submission was not successful. {e.Message}");
            }
        }

    }
}
