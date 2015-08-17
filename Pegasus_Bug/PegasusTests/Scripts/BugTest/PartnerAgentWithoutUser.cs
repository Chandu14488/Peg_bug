using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PegasusTests.PageHelper;
using PegasusTests.PageHelper.Comm;

namespace PegasusTests.Scripts.ClientsTests
{
    [TestClass]
    public class PartnerAgentWithoutUser : DriverTestCase
    {
        [TestMethod]
        public void partnerAgentWithoutUser()
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
            var createAgentHelper = new CreateAgentHelper(GetWebDriver());

            //Variable
            var name = "TestAgent" + GetRandomNumber();


            //Login with valid username and password
            Login(username[0], password[0]);
            Console.WriteLine("Logged in as: " + username[0] + " / " + password[0]);

            //Verify Page title
            VerifyTitle("Dashboard");
            Console.WriteLine("Redirected at Dashboard screen.");

            //Click on Agent in Topmenu
            createAgentHelper.MouseHover("ClickAgentTab");


//################################# CREATE A agent   #############################################

            //Click on Click On Partner Agent
            createAgentHelper.redirectToPage();

            //Click On Create
            createAgentHelper.ClickElement("ClickOnaAgentCreate");

            //Select Salutation
            createAgentHelper.Select("SelectSalutation", "Mr");

            //Enter FirstNAME
            createAgentHelper.TypeText("FirstNAME", "Test Agent");

            //Enter LastName
            createAgentHelper.TypeText("LastName", "Tester");

            //Enter Date Of Birth
            createAgentHelper.TypeText("BirthDay", "1991-03-02");

            //Click on Middle name
            createAgentHelper.ClickElement("ClickMiddleName");

            //Enter DBAName
            createAgentHelper.TypeText("DBAName", "Test DBA");

            //Enter LinkedInUrl
            createAgentHelper.TypeText("LinkedInUrl", "LinkedIn.con");


            //Enter FaceBook Url
            createAgentHelper.TypeText("FaceBookUrl", "Facebook.com");


            //Enter TwitterURL
            createAgentHelper.TypeText("TwitterURL", "Twitter.com");

            //Enter DBAName
            createAgentHelper.Select("SelectLanguage", "English");

//############### CONTACT INFORMATION ###################################

            //Enter eAddressType
            createAgentHelper.Select("eAddressType", "E-Mail");

            //Enter eAddressLebel
            createAgentHelper.Select("eAddressLebel", "Work");

            //Enter eAddressType
            createAgentHelper.TypeText("eAddress", "Test@gmail.com");

//################## PHONE ###########################

            //Enter SelectPhoneType
            createAgentHelper.Select("SelectPhoneType", "Work");

            //Enter PhoneNumber
            createAgentHelper.TypeText("PhoneNumber", "1212121212");

//##################### ADDRESS TYPE

            //Enter Address Type    
            createAgentHelper.Select("AddressType", "Office");

            //Enter AddressLine1
            createAgentHelper.TypeText("AddressLine1", "FC 89");


            //Enter PhoneNumber
            createAgentHelper.TypeText("PostalCode", "60601");
            createAgentHelper.WaitForWorkAround(3000);

            //CLICK Save AGENT btn
            createAgentHelper.ClickElement("SaveAGENTbtn");
            createAgentHelper.WaitForWorkAround(3000);

            //Verify Text
            createAgentHelper.VerifyPageText("Partner Agents");
            createAgentHelper.WaitForWorkAround(3000);
        }
    }
}
