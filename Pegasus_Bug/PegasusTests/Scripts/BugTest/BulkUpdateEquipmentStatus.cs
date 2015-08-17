using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using PegasusTests.PageHelper;
using PegasusTests.PageHelper.Comm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace PegasusTests.Scripts.ClientsTests
{
    [TestClass]
    public class BulkUpdateEquipmentStatus : DriverTestCase
    {
        [TestMethod]
        public void bulkUpdateEquipmentStatus()
        {
            string[] username = null;
            string[] password = null;

            XMLParse oXMLData = new XMLParse();
            oXMLData.LoadXML("../../Config/ApplicationSettings.xml");

            username = oXMLData.getData("settings/Credentials", "username");
            password = oXMLData.getData("settings/Credentials", "password");

            //Initializing the objects
            LoginHelper loginHelper = new LoginHelper(GetWebDriver());
            ClientsHelper clientHelper = new ClientsHelper(GetWebDriver());
            EditEquipmentAdminHelper editEquipmentAdminHelper = new EditEquipmentAdminHelper(GetWebDriver());

            //Variable 
            String  name = "Test" + RandomNumber(1,99);
            String Id = "12345" + RandomNumber(1,99);


            //Login with valid username and password
            Login(username[0], password[0]);
            Console.WriteLine("Logged in as: " + username[0] + " / " + password[0]);

            //Verify Page title
            VerifyTitle("Dashboard");
            Console.WriteLine("Redirected at Dashboard screen.");


//####################### Redirect To 
           

            //Click On  Admin
            GetWebDriver().Navigate().GoToUrl("https://www.pegasus-test.com/selcorp/seloffice/admin");


//################################# Terminal And Equipment Tab #############################################

            //Click on Terminal And Equipment Tab
            editEquipmentAdminHelper.ClickElement("ClickOnEquipmentTabNW");

//##################  Redirect To Url

            //Redirect To URL
            GetWebDriver().Navigate().GoToUrl("https://www.pegasus-test.com/selcorp/seloffice/equipment");

//#################### Create Equipments

            //Enter Name in seacrh field
            editEquipmentAdminHelper.TypeText("EnterNameInSearch", "Bulk Equipment");
            editEquipmentAdminHelper.WaitForWorkAround(5000);

            var Loc = "//table[@id='list1']/tbody/tr[2]";
            if (editEquipmentAdminHelper.IsElementPresent(Loc))
            {

                //ClickOn Equipment
                editEquipmentAdminHelper.ClickElement("ClickOnEquipChkBox");

                //Click On Clone
                editEquipmentAdminHelper.ClickElement("ClickBulkUpdateBtn");

                //Change Status
                editEquipmentAdminHelper.ClickElement("ChangeStatusBU");

                //Select Status
                editEquipmentAdminHelper.Select("SelectStatus","1");

                //Click on Update button
                editEquipmentAdminHelper.ClickElement("ClickOnSaveBulkPopUp");
                editEquipmentAdminHelper.AcceptAlert();
                editEquipmentAdminHelper.WaitForWorkAround(3000);
                editEquipmentAdminHelper.VerifyPageText("Record(s) updated successfully");
                editEquipmentAdminHelper.WaitForWorkAround(2000);

            }

            else
            {

                // Click On Create
                editEquipmentAdminHelper.ClickElement("ClickOnCreatEquipmNW");
                editEquipmentAdminHelper.WaitForWorkAround(3000);

                //Enter Equipment Name
                editEquipmentAdminHelper.TypeText("EqpName", "Bulk Equipment");

                //Enter DownloadsIDName
                editEquipmentAdminHelper.Select("Type", "Check Reader");

                //Enter Equipment Id
                editEquipmentAdminHelper.TypeText("EquipmentId", Id);

                //Enter Category
           //     editEquipmentAdminHelper.Select("Category", "68");

                //Enter Version
                editEquipmentAdminHelper.TypeText("Version", "Testing");

                //Enter Description
                editEquipmentAdminHelper.TypeText("Description", "This is Testing Description");

                //Click On First CheckBox
                editEquipmentAdminHelper.ClickElement("ClickOnFirstCheckBox");

                //Click On Second CheckBox
             //   editEquipmentAdminHelper.ClickElement("ClickOn2CheckBox");

                // Click on Save button   
                editEquipmentAdminHelper.ClickElement("ClickSavebtnNS");
                editEquipmentAdminHelper.WaitForWorkAround(3000);

                //Enter Name in seacrh field
                editEquipmentAdminHelper.TypeText("EnterNameInSearch", "Bulk Equipment");
                editEquipmentAdminHelper.WaitForWorkAround(3000);

                //ClickOn Equipment
                editEquipmentAdminHelper.ClickElement("ClickOnEquipChkBox");

                //Click On Bulk Update
                editEquipmentAdminHelper.ClickElement("ClickBulkUpdateBtn");

                //Change Status
                editEquipmentAdminHelper.ClickElement("ChangeStatusBU");

                //Select Status
                editEquipmentAdminHelper.Select("SelectStatus", "1");

                //Click on Update button
                editEquipmentAdminHelper.ClickElement("ClickOnSaveBulkPopUp");
                editEquipmentAdminHelper.AcceptAlert();
                editEquipmentAdminHelper.WaitForWorkAround(3000);
                editEquipmentAdminHelper.VerifyPageText("Record(s) updated successfully");
                editEquipmentAdminHelper.WaitForWorkAround(2000);

            }
        }
    }
}
