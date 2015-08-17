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
    public class EditTicketForClient : DriverTestCase
    {
        [TestMethod]
        public void editTicketForClient()
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

        
            //Click On Client Tab
            clientBugsHelper.ClickElement("ClientTab");
            clientBugsHelper.WaitForWorkAround(4000);

            //Clcik on Clinet
            clientBugsHelper.ClickElement("ClickOnClient");
            clientBugsHelper.WaitForElementPresent("CreateTicketBtn", 40); 

            //scroll to element
            clientBugsHelper.scrollToElement("CreateTicketBtn");
            //Create Ticket Btn
            clientBugsHelper.ClickElement("CreateTicketBtn");
            clientBugsHelper.WaitForElementPresent("EnterTicketName",40); 

            //Enter Ticket Name
            clientBugsHelper.TypeText("EnterTicketName", TicketName);

            //Enter Description
            clientBugsHelper.TypeText("TicketDescription","Testing Ticket Description");

            //Click on Select
            clientBugsHelper.Select("SelectStatustICKET", "Open");

            //Click on Select
            clientBugsHelper.SelectDropDownByText("//*[@id='TicketAssignedUserId']", "Aslam Khan");

            //Click on Select
            clientBugsHelper.SelectDropDownByText("//*[@id='TicketAssignedManagerId']", "Aslam Khan");

            //Clcik Save ticket button
            clientBugsHelper.ClickDisplayed("//input[@value='Save']");
            clientBugsHelper.WaitForWorkAround(2000);

            //Click on Loc 
            clientBugsHelper.VerifyPageText("1 Ticket(s) created");

            clientBugsHelper.VerifyPageText(TicketName);
            clientBugsHelper.WaitForWorkAround(2000);


            //Click on Ticket Tab
         //   clientBugsHelper.ClickElement("TicketTab");
            GetWebDriver().Navigate().GoToUrl("https://www.pegasus-test.com/selenium_corp/selenium_office/ticket-search/open");

            //Search Ticket
            clientBugsHelper.TypeText("TaskSearch", TicketName);
            clientBugsHelper.WaitForWorkAround(3000);

            //Click On Ticket
            clientBugsHelper.ClickElement("ClickOnEditTicket");
            clientBugsHelper.WaitForWorkAround(3000);

            //Enter Ticket Name
            clientBugsHelper.TypeText("EnterTicketName", TicketName);


            //Click on Save 
            clientBugsHelper.ClickElement("ClickOnSaveButn");
            clientBugsHelper.VerifyPageText("Ticket Edited Successfully");
            clientBugsHelper.WaitForWorkAround(3000);




        }
    }
}
 