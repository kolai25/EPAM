using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;

namespace Automation.Pages
{
    public class LoginPage
    {
        private const string BASE_URL = "https://en.oui.sncf/";

        [FindsBy(How = How.Id, Using = "ccl-email")]
        private IWebElement inputLogin;

        [FindsBy(How = How.Id, Using = "ccl-password")]
        private IWebElement inputPassword;

        [FindsBy(How = How.XPath, Using = "//*[@id='ccl-menu']")]
        private IWebElement buttonSubmit;

        [FindsBy(How = How.XPath, Using = "//*[@id='edit-connect']")]
        private IWebElement buttonSubmitNext;

        [FindsBy(How = How.XPath, Using = "//*[@id='wcc__message']/div/text()")]
        private IWebElement linkLoggedInUser;

        [FindsBy(How = How.XPath, Using = "/html/body/div[2]/header/div/div[1]/button/span[2]/span[1]")]
        private IWebElement buttonMenu;

        private IWebDriver driver;

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(this.driver, this);
        }

        public void OpenPage()
        {
            driver.Navigate().GoToUrl(BASE_URL);
            Console.WriteLine("Login Page opened");
        }

        public void Login(string username, string password)
        {
            buttonMenu.Click();
            buttonSubmit.Click();
            
            inputLogin.SendKeys(username);
            buttonSubmitNext.Click();
            inputPassword.Click();
            inputPassword.SendKeys(password);
            buttonSubmitNext.Click();
        }

        public string GetLoggedInUserName()
        {
            return linkLoggedInUser.Text;
        }
    }
}
