using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;

namespace Automation.Pages
{
    public class MainPage
    {
        private const string BASE_URL = "https://en.oui.sncf/";

        [FindsBy(How = How.XPath, Using = "//*[@id='vsc__menu - rub']/li[2]/span")]
        private IWebElement buttonBook;
        
        [FindsBy(How = How.XPath, Using = "//*[@id='vsc__menu - rub']/li[2]/ul/li[2]/a")]
        private IWebElement buttonTicket;
        
        [FindsBy(How = How.XPath, Using = "//*[@id='block - vsct_feature_canvas - hermes - canvas - header']/header/div/div[1]/button")]
        private IWebElement buttonMenu;

        [FindsBy(How = How.XPath, Using = "//*[@id='CMD_CMD_VALIDATION']")]
        private IWebElement buttonTicketSearch;

        [FindsBy(How = How.XPath, Using = "//*[@id='group - booking']")]
        private IWebElement buttonMorePassengers;

        //inputtext

        [FindsBy(How = How.XPath, Using = "//*[@id='ORIGIN_CITY']")]
        private IWebElement inputFrome;

        [FindsBy(How = How.XPath, Using = "//*[@id='VIA_CITY']")]
        private IWebElement inputGoVia;

        [FindsBy(How = How.XPath, Using = "//*[@id='DESTINATION_CITY']")]
        private IWebElement inputGoingTo;

        //checkbox
        
        [FindsBy(How = How.XPath, Using = "//*[@id='DIRECT_TRAVEL_CHECK']")]
        private IWebElement checkboxTravel;

        //radiobutton

        [FindsBy(How = How.XPath, Using = "//*[@id='COMFORT_CLASS_1']")]
        private IWebElement radiobuttonComfortClassOne;
        

        [FindsBy(How = How.XPath, Using = "//*[@id='COMFORT_CLASS_2']")]
        private IWebElement radiobuttonComfortClassTwo;
        
        //inputdate

        [FindsBy(How = How.XPath, Using = "//*[@id='OUTWARD_DATE']")]
        private IWebElement inputDateFrome;

        [FindsBy(How = How.XPath, Using = "//*[@id='INWARD_DATE']")]
        private IWebElement inputDateGoingTo;

        [FindsBy(How = How.XPath, Using = "//*[@id='OUTWARD_TIME']")]
        private IWebElement inputTimeFrome;

        [FindsBy(How = How.XPath, Using = "//*[@id='INWARD_TIME']")]
        private IWebElement inputTimeGoingTo;
        

        //erors
        [FindsBy(How = How.XPath, Using = "//*[@id='messages_MEA_count']/div[2]")]
        private IWebElement divErrorTicketSearch;


        private IWebDriver driver;

        public MainPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(this.driver, this);
        }


        //button click
        public void ButtonTicketClick()
        {
            buttonTicket.Click();
        }

        public void ButtonMenuClick()
        {
            buttonMenu.Click();
        }
        public void ButtonTicketSearchClick()
        {
            buttonTicketSearch.Click();
        }
        
        public void ButtonMorePassengersClick()
        {
            buttonMorePassengers.Click();
        }
        public void ButtonBookClick()
        {
            buttonBook.Click();
        }

        //checkbox click
        public void CheckboxTraveClick()
        {
            checkboxTravel.Click();
        }

        //radiobutton click
        public void RadiobuttonComfortClassOneClick()
        {
            radiobuttonComfortClassOne.Click();
        }
        public void RadiobuttonComfortClassTwoClick()
        {
            radiobuttonComfortClassTwo.Click();
        }

        //input 

        public void SetStation(string from, string to)
        {
            inputFrome.SendKeys(from);
            inputGoingTo.SendKeys(to);
        }
        
        public void SetStationGoVia(string name)
        {
            inputGoVia.SendKeys(name);
        }

        public void SetInputFromDate(DateTime date)
        {
            inputFrome.SendKeys(date.ToString("dd/mm/yyyy"));
        }

       
        public void SetInputGoingToDate(DateTime date)
        {
            inputGoingTo.SendKeys(date.ToString("dd/mm/yyyy"));
        }


        public void IntupTimeFrome(int countChield)
        {
            if (countChield <= 23)
            {
                IWebElement col = driver.FindElement(By.XPath("//*[@id='OUTWARD_TIME']"));
                SelectElement sl = new SelectElement(col);
                sl.SelectByText(Convert.ToString(countChield));
            }
        }

        public void PassengersForTravel(int countChield)
        {
            if (countChield <= 9)
            {
                IWebElement col = driver.FindElement(By.XPath("//*[@id='nbPassengersForTravel']"));
                SelectElement sl = new SelectElement(col);
                sl.SelectByText(Convert.ToString(countChield));
            }
        }

        public void IntupTimeGoingTo(int countChield)
        {
            if (countChield <= 23)
            {
                IWebElement col = driver.FindElement(By.XPath("//*[@id='INWARD_DATE']"));
                SelectElement sl = new SelectElement(col);
                sl.SelectByText(Convert.ToString(countChield));
            }
        }

        //GetError
        public bool GetErrorSeartch(string errorMessage)
        {
            return divErrorTicketSearch.Text == errorMessage;
        }

        public bool getError()
        {
            try
            {
                IWebElement dataError = driver.FindElement(By.Id("error-messages-container"));
            }
            catch
            {
                return false;
            }
            return true;
        }

        public void OpenPage()
        {
            driver.Navigate().GoToUrl(BASE_URL);
        }

        public void ClickOnCreateNewRepositoryButton()
        {
            buttonMenu.Click();
            buttonBook.Click();
            buttonTicket.Click();
            buttonTicketSearch.Click();
        }

        public string GetLoggedInUserName()
        {
            return divErrorTicketSearch.Text;
        }

       

    }
}
