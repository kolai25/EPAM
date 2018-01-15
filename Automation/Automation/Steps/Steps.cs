using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Automation.Pages;
using System;

namespace Automation.Steps
{
    public class Steps
    {
        IWebDriver driver;
        Pages.MainPage mainPage;

        public void InitBrowser()
        {
            driver = Driver.DriverInstance.GetInstance();
        }

        public void CloseBrowser()
        {
            Driver.DriverInstance.CloseBrowser();
        }

        public void LoginIntercity(string username, string password)
        {
            Pages.LoginPage loginPage = new Pages.LoginPage(driver);
            loginPage.OpenPage();
            loginPage.Login(username, password);
        }

        public bool IsLoggedIn(string username)
        {
            Pages.LoginPage loginPage = new Pages.LoginPage(driver);
            return (loginPage.GetLoggedInUserName().Trim().ToLower().Equals(username));
        }


        public bool GetErrorNameVia(string errorMessage)
        {
            mainPage.ButtonTicketSearchClick();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            return mainPage.GetErrorSeartch(errorMessage);
        }

        public void SetStation(string from, string to)
        {
            mainPage = new Pages.MainPage(driver);
            mainPage.OpenPage();
            mainPage.SetStation(from, to);
        }
        public void SetViaReturn(string name)
        {
            mainPage.CheckboxTraveClick();
            mainPage.SetStationGoVia(name);
        }
        public void EnterChield(int countChield)
        {
            mainPage.IntupTimeFrome(countChield);
        }
        public void SearchClick()
        {
            mainPage.ButtonTicketSearchClick();
        }

        public void SetDateFrom(DateTime date)
        {

            mainPage.SetInputFromDate(date);
        }

        public void SetDateGoingTo(DateTime date)
        {

            mainPage.SetInputGoingToDate(date);
        }

        public void TimeFrome(int num)
        {

            mainPage.IntupTimeFrome(num);
        }
        public void TimeGoingTo(int num)
        {
            
            mainPage.IntupTimeFrome(num);
        }
        
        public void CountPassengersForTravel(int num)
        {

            mainPage.PassengersForTravel(num);
        }

        public void PassengersForTravelMoreClick()
        {

            mainPage.ButtonMorePassengersClick();
        }

        public void RadiobuttonComfortClassTwoClick()
        {

            mainPage.RadiobuttonComfortClassTwoClick();
        }

        public bool GetErrorTicket(string errorMessage)
        {
            
            return mainPage.GetErrorSeartch(errorMessage);
        }

        public bool Result()
        {
            var resultPage = new ResultPage(driver);
            resultPage.Result();
            return true;
        }

        public bool getError()
        {
            var resultPage = new ResultPage(driver);
            resultPage.getError();
            return true;
        }


    }
}
