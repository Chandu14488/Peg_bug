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
    public class CreateTicketAndDeleteTicketFromAgnet : DriverTestCase
    {
        [TestMethod]
        public void createTicketAndDeleteTicketFromAgnet()
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
            var TicketName = "Test" + RandomNumber(1, 99);

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

            //Click on Select
            clientBugsHelper.Select("SelectStatustICKET", "Open");

            //Click on Select
            clientBugsHelper.SelectDropDownByText("//*[@id='TicketAssignedUserId']", "Aslam Khan");

            //Click on Select
            clientBugsHelper.Select("//*[@id='TicketAssignedManagerId']", "Aslam Khan");

            //Clcik Save ticket button
            clientBugsHelper.ClickDisplayed("//input[@value='Save']");
            clientBugsHelper.WaitForWorkAround(2000);

            //Click on Loc 
            clientBugsHelper.VerifyPageText("1 Ticket(s) created");

            clientBugsHelper.VerifyPageText(TicketName);
            clientBugsHelper.WaitForWorkAround(2000);

            //Redirect To Logout Page
            GetWebDriver().Navigate().GoToUrl("https://www.pegasus-test.com/selenium_corp/selenium_office/logout");

//###############   LOGIN AS MY EMPLOYEE AGENT

            //Enter User name
            clientBugsHelper.TypeText("EnterUsername", "MyEmpAgent");

            //Enter Password
            clientBugsHelper.TypeText("EnterPassword", "1qaz!QAZ");

            //Click login button
            clientBugsHelper.ClickElement("LoginBtn");

            //Click on Ticket tab
            clientBugsHelper.ClickElement("TicketTab");
            GetWebDriver().Navigate().GoToUrl("https://www.pegasus-test.com/selenium_corp/selenium_office/tickets");
            clientBugsHelper.WaitForWorkAround(3000);


            //Enter Ticket Subject
            clientBugsHelper.TypeText("TaskSearch", TicketName);
            clientBugsHelper.WaitForWorkAround(3000);

            //Click On Check box
            clientBugsHelper.ClickElement("ClickOnOppChjkBox");

            //Click on Delete 
            clientBugsHelper.ClickElement("ClickDeleteIcon");
            clientBugsHelper.AcceptAlert();
            clientBugsHelper.WaitForWorkAround(3000);
            clientBugsHelper.VerifyPageText("Records deleted successfully");
            clientBugsHelper.WaitForWorkAround(2000);


        }
    }
}
 