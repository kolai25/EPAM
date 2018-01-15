using NUnit.Framework;
using System;

namespace Automation
{
    [TestFixture]
    public class SmokeTests
    {
        private Steps.Steps steps = new Steps.Steps();
        private const string USERNAME = "q3181309@gmail.com";
        private const string PASSWORD = "14ifeduf";
        private const string FROM = "Rome";
        private const string TO = "Berlin"; 
        private const string INVALID_NAME = "Minsk";
        private const string MISSING_NAME_ERROR_MESSAGE = "Please enter a valid station name or code";
        private const string MISSING_TIME_ERROR_MESSAGE = "Your return journey is earlier than your outward journey";
        private const string MISSING_Chield_ERROR_MESSAGE = "Please select up to 9 travellers";
        private const string MISSING_Time_ERROR_MESSAGE = "As you are completing your return journey in the same day, the departure time for the outward journey must be later than that for your return journey. Please change either the dates or the times.";
        private const string MISSING_Day_ERROR_MESSAGE = "You have not entered a return date.";

       

        [SetUp]
        public void Init()
        {
            steps.InitBrowser();
        }

        [TearDown]
        public void Cleanup()
        {
         // steps.CloseBrowser();
        }

        [Test]
        public void OneCanLogin()
        {
            steps.LoginIntercity(USERNAME, PASSWORD);
            Assert.True(steps.IsLoggedIn(USERNAME));
        }

        [Test]
        public void SertchNoParameters()
        {
            steps.SearchClick();
            Assert.True(steps.getError());
        }

        [Test]
        public void SertchParameters()
        {
            steps.SetStation(FROM,TO);
            steps.SearchClick();
            
        }

        [Test]
        public void SertchParametersAndDate()
        {
            steps.SetStation(FROM, TO);
            steps.SetDateFrom(DateTime.Now);
            steps.SearchClick();
            Assert.IsTrue(steps.IsLoggedIn(USERNAME));
        }

        [Test]
        public void SertchParametersDateTime()
        {
            steps.SetStation(FROM, TO);
            steps.SetDateFrom(DateTime.Now);
            steps.TimeFrome(23);
            steps.SearchClick();
            Assert.IsTrue(steps.Result());

        }

        [Test]
        public void SertchParametersDateTimeInvalid()
        {
            steps.SetStation(FROM, TO);
            steps.SetDateFrom(DateTime.Now);
            steps.SetDateGoingTo(DateTime.Now.AddDays(-1));
            steps.TimeFrome(23);
            steps.TimeGoingTo(22);
            steps.SearchClick();
            Assert.IsTrue(steps.GetErrorTicket(MISSING_Day_ERROR_MESSAGE));
        }

        public void PassengersForTravelMoreNine()
        {
            steps.SetStation(FROM, TO);
            steps.SetDateFrom(DateTime.Now);
            steps.SetDateGoingTo(DateTime.Now.AddDays(1));
            steps.TimeFrome(23);
            steps.TimeGoingTo(22);
            steps.PassengersForTravelMoreClick();
            steps.SearchClick();
           /////// Assert.IsTrue(steps.getError());
        }

        [Test]
        public void SertchParametersViaReturn()
        {
            steps.SetStation(FROM, TO);
            steps.SetDateFrom(DateTime.Now);
            steps.SetDateGoingTo(DateTime.Now.AddDays(1));
            steps.TimeFrome(13);
            steps.TimeGoingTo(22);
            steps.SetViaReturn(INVALID_NAME);
            steps.SearchClick();
            Assert.IsTrue(steps.Result());

        }

        [Test]
        public void PassengersForTravel()
        {
            steps.SetStation(FROM, TO);
            steps.SetDateFrom(DateTime.Now);
            steps.SetDateGoingTo(DateTime.Now.AddDays(1));
            steps.TimeFrome(13);
            steps.TimeGoingTo(22);
            steps.CountPassengersForTravel(9);
            steps.SearchClick();
            Assert.IsTrue(steps.Result());

        }

        [Test]
        public void SertchParametersDateTimeInvalid1()
        {
            steps.SetStation(FROM, TO);
            steps.SetDateFrom(DateTime.Now);
            steps.SetDateGoingTo(DateTime.Now.AddDays(1));
            steps.TimeFrome(12);
            steps.TimeGoingTo(13);
            steps.SearchClick();
            Assert.True(steps.GetErrorTicket(MISSING_Time_ERROR_MESSAGE));
        }

        public void ComfortClassTwoClick()
        {
            steps.SetStation(FROM, TO);
            steps.SetDateFrom(DateTime.Now);
            steps.SetDateGoingTo(DateTime.Now.AddDays(1));
            steps.TimeFrome(12);
            steps.TimeGoingTo(13);
            steps.RadiobuttonComfortClassTwoClick();
            steps.SearchClick();
            Assert.IsTrue(steps.Result());

        }

        
    }
    
}
