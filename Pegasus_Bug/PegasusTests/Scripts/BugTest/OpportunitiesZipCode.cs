using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PegasusTests.PageHelper;
using PegasusTests.PageHelper.Comm;

namespace PegasusTests.Scripts.ClientsTests
{
    [TestClass]
    public class OpportunitiesZipCode : DriverTestCase
    {
        [TestMethod]
        public void opportunitiesZipCode()
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

            //Redirect To URL
            GetWebDriver().Navigate().GoToUrl("https://www.pegasus-test.com/selcorp/seloffice/opportunities/create");
            clientBugsHelper.WaitForElementPresent("AddressLine1Opp",20);
 


            //Enter Address Line1
            clientBugsHelper.TypeText("AddressLine1Opp", "TEST ADDRESS LINE 1");

            //Enter City
            clientBugsHelper.TypeText("ZipCodeOpp", "60601");
            clientBugsHelper.WaitForWorkAround(5000);

            //Verify text
          //  clientBugsHelper.VerifyText("AddressCountryDdwn", "United States");

            //Verify 
        //    clientBugsHelper.VerifyText("StateOpp", "IL");
            clientBugsHelper.WaitForWorkAround(2000);


//############################# MAILING  ADDRESS   ##################################3

          //Select MailingAddressLine1
            clientBugsHelper.TypeText("MailingAddLine1opp", "test");

            //Enter Mailing Zip Code
            clientBugsHelper.TypeText("MailingZipCodeOpp", "30033");
            clientBugsHelper.WaitForWorkAround(3000);

            //Select County
    //        clientBugsHelper.VerifyText("CountryDrpDwnMailing", "United States");
            clientBugsHelper.WaitForWorkAround(3000);

            //Select Mailing State
      //      clientBugsHelper.VerifyText("StateMailing", "GA");   

           
        }
    }
}
