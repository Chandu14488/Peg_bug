using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PegasusTests.PageHelper;
using PegasusTests.PageHelper.Comm;

namespace PegasusTests.Scripts.Admin
{
    [TestClass]
    public class BulkUpdateVendorType : DriverTestCase
    {
        [TestMethod]
        public void bulkUpdateVendorType()
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


//#######################  MOVE HOVER TO THE WELCOME
            //Click on Move over
            createVendorHelper.ClickElement("MoveHover");

            //Click On  Admin
            createVendorHelper.RedirectToAdmin();

//#########    Terminal And Equipment Tab 

            //Click on Terminal And Equipment Tab
            createVendorHelper.ClickElement("ClickOnEquipmentTab");

//##################  Redirect To Url

            //Redirect To URL
            createVendorHelper.RedirectToPage();

            //EnterVendorName
            createVendorHelper.TypeText("EnterVendorName", "Bulk Vendor");

            //Search Last Name
            createVendorHelper.TypeText("SechFirstName","Test");

            //Search Last Name
            createVendorHelper.TypeText("SearchLastName","Bulk");
            createVendorHelper.WaitForWorkAround(3000);


            var Loc = "//table[@id='list1']/tbody/tr[2]/td[5]/a";
            if (createVendorHelper.IsElementPresent(Loc))
            {
                createVendorHelper.ClickElement("SelectChkBox");
                createVendorHelper.WaitForWorkAround(2000);
                //Enter EquipmentId
                createVendorHelper.ClickElement("ClickOnBulkUpdate");
                createVendorHelper.ClickElement("VendorTypeSelect");

                //Select Vender Type
                createVendorHelper.Select("SelectVenderType", "My Vendor");

                //Click on Update
                createVendorHelper.ClickElement("ClickUpdateVT");
                createVendorHelper.AcceptAlert();
                createVendorHelper.WaitForWorkAround(2000);
                createVendorHelper.VerifyPageText("Vendor Type updated successfully.");
                createVendorHelper.WaitForWorkAround(2000);


            }

            else
            {

                //#########  Create Vendor

                // Click On Create
                createVendorHelper.ClickElement("ClickOnCreate");

                //Enter Name
                createVendorHelper.Select("Type", "My Vendor");

                //Enter Type
                createVendorHelper.TypeText("Name", "Bulk Vendor");

                //Enter EquipmentId
                createVendorHelper.TypeText("DBAName", "Test123");

                //Enter Name
                createVendorHelper.TypeText("Website", "www.test.com");

                //LinkedURL
                createVendorHelper.TypeText("LinkedURL", "LinkedIn.com");

                //TwitterURL
                createVendorHelper.TypeText("TwitterURL", "Twiter.com");

                //LinkedURL
                createVendorHelper.Select("Salutation", "Mr");

                //LinkedURL
                createVendorHelper.TypeText("FirstName", "Test");

                //LinkedURL
                createVendorHelper.TypeText("LastName", "Bulk");

                //LinkedURL
                createVendorHelper.Select("eAddessType", "E-Mail");

                //EAddress Label
                createVendorHelper.Select("EAddressLabel", "Work");

                //E Address
                createVendorHelper.TypeText("eAddress", "Test@yopmail.com");


                //Phone Type
                createVendorHelper.Select("PhoneType", "Work");

                //Enter Phone Number
                createVendorHelper.TypeText("PhoneNumber", "9898952292");


                //Enter Zip Code
                createVendorHelper.TypeText("ZipCodeVendor", "60601");
                createVendorHelper.WaitForWorkAround(3000);

                // Click on Save button   
                createVendorHelper.ClickElement("SaveBtn");
                createVendorHelper.WaitForWorkAround(3000);


                //Click on Terminal And Equipment Tab
                createVendorHelper.ClickElement("ClickOnEquipmentTab");


                //Redirect To URL
                createVendorHelper.RedirectToPage();


                //EnterVendorName
                createVendorHelper.TypeText("EnterVendorName", "Bulk Vendor");

                //Search Last Name
                createVendorHelper.TypeText("SechFirstName", "Test");

                //Search Last Name
                createVendorHelper.TypeText("SearchLastName", "Bulk");
                createVendorHelper.WaitForWorkAround(3000);

                createVendorHelper.ClickElement("SelectChkBox");
                createVendorHelper.WaitForWorkAround(2000);

                //Enter EquipmentId
                createVendorHelper.ClickElement("ClickOnBulkUpdate");
                createVendorHelper.ClickElement("VendorTypeSelect");

                //Select Vender Type
                createVendorHelper.Select("SelectVenderType", "My Vendor");

                //Click on Update
                createVendorHelper.ClickElement("ClickUpdateVT");
                createVendorHelper.AcceptAlert();
                createVendorHelper.WaitForWorkAround(2000);
                createVendorHelper.VerifyPageText("Vendor Type updated successfully.");
                createVendorHelper.WaitForWorkAround(2000);


            }

        }
    }
}