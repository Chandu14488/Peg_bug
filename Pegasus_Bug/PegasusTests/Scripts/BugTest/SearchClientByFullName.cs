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
    public class SearchClientByFullName : DriverTestCase
    {
        [TestMethod]
        public void searchClientByFullName()
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

            //Create ClientBtn
            clientBugsHelper.ClickElement("CreateClientBtn");

            //Enter client DBA Name
            clientBugsHelper.TypeText("ClientDBAName", "ADDRESS TEST");

            //Enter Clinet First Name
            clientBugsHelper.TypeText("ClientFirstName", "Client");

            //Enter Client Last Name
            clientBugsHelper.TypeText("ClientLastName", "Name");

            //Click on Save
            clientBugsHelper.ClickOnDublicate();
            clientBugsHelper.WaitForWorkAround(4000);

            //Verify Text
            clientBugsHelper.VerifyPageText("Client saved successfully");

            //Click On Client Tab
            clientBugsHelper.ClickElement("ClientTab");
            clientBugsHelper.WaitForWorkAround(4000);

            //Search By Full Name
            clientBugsHelper.TypeText("SearchByFullName", "Client Name");
            clientBugsHelper.WaitForWorkAround(4000);

            //Verify Page Text
            clientBugsHelper.VerifyPageText("ADDRESS TEST");

        

        }
    }
}
 