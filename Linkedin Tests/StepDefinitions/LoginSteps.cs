using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using TechTalk.SpecFlow;

namespace Linkedin_Tests.StepDefinitions
{
    [Binding]
    public class LoginSteps
    {
        public static IWebDriver? driver;
        private IWebElement? passwordInput;


        // [BeforeScenario]
        //public void InitializeBrowser()
        //{
        //  driver = new ChromeDriver();
        //driver.Url = "https://www.google.com";
        //driver.Manage().Window.Maximize();
        //}
        //[AfterScenario]
        // public void CleanupBrowser()
        //{
        //  driver?.Quit();
        //}

        [BeforeFeature]
        public static void InitializeBrowser()
        {
            driver = new ChromeDriver();
        }








        [Given(@"User will be on the login page")]
        public void GivenUserWillBeOnTheLoginPage()
        {

            driver.Url = "https://www.Linkedin.com";

        }
        [AfterFeature]
        public static void CleanUp()
        {
            driver?.Quit();
        }

        [When(@"User will enter username '(.*)'")]
        public void WhenUserWillEnterUsername(string un)
        {

            DefaultWait<IWebDriver?> fluentWait = new DefaultWait<IWebDriver?>(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(10);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(100);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentWait.Message = "Element not found";

            IWebElement emailInput = fluentWait.Until(d => d.FindElement(By.Id("session_key")));
            emailInput.SendKeys(un);


        }

        [When(@"User will enter password '(.*)'")]
        public void WhenUserWillEnterPassword(string pwd)
        {

            DefaultWait<IWebDriver?> fluentWait = new DefaultWait<IWebDriver?>(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(10);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(100);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentWait.Message = "Element not found";


            passwordInput = fluentWait.Until(d => d.FindElement(By.Id("session_password")));
            passwordInput.SendKeys(pwd);
            Console.WriteLine(passwordInput.GetAttribute("value"));
        }

        [When(@"User will click on login  button")]
        public void WhenUserWillClickOnLoginButton()
        {
            IJavaScriptExecutor? js = (IJavaScriptExecutor?)driver;
            js?.ExecuteScript("arguments[0].scrollIntoView(true);", driver?.FindElement(By.XPath("//button[@type='submit']")));

            Thread.Sleep(5000);
            js?.ExecuteScript("arguments[0].click();", driver?.FindElement(By.XPath("//button[@type='submit']")));
        }

        [Then(@"User will be redirected to Homepage")]
        public void ThenUserWillBeRedirectedToHomepage()
        {
            Assert.That(driver.Title.Contains("Log In"));
        }
        [Then(@"Error message for Password Length should be thrown")]
        
        public void ThenErrorMessageForPasswordLengthShouldBeThrown()
        {

            Thread.Sleep(5000);
            IWebElement? alertPara = driver?.FindElement(By.XPath("//p[@for='session_password']"));
            string? alertText = alertPara?.Text;
            Assert.That(alertText.Contains("password"));
        }
        [When(@"User will click on show button in the password text box")]
        public void WhenUserWillClickOnShowButtonInThePasswordTextBox()
        {
            IWebElement showButton = driver.FindElement(By.XPath("//button[text()='Show']"));
            showButton.Click();
        }

        [Then(@"The password characters should be shown")]
        public void ThenThePasswordCharactersShouldBeShown()
        {
            Assert.That(passwordInput.GetAttribute("type").Equals("text"));
        }

        [When(@"User will click on hide button in the password text box")]
        public void WhenUserWillClickOnHideButtonInThePasswordTextBox()
        {
            IWebElement hideButton = driver.FindElement(By.XPath("//button[text()='Hide']"));
            hideButton.Click();
        }

        [Then(@"The password characters should not be shown")]
        public void ThenThePasswordCharactersShouldNotBeShown()
        {
            Assert.That(passwordInput.GetAttribute("type").Equals("password"));
        }

        
    }



}
