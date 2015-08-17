using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PegasusTests.PageHelper;
using PegasusTests.PageHelper.Comm;

namespace PegasusTests.Scripts.ClientsTests
{
    [TestClass]
    public class LeadZipCode : DriverTestCase
    {
        [TestMethod]
        public void leadZipCode()
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
            var addLeadsHelper = new AddLeadsHelper(GetWebDriver());

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

             //Redirect To Lead
            GetWebDriver().Navigate().GoToUrl("https://www.pegasus-test.com/selcorp/seloffice/leads/create");
            addLeadsHelper.WaitForElementPresent("SelectSalutation",20);

            //Click on Comapy Detail
            addLeadsHelper.Click("//a[text()='Company Details']");
            addLeadsHelper.WaitForElementPresent("SelectSalutation", 20);


            //Select Salutation
            addLeadsHelper.Select("SelectSalutation", "Mr");

            //Enter First Name
            addLeadsHelper.TypeText("FirstNAME", FirstName);

            //Enter Last Name
            addLeadsHelper.TypeText("LastName", LastName);

            //Enter Company Name  
            addLeadsHelper.TypeText("CompanyName", "TEST COMPANY");



//############################# ADDRESS   ##################################3


            //Enter Address Line1
            addLeadsHelper.TypeText("AddressLine1", "TEST");

            //Enter City
            addLeadsHelper.TypeText("ZipCode", "60601");
            addLeadsHelper.WaitForWorkAround(5000);

            //Verify text
   //         addLeadsHelper.VerifyText("SelectCountry0", "United States");

            //Verify 
   //         addLeadsHelper.VerifyText("AddressState", "IL");
 //           addLeadsHelper.WaitForWorkAround(2000);

            //Verify 
         //   addLeadsHelper.VerifyPageText("Chicago");
         //   addLeadsHelper.WaitForWorkAround(2000);

            //Verify LeadCounty
//            addLeadsHelper.VerifyPageText("Cook");
         


//############################# MAILING  ADDRESS   ##################################3

          //Select MailingAddressLine1
            addLeadsHelper.TypeText("MailingAddressLine1", "test");

            //Enter MailingCity
    //        addLeadsHelper.TypeText("MailingCity", "TEST");

            //Enter Mailing Zip Code
            addLeadsHelper.TypeText("MailingZipCode", "30033");
            addLeadsHelper.WaitForWorkAround(3000);

            //Select County
  //          addLeadsHelper.VerifyText("SelectCountry", "United States");
            addLeadsHelper.WaitForWorkAround(3000);

            //Select Mailing State
     //       addLeadsHelper.VerifyText("MailingState", "GA");   

            //Mailing City
//            addLeadsHelper.VerifyText("MailingCity", "Decatur");

            //Mailing County
  //          addLeadsHelper.VerifyText("MailingConty", "Dekalb");

           



        }
    }
}
