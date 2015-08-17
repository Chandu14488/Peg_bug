using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PegasusTests.PageHelper;
using PegasusTests.PageHelper.Comm;

namespace PegasusTests.Scripts.ClientsTests
{
    [TestClass]
    public class MeetingForLead : DriverTestCase
    {
        [TestMethod]
        public void meetingForLead()
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

            //Click on Activity Tab
     //        clientBugsHelper.ClickElement("ClickOnActivityTab");

            //Redirect to Meeting
            GetWebDriver().Navigate().GoToUrl("https://www.pegasus-test.com/selenium_corp/selenium_office/meetings/create");


            //EnterMeetingName
            clientBugsHelper.TypeText("EnterMeetingName","Test Meeting");

            //MeetingStart
            clientBugsHelper.ClickElement("MeetingStart");
            clientBugsHelper.WaitForWorkAround(3000);

            //ClickDate18
            clientBugsHelper.ClickElement("ClickDate18");
            clientBugsHelper.WaitForWorkAround(3000);

            //EndDATE
            clientBugsHelper.ClickElement("EndDATE");
            clientBugsHelper.WaitForWorkAround(3000);


            //ClickDate28
            clientBugsHelper.ClickElement("ClickDate28");
            clientBugsHelper.WaitForWorkAround(3000);

            //ClickOnSaveButn
            clientBugsHelper.ClickElement("ClickOnSaveButn");
            clientBugsHelper.WaitForWorkAround(3000);


            //Select Related 
            clientBugsHelper.SelectDropDownByText("//*[@id='MeetingParentType']", "Lead");

            //ClickOnAssignedToMeeting
            clientBugsHelper.ClickElement("ClickOnAssignedToMeeting");

            //SelectLedForMeeting
            clientBugsHelper.ClickElement("SelectLedForMeeting");
            clientBugsHelper.WaitForWorkAround(3000);

            //ClickOnSaveButn
            clientBugsHelper.ClickElement("ClickOnSaveButn");
            clientBugsHelper.WaitForWorkAround(3000);


            //verify page text
            clientHelper.VerifyPageText("Meeting saved successfully.");
            clientBugsHelper.WaitForWorkAround(3000);



        }
    }
}
