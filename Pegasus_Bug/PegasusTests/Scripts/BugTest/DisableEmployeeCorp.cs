using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PegasusTests.PageHelper;
using PegasusTests.PageHelper.Comm;

namespace PegasusTests.Scripts.Corp
{
    [TestClass]
    public class DisableEmployeeCorp : DriverTestCase
    {
        [TestMethod]
        public void disableEmployeeCorp()
        {
          

            var oXMLData = new XMLParse();
            oXMLData.LoadXML("../../Config/ApplicationSettings.xml");


            //Initializing the objects
            var loginHelper = new LoginHelper(GetWebDriver());
            var clientHelper = new ClientsHelper(GetWebDriver());
            var createEmployeeCorp = new CreateEmployeeCorp(GetWebDriver());

            //Variable random

            var username = "TESTUSER" + RandomNumber(1, 99);
            var email = "Test" + RandomNumber(1, 99) + "@gmail.com";

            //Login with valid username and password
            createEmployeeCorp.TypeText("EnterUsername", "selcorp");

            //Login with valid username and password
            createEmployeeCorp.TypeText("EnterPassword", "seWelcome2");

            //Login Button
            createEmployeeCorp.ClickElement("ClickOnLoginButtojn");

            //Verify Page title
            VerifyTitle("Dashboard");
            Console.WriteLine("Redirected at Dashboard screen.");

            //Click on Agent in Topmenu
            createEmployeeCorp.ClickElement("ClickOnEmployeesTab");


//################################# CREATE A agent   #############################################


            //Click on Create button
            createEmployeeCorp.ClickElement("ClickOnCreate");

            //Enter Name
            createEmployeeCorp.TypeText("UserName", username);

            //Enter PrimaryEmail
            createEmployeeCorp.TypeText("PrimaryEmail", email);


            //Enter Salutation
            createEmployeeCorp.Select("Salutation", "Mr");


            //Enter OfficeCode
            createEmployeeCorp.TypeText("FirstName", "Test Name");


            //Enter SysPrinNumber
            createEmployeeCorp.TypeText("LastName", "Test LastName");

//##############  Avatars

            //  Click CorporateAdmin
            createEmployeeCorp.ClickElement("CorporateAdmin");

//############   PHONE
            //Select Phone Country
            createEmployeeCorp.Select("SelectCountry", "1");

            //Enter PhoneNumber
            createEmployeeCorp.TypeText("PhoneNumber", "9898398438");

//#############  E-Mails And Internet

            //Enter eAddress
            createEmployeeCorp.TypeText("eAddress", email);

//#############   ADDRESS

            //Enter AddressLine1
            createEmployeeCorp.TypeText("AddressLine1", "F-TEST");

            //Select Country
            createEmployeeCorp.Select("Country", "Canada");
            createEmployeeCorp.WaitForWorkAround(4000);

            //Enter VenderName
            createEmployeeCorp.Select("State", "AB");

            //CliCK On Save button
            createEmployeeCorp.ClickElement("ClickOnSaveBtn");

//#################      EDIT PROFILE 


            //Search Employee
            createEmployeeCorp.TypeText("searchemployee", email);

            //Click on Edit
            createEmployeeCorp.ClickElement("ClickOnEdit");



           
        }
    }
}
