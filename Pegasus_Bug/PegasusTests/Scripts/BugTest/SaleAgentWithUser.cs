using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PegasusTests.PageHelper;
using PegasusTests.PageHelper.Comm;

namespace PegasusTests.Scripts.ClientsTests
{
    [TestClass]
    public class SaleAgentWithUser : DriverTestCase
    {
        [TestMethod]
        public void saleAgentWithUser()
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
            var saleAgentHelper = new SaleAgentHelper(GetWebDriver());

            //Variable random
            var name = "TESTCLIENT" + GetRandomNumber();


            //Login with valid username and password
            Login(username[0], password[0]);
            Console.WriteLine("Logged in as: " + username[0] + " / " + password[0]);

            //Verify Page title
            VerifyTitle("Dashboard");
            Console.WriteLine("Redirected at Dashboard screen.");

            //Click on Agent in Topmenu
            saleAgentHelper.ClickElement("ClickAgentTab");


//################################# CREATE A agent   #############################################

            //Click on Click On Partner Agent
            saleAgentHelper.redirectToPage();

            //Click On Click On Create SaleBtn
            saleAgentHelper.ClickElement("ClickOnaCreateSaleBtn");

            //Select Salutation
            saleAgentHelper.Select("SelectSalutation", "Mr");

            //Enter FirstNAME
            saleAgentHelper.TypeText("FirstNAME", "Test Sale gent");

            //Enter LastName
            saleAgentHelper.TypeText("LastName", "Tester");

            //Enter Date Of Birth
            saleAgentHelper.TypeText("BirthDay", "1991-03-02");


            //############### CONTACT INFORMATION ###################################

            //Enter eAddressType
            saleAgentHelper.Select("eAddressType", "E-Mail");

            //Enter eAddressLebel
            saleAgentHelper.Select("eAddressLebel", "Work");

            //Enter eAddressType
            var Email = "Sale" + RandomNumber(1,999) + "@yopmail.com";
            saleAgentHelper.TypeText("eAddress", Email);

            //################## PHONE ###########################

            //Enter SelectPhoneType
            saleAgentHelper.Select("SelectPhoneType", "Work");

            //Enter PhoneNumber
            saleAgentHelper.TypeText("PhoneNumber", "1214122121");

            //##################### ADDRESS TYPE

            //Enter Address Type    
            saleAgentHelper.Select("AddressType", "Office");

            //Enter AddressLine1
            saleAgentHelper.TypeText("AddressLine1", "FC 89");

            //Enter City
            saleAgentHelper.TypeText("City", "Test City");

            //Enter PhoneNumber
            saleAgentHelper.TypeText("PostalCode", "60601");


            //########################## DEPARTMENT ROLE   ###############################

            //Click On Department 
            saleAgentHelper.ClickElement("ClickOnDeppartmentTeam");

            //Select Department
            saleAgentHelper.Select("SelectDepartment", "78");

            //Select Select Role
            saleAgentHelper.Select("SelectRole", "76");

            //Select Primary  Team
            saleAgentHelper.Select("PrimaryTeam", "40");


            //################### CREATE USER ACCOUNT

            //Click On Checkbox
            saleAgentHelper.ClickElement("ClickONcheckBox");

            //Enter UserName
            saleAgentHelper.TypeText("UserName", name);

            //Click On Avatar
            saleAgentHelper.ClickElement("ClickOnSAvatarBtn");


//##############    click on Save Contact 

            //CLICK DoNotSolicit
            saleAgentHelper.ClickElement("SaveAGENTbtn");

            //Click on Move over
            saleAgentHelper.ClickElement("MoveHover");

            //Redirect To Admin
            GetWebDriver().Navigate().GoToUrl("https://www.pegasus-test.com/selenium_corp/selenium_office/admin");
            saleAgentHelper.WaitForWorkAround(3000);

            //Click on Office
            saleAgentHelper.ClickElement("ClickOnOffice");

            //Redirect To User
            GetWebDriver().Navigate().GoToUrl("https://www.pegasus-test.com/selenium_corp/selenium_office/users");
            saleAgentHelper.WaitForWorkAround(2000);

            //Enter Email 
            saleAgentHelper.Select("SelectStatus1", "");
            saleAgentHelper.WaitForWorkAround(3000);
            saleAgentHelper.TypeText("EnterEmail", Email);
            saleAgentHelper.WaitForWorkAround(4000);
            saleAgentHelper.VerifyPageText(Email);
            saleAgentHelper.WaitForWorkAround(2000);
        }
    }
}
