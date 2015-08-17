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
    public class SentEmailVerifyResidualIncomeReports : DriverTestCase
    {
        [TestMethod]
        public void sentEmailVerifyResidualIncomeReports()
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
            var  email = "Testing" + RandomNumber(1,999) + "@yopmail.com";
            var  subject = "This is Testing Subject" + RandomNumber(1,999);

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

            //Select Status
           clientBugsHelper.Select("SelectStatusRIReport", "Published");
           clientBugsHelper.WaitForWorkAround(3000);
            
            //Click on View Report 
           clientBugsHelper.ClickElement("ViewReports");
           clientBugsHelper.WaitForWorkAround(4000);

            //Verify Text Selenium Corp Residual Reports
           clientBugsHelper.VerifyPageText("Selenium Corp Residual Reports");
           

           //Click On Email Icon
           clientBugsHelper.ClickElement("ClickOnEmailIcon");

            //Enter To Email 
           clientBugsHelper.TypeText("EnterToEmailRI", email);

            //Enter Subject 
           clientBugsHelper.TypeText("EnterSubjectAttRI", subject);

            //Click on Send button
           clientBugsHelper.ClickElement("EmailSendButtonRI");
           clientBugsHelper.WaitForWorkAround(4000);


           //Verify Report Mail is Sent Successfully.
           clientBugsHelper.VerifyPageText("Report Mail is Sent Successfully.");


            //Click On Activity Tab
           clientBugsHelper.ClickElement("ClickOnActivityTab");

            //Redirect To Page
           GetWebDriver().Navigate().GoToUrl("https://www.pegasus-test.com/selenium_corp/selenium_office/mails/sent");
           clientBugsHelper.WaitForWorkAround(4000);

            //Enter To Search RI
           clientBugsHelper.TypeText("EnterToSearchRI",email);

            //Enter Subject
           clientBugsHelper.TypeText("EnterSubjectRI", subject);
           clientBugsHelper.WaitForWorkAround(4000);

            //Click on Email
           clientBugsHelper.ClickElement("ClickPDF");
           clientBugsHelper.WaitForWorkAround(3000);
           clientBugsHelper.VerifyPageText(email);
           clientBugsHelper.VerifyPageText(subject);
           clientBugsHelper.WaitForWorkAround(3000);

        }
    }
}
