using Microsoft.VisualStudio.TestTools.UnitTesting;
using PegasusTests.PageHelper;
using PegasusTests.PageHelper.Comm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PegasusTests.Scripts.ClientsTests
{
    [TestClass]
    public class TicketSettingAdmin : DriverTestCase
    {
        [TestMethod]
        public void ticketSettingAdmin()
        {
            string[] username = null;
            string[] password = null;

            XMLParse oXMLData = new XMLParse();
            oXMLData.LoadXML("../../Config/ApplicationSettings.xml");

            username = oXMLData.getData("settings/Credentials", "username");
            password = oXMLData.getData("settings/Credentials", "password");

            //Initializing the objects
            LoginHelper loginHelper = new LoginHelper(GetWebDriver());
            ClientsHelper clientHelper = new ClientsHelper(GetWebDriver());
            var clientBugsHelper = new ClientBugsHelper(GetWebDriver());

            //Variable
            var TicketName = "Test" + RandomNumber(9, 999);
            var NewName = "TestNew Ticket" + RandomNumber(1,99);
        

            //Login with valid username and password
            Login(username[0], password[0]);
            Console.WriteLine("Logged in as: " + username[0] + " / " + password[0]);

            //Verify Page title
            VerifyTitle("Dashboard");
            Console.WriteLine("Redirected at Dashboard screen.");
            clientBugsHelper.WaitForWorkAround(4000);

            //Redirect To Admin
            GetWebDriver().Navigate().GoToUrl("https://www.pegasus-test.com/selenium_corp/selenium_office/admin");
            clientBugsHelper.WaitForWorkAround(4000);

            //Ticket Tab
            clientBugsHelper.ClickElement("TicketTab1");
            GetWebDriver().Navigate().GoToUrl("https://www.pegasus-test.com/selenium_corp/selenium_office/tickets/settings");

            //Select Ticket Created Status
            clientBugsHelper.Select("SelectTicketCreatedStatus","New");

            //Select Ticket Created Status
            clientBugsHelper.Select("ResolvedTicketStatus", "Resolved Status");

            //Select Ticket Created Status
            clientBugsHelper.Select("ClosedTicketStatus", "Closed");

            //Click Save
            clientBugsHelper.ClickElement("ClickOnAddBtn");
            clientBugsHelper.WaitForWorkAround(3000);

   
        }
    }
}
 