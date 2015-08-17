using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using PegasusTests.PageHelper;
using PegasusTests.PageHelper.Comm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace PegasusTests.Scripts.ClientsTests
{
    [TestClass]
    public class ResidualIncomePayoutSummaryOfficeViewReports : DriverTestCase
    {
        [TestMethod]
        public void residualIncomePayoutSummaryOfficeViewReports()
        {
           string[] username = null;
           string[] password = null;

            XMLParse oXMLData = new XMLParse();
            oXMLData.LoadXML("../../Config/ApplicationSettings.xml");

          username = oXMLData.getData("settings/Credentials", "username");
           password = oXMLData.getData("settings/Credentials", "password");

            //Initializing the objects
           var residualIncmeOfficeHelper = new ResidualIncmeOfficeHelper(GetWebDriver());
           var clientBugsHelper = new ClientBugsHelper(GetWebDriver());

            //Variable 
           String AdjName = "Rule Test" + RandomNumber(1,99);

           //Login with valid username and password
           Login(username[0], password[0]);
           Console.WriteLine("Logged in as: " + username[0] + " / " + password[0]);

           //Verify Page title
           VerifyTitle("Dashboard");
           Console.WriteLine("Redirected at Dashboard screen.");

             //Click on Residual Income tab
           residualIncmeOfficeHelper.ClickElement("ClickOnResidualIncome");

            //Goto Adjustment rule
           GetWebDriver().Navigate().GoToUrl("https://www.pegasus-test.com/selenium_corp/selenium_office/rir/payout_summary");
           clientBugsHelper.WaitForWorkAround(4000);

            //File Format
           clientBugsHelper.Select("FileFormat", "First Data North");
           clientBugsHelper.WaitForWorkAround(3000);

           //Select Status
          // clientBugsHelper.Select("SelectStatusRIReport", "Published");
          // clientBugsHelper.WaitForWorkAround(3000);

            //Click On RI Date
           clientBugsHelper.ClickElement("ClickOnRIDate");
           clientBugsHelper.WaitForWorkAround(3000);

     

        }
    }
}
