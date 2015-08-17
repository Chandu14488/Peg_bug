using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PegasusTests.PageHelper;
using PegasusTests.PageHelper.Comm;

namespace PegasusTests.Scripts.ClientsTests
{
    [TestClass]
    public class EmployeeAgentWithoutUser : DriverTestCase
    {
        [TestMethod]
        public void employeeAgentWithoutUser()
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
            var employeeAgentHelper = new EmployeeAgentHelper(GetWebDriver());

            //VARIABLE
            var name = "TestEmployee" + GetRandomNumber();


            //Login with valid username and password
            Login(username[0], password[0]);
            Console.WriteLine("Logged in as: " + username[0] + " / " + password[0]);

            //Verify Page title
            VerifyTitle("Dashboard");
            Console.WriteLine("Redirected at Dashboard screen.");

            //Redirect To
            GetWebDriver().Navigate().GoToUrl("https://www.pegasus-test.com/selcorp/seloffice/employees/create");
            employeeAgentHelper.WaitForWorkAround(4000);


            //Select Salutation
            employeeAgentHelper.Select("SelectSalutation", "Mr");

            //Enter FirstNAME
            employeeAgentHelper.TypeText("FirstNAME", "Test Agent");

            //Enter LastName
            employeeAgentHelper.TypeText("LastName", "Tester");

            //Enter Date Of Birth
            employeeAgentHelper.TypeText("BirthDay", "1991-03-02");


//############### CONTACT INFORMATION ###################################

            //Enter eAddressType
            employeeAgentHelper.Select("eAddressType", "E-Mail");

            //Enter eAddressLebel
            employeeAgentHelper.Select("eAddressLebel", "Work");

            //Enter eAddressType
            employeeAgentHelper.TypeText("eAddress", "Test@gmail.com");

//################## PHONE ###########################

            //Enter SelectPhoneType
            employeeAgentHelper.Select("SelectPhoneType", "Work");

            //Enter PhoneNumber
//            employeeAgentHelper.TypeText("PhoneNumber", "121212121");

//##################### ADDRESS TYPE

            //Enter Address Type    
            employeeAgentHelper.Select("AddressType", "Office");

            //Enter AddressLine1
            employeeAgentHelper.TypeText("AddressLine1", "FC 89");

            //Enter PhoneNumber
            employeeAgentHelper.TypeText("PostalCode", "60601");
            employeeAgentHelper.WaitForWorkAround(3000);

            //CLICK DoNotSolicit
            employeeAgentHelper.ClickElement("SaveAGENTbtn");
            employeeAgentHelper.VerifyPageText("The employee is successfully added");
        }
    }
}
