using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PegasusTests.PageHelper;
using PegasusTests.PageHelper.Comm;

namespace PegasusTests.Scripts.ClientsTests
{
    [TestClass]
    public class SendEmailFromActivity : DriverTestCase
    {
        [TestMethod]
        public void sendEmailFromActivity()
        {
            string[] username = null;
            string[] password = null;

            var oXMLData = new XMLParse();
            oXMLData.LoadXML("../../Config/ApplicationSettings.xml");

            username = oXMLData.getData("settings/Credentials", "username");
            password = oXMLData.getData("settings/Credentials", "password");

            //Initializing the objects
            var loginHelper = new LoginHelper(GetWebDriver());
            var clientHelper = new ClientsHelper(GetWebDriver());
            var clientBugsHelper = new ClientBugsHelper(GetWebDriver());

            //Login with valid username and password
            Login(username[0], password[0]);
            Console.WriteLine("Logged in as: " + username[0] + " / " + password[0]);

            //Verify Page title
            VerifyTitle("Dashboard");
            Console.WriteLine("Redirected at Dashboard screen.");

            //Click On Activity Tab\
            clientBugsHelper.ClickElement("ClickOnActivityTab");

            //Redirect to URL
            GetWebDriver().Navigate().GoToUrl("https://www.pegasus-test.com/selenium_corp/selenium_office/mails/compose");


            //Enter To Filed
            clientBugsHelper.TypeText("EnterToFiled", "Test@yopmail.com");

            //Enter CC
            clientBugsHelper.TypeText("EnterCCMuliple", "Test@yopmail.com,123@yopmail.com,mytest@yopmail.com");

            //Enter Subject 
            clientBugsHelper.TypeText("EmailName","This is Subject");

            //Click send Button
            clientBugsHelper.ClickElement("ClickSendBtn");
            clientBugsHelper.WaitForWorkAround(3000);

            //Verify Email sent successfully
            clientBugsHelper.VerifyPageText("E-Mail Sent Successfully.");
            clientBugsHelper.WaitForWorkAround(3000);

        }
    }
};
