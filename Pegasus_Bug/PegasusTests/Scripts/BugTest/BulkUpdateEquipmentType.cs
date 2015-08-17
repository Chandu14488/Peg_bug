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
    public class BulkUpdateEquipmentType : DriverTestCase
    {
        [TestMethod]
        public void bulkUpdateEquipmentType()
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


            //Redirecte to admin
            GetWebDriver().Navigate().GoToUrl("https://www.pegasus-test.com/selcorp/seloffice/admin");
            editEquipmentAdminHelper.WaitForWorkAround(4000);

            //################################# Terminal And Equipment Tab #############################################

            //Click on Terminal And Equipment Tab
            editEquipmentAdminHelper.ClickElement("ClickOnEquipmentTabNW");
            editEquipmentAdminHelper.WaitForWorkAround(4000);

            //##################  Redirect To Url

            //Redirect To URL
            GetWebDriver().Navigate().GoToUrl("https://www.pegasus-test.com/selcorp/seloffice/equipment");
            editEquipmentAdminHelper.WaitForWorkAround(4000);

//#################### Create Equipments

            //Enter Name in seacrh field
        //    editEquipmentAdminHelper.TypeText("EnterNameInSearch", "Bulk Equipment");
            editEquipmentAdminHelper.WaitForWorkAround(5000);

            var Loc = "//table[@id='list1']/tbody/tr[2]";
            if (editEquipmentAdminHelper.IsElementPresent(Loc))
            {

                //ClickOn Equipment
                editEquipmentAdminHelper.ClickElement("ClickOnEquipChkBox");

                //Click On Clone
                editEquipmentAdminHelper.ClickElement("ClickBulkUpdateBtn");
                editEquipmentAdminHelper.WaitForWorkAround(3000);

                //Change Status
                editEquipmentAdminHelper.ClickElement("ClikEquipType");
                editEquipmentAdminHelper.WaitForWorkAround(3000);


                //Select Status
                editEquipmentAdminHelper.Select("EquipTypeStatus", "Check Reader");
                editEquipmentAdminHelper.WaitForWorkAround(3000);

                //Click on Update button
                editEquipmentAdminHelper.ClickElementMultiple("ClickOnSaveBulkPopUp");
                editEquipmentAdminHelper.AcceptAlert();
                editEquipmentAdminHelper.WaitForWorkAround(3000);
                editEquipmentAdminHelper.VerifyPageText("Record(s) updated successfully");
                editEquipmentAdminHelper.WaitForWorkAround(2000);

            }

            else
            {

                // Click On Create
                editEquipmentAdminHelper.ClickElement("ClickOnCreate");
                editEquipmentAdminHelper.WaitForWorkAround(3000);

                //Enter Equipment Name
                editEquipmentAdminHelper.TypeText("EqpName", "Bulk Equipment");

                //Enter DownloadsIDName
                editEquipmentAdminHelper.Select("Type", "Check Reader");

                //Enter Equipment Id
                editEquipmentAdminHelper.TypeText("EquipmentId", Id);

                //Enter Category
                editEquipmentAdminHelper.Select("Category", "68");

                //Enter Version
                editEquipmentAdminHelper.TypeText("Version", "Testing");

                //Enter Description
                editEquipmentAdminHelper.TypeText("Description", "This is Testing Description");

                //Click On First CheckBox
        //        editEquipmentAdminHelper.ClickElement("ClickOnFirstCheckBox");

                //Click On Second CheckBox
     //           editEquipmentAdminHelper.ClickElement("ClickOn2CheckBox");


                // Click on Save button   
                editEquipmentAdminHelper.ClickElement("ClickSavebtnNS");
                editEquipmentAdminHelper.WaitForWorkAround(3000);


                //Enter Name in seacrh field
      //          editEquipmentAdminHelper.TypeText("EnterNameInSearch", "Bulk Equipment");
                editEquipmentAdminHelper.WaitForWorkAround(3000);

                //ClickOn Equipment
                editEquipmentAdminHelper.ClickElement("ClickOnEquipChkBox");

                //Click On Clone
                editEquipmentAdminHelper.ClickElement("ClickBulkUpdateBtn");

                //Change Status
                editEquipmentAdminHelper.ClickElement("ClikEquipType");

                //Select Status
                editEquipmentAdminHelper.Select("EquipTypeStatus", "Check Reader");

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
