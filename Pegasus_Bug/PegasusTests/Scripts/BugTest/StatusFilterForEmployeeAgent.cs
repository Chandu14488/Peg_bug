using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PegasusTests.PageHelper;
using PegasusTests.PageHelper.Comm;

namespace PegasusTests.Scripts.ClientsTests
{
    [TestClass]
    public class StatusFilterForEmployeeAgent : DriverTestCase
    {
        [TestMethod]
        public void statusFilterForEmployeeAgent()
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

            //Variable

            var FirstName = "Test" + RandomNumber(1, 99);
            var LastName = "Tester" + RandomNumber(1, 99);
            var Number = "12345678" + RandomNumber(10, 99);

            //Login with valid username and password
            Login(username[0], password[0]);
            Console.WriteLine("Logged in as: " + username[0] + " / " + password[0]);

            //Verify Page title
            VerifyTitle("Dashboard");
            Console.WriteLine("Redirected at Dashboard screen.");

            //Click on Clients in Topmenu
//            clientBugsHelper.ClickElement("ClickOnAgentTab");

            //Redirect To URL
            GetWebDriver().Navigate().GoToUrl("https://www.pegasus-test.com/selenium_corp/selenium_office/employees");
      
            //Select Status
            clientBugsHelper.Select("SelectStatus", "Active");
            clientBugsHelper.WaitForElementPresent("VerifyStatus",20);

            //Verify page text
            clientBugsHelper.VerifyText("VerifyStatus", "Active");
            clientBugsHelper.WaitForWorkAround(3000);

            //Select Status
            clientBugsHelper.Select("SelectStatus", "Disabled");
       //     clientBugsHelper.WaitForElementPresent("VerifyStatus", 20);

            //Verify page text
        //    clientBugsHelper.VerifyText("VerifyStatus", "Inactive");


            //Select Status
            clientBugsHelper.Select("SelectStatus", "");
            clientBugsHelper.WaitForWorkAround(3000);

            //Verify page text
            clientBugsHelper.VerifyPageText("Active");
            clientBugsHelper.WaitForWorkAround(3000);

            //Verify Page Text
          //  clientBugsHelper.VerifyPageText("Inactive");
          //  clientBugsHelper.WaitForWorkAround(3000);


           
        }
    }
}
