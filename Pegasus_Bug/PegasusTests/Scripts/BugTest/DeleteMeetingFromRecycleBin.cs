using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PegasusTests.PageHelper;
using PegasusTests.PageHelper.Comm;

namespace PegasusTests.Scripts.ClientsTests
{
    [TestClass]
    public class DeleteMeetingFromRecycleBin : DriverTestCase
    {
        [TestMethod]
        public void deleteMeetingFromRecycleBin()
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

            //Click on Clients in Topmenu
            clientBugsHelper.ClickElement("ClickOnActivityTab");

            //Click to open client info
            GetWebDriver().Navigate().GoToUrl("https://www.pegasus-test.com/selcorp/seloffice/meetings/create");
            clientHelper.WaitForWorkAround(3000);

            //Enter Subject for the task
            clientHelper.TypeText("MeetingSubject", "TESTING MEETING SUBJECT");

            //Enter Subject for the task
            clientHelper.TypeText("MeetingLocation", "TESTING MEETING LOCATION");

            //Enter date in the date field
            clientHelper.TypeText("StartDateMeting", "2015-03-25");

            //Enter Date in the End Date  field
            clientHelper.TypeText("EndMeetingDate", "2015-03-26");

            //Select Related To
            clientBugsHelper.Select("SelectRelatedTo", "20");
            clientBugsHelper.WaitForWorkAround(4000);

            //Click On Assigned To
            clientBugsHelper.ClickElement("ClickOnAssignedToMeeting");
            clientBugsHelper.WaitForWorkAround(4000);

            //Clcik on Client You Want To Invite
            clientBugsHelper.ClickElement("ClickOnClientMeeting");
            clientBugsHelper.WaitForWorkAround(4000);


            //Click On Save button
            clientBugsHelper.ClickElement("SaveActivity");
            clientBugsHelper.WaitForWorkAround(3000);

            //verify page text
            clientBugsHelper.VerifyPageText("Meeting saved successfully.");
            clientBugsHelper.WaitForWorkAround(3000);

            //Click on Clients in Topmenu
            clientBugsHelper.ClickElement("ClickOnActivityTab");

            //Redirect To
            GetWebDriver().Navigate().GoToUrl("https://www.pegasus-test.com/selenium_corp/selenium_office/meetings");
            clientBugsHelper.WaitForWorkAround(3000);

            //Search Meeting
            clientBugsHelper.TypeText("TaskSearch", "DELETE MEETING");

        }
    }
}
