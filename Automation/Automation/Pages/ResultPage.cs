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
    public class ResultPage
    {
        
        private IWebDriver driver;

        public ResultPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(this.driver, this);
        }

        public bool Result()
        {
            try
            {
                IWebElement resultList = driver.FindElement(By.ClassName("boxShadow  scheduledCon"));
            }
            catch
            {
                return false;
            }
            return true;
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


    }


        
}
