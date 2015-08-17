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
    public class ResidualIncomeAdjustmentToolWith2014 : DriverTestCase
    {
        [TestMethod]
        public void residualIncomeAdjustmentToolWith2014()
        {
           string[] username = null;
           string[] password = null;

            XMLParse oXMLData = new XMLParse();
            oXMLData.LoadXML("../../Config/ApplicationSettings.xml");

          username = oXMLData.getData("settings/Credentials", "username");
           password = oXMLData.getData("settings/Credentials", "password");

            //Initializing the objects
           ResidualIncmeOfficeHelper residualIncmeOfficeHelper = new ResidualIncmeOfficeHelper(GetWebDriver());

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
            GetWebDriver().Navigate().GoToUrl("https://www.pegasus-test.com/selenium_corp/selenium_office/rir/adjustments_tool");

            //Click on Craete button
            residualIncmeOfficeHelper.ClickElement("ClickOnCreateBtn");
            residualIncmeOfficeHelper.WaitForWorkAround(3000);

            //Click on Save button
            residualIncmeOfficeHelper.ClickElement("ClickOnSaveBtn");
            residualIncmeOfficeHelper.WaitForWorkAround(2000);

            //Enter Adjustment Name
            residualIncmeOfficeHelper.TypeText("AdjustmentName", AdjName);

            //Enter Description
            residualIncmeOfficeHelper.TypeText("Description", "This is testing Description");

            //Select AdjustmentFor'
            residualIncmeOfficeHelper.Select("AdjustmentFor", "Agent");

            //Select Adjustment Type
            residualIncmeOfficeHelper.Select("AdjustmentType", "Transaction");

            //Select Reporting Period 
            residualIncmeOfficeHelper.Select("ReportingPeriod", "01");

            //Select Reporting year
            residualIncmeOfficeHelper.Select("SelectYearReporting", "2014");

            //Select Processor
            residualIncmeOfficeHelper.Select("Processor", "Any");

            //Click Radio button apply to all merchnat
            residualIncmeOfficeHelper.ClickElement("ApplyBeforRevenueShareCollection");

          //Create Rule
            residualIncmeOfficeHelper.Select("SelectRuleType", "1");

            //Enter Percentage Amount
            residualIncmeOfficeHelper.TypeText("Amount", "50");

            //Remove
            residualIncmeOfficeHelper.Select("AddRemove", "Remove");

            //Click on Save button
            residualIncmeOfficeHelper.ClickElement("ClickOnSaveBtn");
            residualIncmeOfficeHelper.WaitForWorkAround(2000);

            residualIncmeOfficeHelper.VerifyPageText(AdjName);
            residualIncmeOfficeHelper.WaitForWorkAround(2000);


            //Enter Rule to search
            residualIncmeOfficeHelper.TypeText("EnterRuleToSearch",AdjName);
            residualIncmeOfficeHelper.WaitForWorkAround(3000);

            //Click on Rule
            residualIncmeOfficeHelper.ClickElement("ClickonRule");
            residualIncmeOfficeHelper.WaitForWorkAround(4000);

        }
    }
}
