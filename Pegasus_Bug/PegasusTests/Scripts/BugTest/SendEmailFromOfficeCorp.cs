using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PegasusTests.PageHelper;
using PegasusTests.PageHelper.Comm;

namespace PegasusTests.Scripts.Corp
{
    [TestClass]
    public class SendEmailFromOfficeCorp : DriverTestCase
    {
        [TestMethod]
        public void sendEmailFromOfficeCorp()
        {
            var oXMLData = new XMLParse();
            oXMLData.LoadXML("../../Config/ApplicationSettings.xml");

            // Initializing the objects
            var loginHelper = new LoginHelper(GetWebDriver());
            var clientHelper = new ClientsHelper(GetWebDriver());
            var editOfficeHelper = new EditOfficeHelper(GetWebDriver());

            //Variable random

            var username = "TESTUSER" + GetRandomNumber();
            var name = "Test" + RandomNumber(1, 99);

            //Login with valid username and password
            editOfficeHelper.TypeText("EnterUsername", "selcorp");

            //Login with valid username and password
            editOfficeHelper.TypeText("EnterPassword", "seWelcome2");

            //Login Button
            editOfficeHelper.ClickElement("ClickOnLoginButtojn");

            //Verify Page title
            VerifyTitle("Dashboard");
            Console.WriteLine("Redirected at Dashboard screen.");

            //Click on Agent in Topmenu
            editOfficeHelper.ClickElement("ClickOnOfficeTab");


//################################# CREATE A agent   #############################################

            //Redirect to Office
            editOfficeHelper.redirectToPage(); 

            //Enter Name To Search Office
            editOfficeHelper.TypeText("EnterNameToSrch", "Selenium Office");
            editOfficeHelper.WaitForWorkAround(3000);

            //Click on Delete
            editOfficeHelper.ClickElement("ClickOnOffice");

            //Click Delete to confirm
            editOfficeHelper.ClickElement("ClickOfficeEmail");

            //Enter Subject
            editOfficeHelper.TypeText("EnterSubject", "Testing Email");

            //Enter Message
            editOfficeHelper.TypeText("Message", "This is testing message");

            //Click Send Button
            editOfficeHelper.ClickElement("SendEmailBtn");
            editOfficeHelper.WaitForWorkAround(2000);
            editOfficeHelper.VerifyPageText("Email Sent Successfully.");

            
        }

    }
}
