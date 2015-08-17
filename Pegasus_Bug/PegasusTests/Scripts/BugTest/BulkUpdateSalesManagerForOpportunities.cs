using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PegasusTests.PageHelper;
using PegasusTests.PageHelper.Comm;

namespace PegasusTests.Scripts.ClientsTests
{
    [TestClass]
    public class BulkUpdateSalesManagerForOpportunities : DriverTestCase
    {
        [TestMethod]
        public void bulkUpdateSalesManagerForOpportunities()
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
            GetWebDriver().Navigate().GoToUrl("https://www.pegasus-test.com/selcorp/seloffice/opportunities");
            clientBugsHelper.WaitForElementVisible("ClickOnOppChjkBox",30);

            //Click On Opp Check Box
            clientBugsHelper.ClickElement("ClickOnOppChjkBox");

            //Click On Bulk Update
            clientBugsHelper.ClickElement("ClickOnBulkUpdate");

            //Change Sale Manager
            clientBugsHelper.ClickElement("ChangeSaleManager");

            //Select Sales MANAGER
            clientBugsHelper.SelectDropDownByText("//*[@id='OpportunitySalesManagerUpdateSalesManagerId']", "Aslam Khan");

            //Click on Update button
            clientBugsHelper.ClickDisplayed("//button[text()='Update']");
            clientBugsHelper.AcceptAlert();
            clientBugsHelper.WaitForWorkAround(2000);
            clientBugsHelper.VerifyPageText("records updated successfully");

           
        }
    }
}
