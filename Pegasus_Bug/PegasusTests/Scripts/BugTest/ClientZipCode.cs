using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PegasusTests.PageHelper;
using PegasusTests.PageHelper.Comm;

namespace PegasusTests.Scripts.ClientsTests
{
    [TestClass]
    public class ClientZipCode : DriverTestCase
    {
        [TestMethod]
        public void clientZipCode()
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

            //Redirect
            GetWebDriver().Navigate().GoToUrl("https://www.pegasus-test.com/selcorp/seloffice/clients/create");

            //ClickOnClientContactTab
            clientBugsHelper.ClickElement("ClickOnClientContactTab");


            clientBugsHelper.TypeText("AddressLine1NW", "F/C=89");

            //EnterZipCodeClnt
            clientBugsHelper.TypeText("EnterZipCodeClnt", "60601");
            clientBugsHelper.WaitForWorkAround(4000);


            //MailClintAddNS
            clientBugsHelper.TypeText("MailClintAddNS", "Test");

            //MailingZipCode
            clientBugsHelper.TypeText("MailingZipCodeNS", "60601");
            clientBugsHelper.WaitForWorkAround(4000);

            //Enetr Client First Name
            clientBugsHelper.TypeText("FirstNameContactClintNS", "My Client");

            //EnterZipCodeClintNWcNT
            clientBugsHelper.TypeText("EnterZipCodeClintNWcNT", "60601");
            clientBugsHelper.WaitForWorkAround(6000);


           
        }
    }
}
