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
    public class VerifyCreateTicketInAllTickets : DriverTestCase
    {
        [TestMethod]
        public void verifyCreateTicketInAllTickets()
        {
            string[] username = null;
            string[] password = null;

            XMLParse oXMLData = new XMLParse();
            oXMLData.LoadXML("../../Config/ApplicationSettings.xml");

            username = oXMLData.getData("settings/Credentials", "username");
            password = oXMLData.getData("settings/Credentials", "password");

            //Initializing the objects
            var loginHelper = new LoginHelper(GetWebDriver());
            var clientHelper = new ClientsHelper(GetWebDriver());
            var clientBugsHelper = new ClientBugsHelper(GetWebDriver());

            //Variable
            var TicketName = "Test" + RandomNumber(1, 99);
            string Loc = "//a[text()="+"[']"+TicketName+"[']"+"]";
        

            //Login with valid username and password
            Login(username[0], password[0]);
            Console.WriteLine("Logged in as: " + username[0] + " / " + password[0]);

            //Verify Page title
            VerifyTitle("Dashboard");
            Console.WriteLine("Redirected at Dashboard screen.");
            clientBugsHelper.WaitForWorkAround(4000);

        
            //Click On Client Tab
            clientBugsHelper.ClickElement("ClientTab");
            clientBugsHelper.WaitForWorkAround(4000);

            //Clcik on Clinet
            clientBugsHelper.ClickElement("ClickOnClient");

            //Create Ticket Btn
            clientBugsHelper.ClickElement("CreateTicketBtn");

            //Enter Ticket Name
            clientBugsHelper.TypeText("EnterTicketName", TicketName);

            //Enter Description
            clientBugsHelper.TypeText("TicketDescription","Testing Ticket Description");

            //Clcik Save ticket button
            clientBugsHelper.ClickElement("SaveBtnTicket");
            clientBugsHelper.WaitForWorkAround(2000);

            //Click on Loc 
            clientBugsHelper.VerifyPageText("1 Ticket(s) created");

            clientBugsHelper.VerifyPageText(TicketName);
            clientBugsHelper.WaitForWorkAround(2000);

            //Click on Ticket Tab
            clientBugsHelper.ClickElement("TicketTab");
            clientBugsHelper.WaitForWorkAround(3000);

            //Search Created Ticket 
            clientBugsHelper.TypeText("TaskSearch", TicketName);
            clientBugsHelper.WaitForWorkAround(4000);
            clientBugsHelper.VerifyPageText(TicketName);
            clientBugsHelper.WaitForWorkAround(2000);




        }
    }
}
 