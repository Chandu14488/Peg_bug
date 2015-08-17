using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PegasusTests.PageHelper;
using PegasusTests.PageHelper.Comm;

namespace PegasusTests.Scripts.ClientsTests
{
    [TestClass]
    public class RelatedToMeetingPaginationFilter : DriverTestCase
    {
        [TestMethod]
        public void relatedToMeetingPaginationFilter()
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

            //Click on Clients in Topmenu
            clientBugsHelper.ClickElement("ClickOnActivityTab");

            //Click to open client info
            GetWebDriver().Navigate().GoToUrl("https://www.pegasus-test.com/selenium_corp/selenium_office/meetings/create");
            clientHelper.WaitForWorkAround(3000); 

            //Select Related To
            clientBugsHelper.Select("SelectRelatedTo", "20");


            //Click On Assigned To
         //   clientBugsHelper.ClickElement("ClickOnAssignedToMeeting");

            //Click ON Pagination
            clientBugsHelper.ClickOnPag();
            clientBugsHelper.WaitForWorkAround(3000);

        

/*

            //Clcik on Client You Want To Invite
            clientBugsHelper.ClickElement("ClickOnClientMeeting");



            //verify page text
            clientHelper.VerifyPageText("Meeting saved successfully.");  */

        }
    }
}
