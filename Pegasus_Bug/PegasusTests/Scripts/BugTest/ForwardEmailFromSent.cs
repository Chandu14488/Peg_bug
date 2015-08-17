using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PegasusTests.PageHelper;
using PegasusTests.PageHelper.Comm;

namespace PegasusTests.Scripts.ClientsTests
{
    [TestClass]
    public class ForwardEmailFromSent : DriverTestCase
    {
        [TestMethod]
        public void forwardEmailFromSent()
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
      //      clientBugsHelper.ClickElement("ClickOnActivityTab");

            //Redirect to URL
            GetWebDriver().Navigate().GoToUrl("https://www.pegasus-test.com/selenium_corp/selenium_office/mails/compose");


            //Enter To Filed
            clientBugsHelper.TypeText("EnterToFiled", "Test@yopmail.com");

            //Enter CC
            clientBugsHelper.TypeText("EnterCCMuliple", "Test@yopmail.com,123@yopmail.com,mytest@yopmail.com");

            //Enter Subject 
            clientBugsHelper.TypeText("EmailName", "This is Subject");

            //Click send Button
            clientBugsHelper.ClickElement("ClickSendBtn");
            clientBugsHelper.WaitForWorkAround(3000);


            //Verify Email sent successfully
            clientBugsHelper.VerifyPageText("E-Mail Sent Successfully.");
            clientBugsHelper.WaitForWorkAround(3000);


            //Click On Activity Tab\
            //      clientBugsHelper.ClickElement("ClickOnActivityTab");  

            //Redirect 
            GetWebDriver().Navigate().GoToUrl("https://www.pegasus-test.com/selenium_corp/selenium_office/mails");
            clientBugsHelper.WaitForWorkAround(3000);

            //Click On Sent To Forward
            clientBugsHelper.ClickElement("ClickOnSentToForward");
            clientBugsHelper.WaitForWorkAround(3000);

            //Click on Email To Forward
            clientBugsHelper.ClickElement("ClickOnEmailToFORAWRD");
            clientBugsHelper.WaitForWorkAround(3000);

            //Click on Forwar
            clientBugsHelper.ClickElement("ClickOnForward");
            clientBugsHelper.WaitForElementPresent("EnterToEmailRI",30);

            //Enter Email To Search 
            clientBugsHelper.TypeText("EnterToEmailRI", "Test@yopmail.com");

            //Enter SubjectRI
      //      clientBugsHelper.TypeText("EnterSubjectRI", "This is Subject");

            //Click on Send Button
            clientBugsHelper.ClickElement("ClickSendBtn");
            clientBugsHelper.WaitForWorkAround(3000);
            clientBugsHelper.VerifyPageText("E-Mail Sent Successfully.");
            clientBugsHelper.WaitForWorkAround(2000);


        }
    }
}
