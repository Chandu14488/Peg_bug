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
    public class FilterForAgent : DriverTestCase
    {
        [TestMethod]
        public void filterForAgent()
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

        

            //Login with valid username and password
            Login(username[0], password[0]);
            Console.WriteLine("Logged in as: " + username[0] + " / " + password[0]);

            //Verify Page title
            VerifyTitle("Dashboard");
            Console.WriteLine("Redirected at Dashboard screen.");
            clientBugsHelper.WaitForWorkAround(4000);

        
            //Click On Agent Tab
          //  clientBugsHelper.ClickElement("ClickOnAgentTab");
            GetWebDriver().Navigate().GoToUrl("https://www.pegasus-test.com/selenium_corp/selenium_office/agents");
            clientBugsHelper.WaitForWorkAround(4000);

            //Select Agent Type
            clientBugsHelper.Select("SelectAgentType", "");
            clientBugsHelper.WaitForWorkAround(3000);

            //Select Agent Type
            clientBugsHelper.Select("SelectStatus", "Active");
            clientBugsHelper.WaitForWorkAround(3000);

            //Select Agent Type
            clientBugsHelper.Select("SelectRole", "");
            clientBugsHelper.WaitForWorkAround(3000);

            //Select Agent Type
            clientBugsHelper.Select("SelectDepartment", "");
            clientBugsHelper.WaitForWorkAround(3000);

            //Select Agent Type
            clientBugsHelper.Select("SelectTeam", "");
            clientBugsHelper.WaitForWorkAround(3000);

        
        }
    }
}
 