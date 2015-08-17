using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PegasusTests.PageHelper;
using PegasusTests.PageHelper.Comm;

namespace PegasusTests.Scripts.ClientsTests
{
    [TestClass]
    public class EmailNoteForward : DriverTestCase
    {
        [TestMethod]
        public void emailNoteForward()
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
        //    clientBugsHelper.ClickElement("ClickOnActivityTab");

            //Redirect to URL
            GetWebDriver().Navigate().GoToUrl("https://www.pegasus-test.com/selenium_corp/selenium_office/notes/create");

            //Enter Subject 
            clientBugsHelper.TypeText("EnterSubNote", "Email This Note");

            //Click on Save
            clientBugsHelper.ClickElement("ClickSaveBtn");
            clientBugsHelper.WaitForWorkAround(3000);

            //Verify tEXT
            clientBugsHelper.VerifyPageText("Note saved successfully.");

            //Search Note
            clientBugsHelper.TypeText("TaskSearch", "Email This Note");
            clientBugsHelper.WaitForWorkAround(3000);

            //Click on Note
            clientBugsHelper.ClickElement("ClickOnNote");

            //Click On Email This NOte
            clientBugsHelper.ClickElement("ClickOnEmail");
            clientBugsHelper.WaitForWorkAround(3000);

            //Enter To Filed
            clientBugsHelper.TypeText("EnterToFiled", "Test@yopmail.com");

            //Click send Button
            clientBugsHelper.ClickElement("ClickSendBtn");
            clientBugsHelper.WaitForWorkAround(3000);

            //Verify Email sent successfully
            clientBugsHelper.VerifyPageText("E-Mail Sent Successfully.");
            clientBugsHelper.WaitForWorkAround(3000);

        }
    }
}
