﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PegasusTests.PageHelper;
using PegasusTests.PageHelper.Comm;

namespace PegasusTests.Scripts.ClientsTests
{
    [TestClass]
    public class PartnerAssociationWithoutUser : DriverTestCase
    {
        [TestMethod]
        public void partnerAssociationWithoutUser()
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
            var partnerAssociationHelper = new PartnerAssociationHelper(GetWebDriver());

            //Variable
            var name = "TestAgent" + GetRandomNumber();


            //Login with valid username and password
            Login(username[0], password[0]);
            Console.WriteLine("Logged in as: " + username[0] + " / " + password[0]);

            //Verify Page title
            VerifyTitle("Dashboard");
            Console.WriteLine("Redirected at Dashboard screen.");

            //Click on Agent in Topmenu
            partnerAssociationHelper.MouseHover("ClickAgentTab");


//################################# CREATE A agent   #############################################

            //Click on Click On Partner Agent
            partnerAssociationHelper.redirectToPage();

            //Click On Create
            partnerAssociationHelper.ClickElement("ClickOnaAgentCreate");

            //Enter Association name
            partnerAssociationHelper.TypeText("Name", "AssociationTester");

            //Enter DBAName
            partnerAssociationHelper.TypeText("DBAName", "Test DBA");

            //Select Salutation
            partnerAssociationHelper.Select("SelectSalutation", "Mr");

            //Enter FirstNAME
            partnerAssociationHelper.TypeText("FirstNAME", "Test Agent");

            //Enter LastName
            partnerAssociationHelper.TypeText("LastName", "Tester");


            //Enter LinkedInUrl
            partnerAssociationHelper.TypeText("LinkedInUrl", "LinkedIn.con");


            //Enter FaceBook Url
            partnerAssociationHelper.TypeText("FaceBookUrl", "Facebook.com");


            //Enter TwitterURL
            partnerAssociationHelper.TypeText("TwitterURL", "Twitter.com");


            //Enter Date Of Birth
            partnerAssociationHelper.TypeText("BirthDay", "1991-03-02");


            //Select Language
            partnerAssociationHelper.Select("SelectLanguage", "English");

//############### CONTACT INFORMATION ###################################

            //Enter eAddressType
            partnerAssociationHelper.Select("eAddressType", "E-Mail");

            //Enter eAddressLebel
            partnerAssociationHelper.Select("eAddressLebel", "Work");

            //Enter eAddressType
            partnerAssociationHelper.TypeText("eAddress", "Test@gmail.com");

//################## PHONE ###########################

            //Enter SelectPhoneType
            partnerAssociationHelper.Select("SelectPhoneType", "Work");

            //Enter PhoneNumber
            partnerAssociationHelper.TypeText("PhoneNumber", "1212121212");

//##################### ADDRESS TYPE

            //Enter Address Type    
            partnerAssociationHelper.Select("AddressType", "Office");

            //Enter AddressLine1
            partnerAssociationHelper.TypeText("AddressLine1", "FC 89");


            //Enter PhoneNumber
            partnerAssociationHelper.TypeText("PostalCode", "60601");
            partnerAssociationHelper.WaitForWorkAround(3000);

            //############## click on Save Contact 

            //CLICK DoNotSolicit
            partnerAssociationHelper.ClickElement("SaveAGENTbtn");
        }
    }
}