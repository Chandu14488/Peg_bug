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
    public class ResidualIncomeSummaryReportFilter : DriverTestCase
    {
        [TestMethod]
        public void residualIncomeSummaryReportFilter()
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
       //     GetWebDriver().Navigate().GoToUrl("https://www.pegasus-test.com/selenium_corp/selenium_office/rir/adjustments_tool");
           residualIncmeOfficeHelper.ClickElement("ReportSummaryLink");
           residualIncmeOfficeHelper.WaitForWorkAround(4000);

            //Set Filter 
           residualIncmeOfficeHelper.Select("SetFilterProcessor", "First Data North");
           residualIncmeOfficeHelper.WaitForWorkAround(4000);

            //Veify FND
           residualIncmeOfficeHelper.VerifyText("VerifyTextFND", "First Data North");

           //Set Filter 
           residualIncmeOfficeHelper.Select("SetFilterProcessor", "WorldPay");
           residualIncmeOfficeHelper.WaitForWorkAround(4000);

           //Veify FND
           residualIncmeOfficeHelper.VerifyText("VerifyTextFND", "WorldPay");
           residualIncmeOfficeHelper.WaitForWorkAround(3000);

           //Set Filter 
           residualIncmeOfficeHelper.Select("SetFilterProcessor", "");
           residualIncmeOfficeHelper.WaitForWorkAround(4000);
           




           
        }
    }
}
