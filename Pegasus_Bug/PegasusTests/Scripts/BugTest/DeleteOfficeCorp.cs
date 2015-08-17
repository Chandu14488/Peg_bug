using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PegasusTests.PageHelper;
using PegasusTests.PageHelper.Comm;

namespace PegasusTests.Scripts.Corp
{
    [TestClass]
    public class DeleteOfficeCorp : DriverTestCase
    {
        [TestMethod]
        public void deleteOfficeCorp()
        {

            string[] username = null;
            string[] password = null;

            
            var oXMLData = new XMLParse();
            oXMLData.LoadXML("../../Config/ApplicationSettings.xml");

            username = oXMLData.getData("settings/Credentials", "username2");
            password = oXMLData.getData("settings/Credentials", "password2");

            // Initializing the objects
            var loginHelper = new LoginHelper(GetWebDriver());
            var clientHelper = new ClientsHelper(GetWebDriver());
            var editOfficeHelper = new EditOfficeHelper(GetWebDriver());

            //Variable random

          //  var usernae = "TESTUSER" + GetRandomNumber();
            var name = "Test" + RandomNumber(1, 99);

            //Login with valid username and password
            Login(username[0], password[0]);
            Console.WriteLine("Logged in as: " + username[0] + " / " + password[0]);

            //Verify Page title
            VerifyTitle("Dashboard");
            Console.WriteLine("Redirected at Dashboard screen.");

            //Verify Page title
            VerifyTitle("Dashboard");
            Console.WriteLine("Redirected at Dashboard screen.");

            //Craete Office
            GetWebDriver().Navigate().GoToUrl("https://www.pegasus-test.com/selcorp/offices/create");
            editOfficeHelper.WaitForElementPresent("Name",30);



            //Enter Name
            editOfficeHelper.TypeText("Name", "DELETE OFFICE");
            editOfficeHelper.WaitForElementPresent("AddressType", 30);


          
   //##########################  ADDRESS   
          
            //Enter Address
            editOfficeHelper.Select("AddressType", "Office");

            //Enter AddressLine1
            editOfficeHelper.TypeText("AddressLine1", "FC-89");


            //Enter CITY
            editOfficeHelper.TypeText("CITY", "test");

            //Select Country
            editOfficeHelper.Select("SelectCountry", "Canada");
            editOfficeHelper.WaitForWorkAround(5000);

            // Select State
            editOfficeHelper.Select("SelectState", "BC");


            //Do Not Create Primary User
            editOfficeHelper.ClickElement("DoNotCreatePrimaryUser");

           //#SAVE   
            editOfficeHelper.ClickElement("ClickOnSaveBtnNS");
            editOfficeHelper.WaitForWorkAround(5000);

            //Verify text on the page
            editOfficeHelper.VerifyPageText("Office created successfully.");
            editOfficeHelper.WaitForWorkAround(3000);

//##################### 

            //Enter Name To Search Office
            editOfficeHelper.TypeText("EnterNameToSrch", "DELETE OFFICE");
            editOfficeHelper.WaitForWorkAround(6000);

            //Click on Delete
            editOfficeHelper.ClickElement("DeleteOfficeBtn");

            //Click Delete to confirm
            editOfficeHelper.ClickElement("ConfrmDelbtn");
            editOfficeHelper.WaitForWorkAround(3000);
            editOfficeHelper.VerifyPageText("Office deleted successfully");
        }

    }
}
