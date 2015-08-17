using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PegasusTests.PageHelper;
using PegasusTests.PageHelper.Comm;

namespace PegasusTests.Scripts.Admin
{
    [TestClass]
    public class CloneVendors : DriverTestCase
    {
        [TestMethod]
        public void cloneVendors()
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
            var createVendorHelper = new CreateVendorHelper(GetWebDriver());


            //Login with valid username and password
            Login(username[0], password[0]);
            Console.WriteLine("Logged in as: " + username[0] + " / " + password[0]);

            //Verify Page title
            VerifyTitle("Dashboard");
            Console.WriteLine("Redirected at Dashboard screen.");

            //Redirect To Vandor
            GetWebDriver().Navigate().GoToUrl("https://www.pegasus-test.com/selcorp/seloffice/vendors");
            createVendorHelper.WaitForWorkAround(2000);


            var Loc = "//table[@id='list1']/tbody/tr[2]";
            if (createVendorHelper.IsElementPresent(Loc))
            {
                createVendorHelper.ClickElement("ClickOnVender");
                createVendorHelper.WaitForWorkAround(2000);
                //Enter EquipmentId
                createVendorHelper.ClickElement("Copy");
                createVendorHelper.WaitForWorkAround(2000);
                createVendorHelper.VerifyPageText("Vendor cloned successfully");
               

                //Delete Clone
                createVendorHelper.ClickElement("DeleteClone");
                createVendorHelper.AcceptAlert();
                createVendorHelper.WaitForWorkAround(2000);
                createVendorHelper.VerifyPageText("Vendor Deleted Successfully");

            }

            else
            {

                //#########  Create Vendor

                // Click On Create
                GetWebDriver().Navigate().GoToUrl("https://www.pegasus-test.com/selcorp/seloffice/vendors/create");
                createVendorHelper.WaitForWorkAround(4000);

                //Enter Name
                createVendorHelper.Select("Type", "Test");

                //Enter Type
                createVendorHelper.TypeText("Name", "Clone Vendor");

                //Enter EquipmentId
                createVendorHelper.TypeText("DBAName", "Test123");


                //LinkedURL
                createVendorHelper.Select("Salutation", "Mr");

                //LinkedURL
                createVendorHelper.TypeText("FirstName", "Test");

                //LinkedURL
                createVendorHelper.TypeText("LastName", "Clone");

                //LinkedURL
                createVendorHelper.Select("eAddessType", "E-Mail");

                //EAddress Label
                createVendorHelper.Select("EAddressLabel", "Work");

                //E Address
                createVendorHelper.TypeText("eAddress", "Test@yopmail.com");


                //Phone Type
                createVendorHelper.Select("PhoneType", "Work");

                //Enter Phone Number
              //  createVendorHelper.TypeText("PhoneNumber", "9898952292");


                //Enter Zip Code
                createVendorHelper.TypeText("ZipCodeVendor", "60601");
                createVendorHelper.WaitForWorkAround(3000);

                // Click on Save button   
                createVendorHelper.ClickElement("SaveBtn");
                createVendorHelper.WaitForWorkAround(3000);

                createVendorHelper.ClickElement("ClickOnVender");
                createVendorHelper.WaitForWorkAround(2000);
                //Enter EquipmentId
                createVendorHelper.ClickElement("Copy");
                createVendorHelper.WaitForWorkAround(2000);

                createVendorHelper.VerifyPageText("Vendor cloned successfully");

                //Delete Clone
                createVendorHelper.ClickElement("DeleteClone");

                createVendorHelper.AcceptAlert();
                createVendorHelper.WaitForWorkAround(2000);
                createVendorHelper.VerifyPageText("Vendor Deleted Successfully");

            }

        }
    }
}