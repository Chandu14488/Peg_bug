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
    public class CloneEquipment : DriverTestCase
    {
        [TestMethod]
        public void cloneEquipment()
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


            //Redirect To Equipment
            GetWebDriver().Navigate().GoToUrl("https://www.pegasus-test.com/selcorp/seloffice/equipment");
            editEquipmentAdminHelper.WaitForWorkAround(4000);


            var Loc = "//table[@id='list1']/tbody/tr[2]";
            if (editEquipmentAdminHelper.IsElementPresent(Loc))
            {

                //ClickOn Equipment
                editEquipmentAdminHelper.ClickElement("ClickOneQUIP");

                //Click On Clone
                editEquipmentAdminHelper.ClickElement("ClickOnClone");
                editEquipmentAdminHelper.WaitForWorkAround(4000);

                //Verify 
                editEquipmentAdminHelper.VerifyPageText("Equipment is cloned successfully");
                editEquipmentAdminHelper.VerifyPageText("Clone of Equipment");
                editEquipmentAdminHelper.ClickElement("ClickDelClone");
                editEquipmentAdminHelper.AcceptAlert();
                editEquipmentAdminHelper.WaitForWorkAround(3000);
                editEquipmentAdminHelper.VerifyPageText("Equipment deleted successfully.");
                editEquipmentAdminHelper.WaitForWorkAround(3000);
            }

            else
            {

                // Click On Create
                GetWebDriver().Navigate().GoToUrl("https://www.pegasus-test.com/selcorp/seloffice/equipment/create");
                editEquipmentAdminHelper.WaitForWorkAround(3000);

                //Enter Equipment Name
                editEquipmentAdminHelper.TypeText("EqpName", "Clone Equipment");

                //Enter DownloadsIDName
                editEquipmentAdminHelper.Select("Type", "Check Reader");

                //Enter Equipment Id
                editEquipmentAdminHelper.TypeText("EquipmentId", Id);

                //Enter Category
         //       editEquipmentAdminHelper.Select("Category", "68");

                //Enter Version
                editEquipmentAdminHelper.TypeText("Version", "Testing");

                //Enter Description
                editEquipmentAdminHelper.TypeText("Description", "This is Testing Description");

                //Click On First CheckBox
            //    editEquipmentAdminHelper.ClickElement("ClickOnFirstCheckBox");

                //Click On Second CheckBox
          //      editEquipmentAdminHelper.ClickElement("ClickOn2CheckBox");

                //######################## CLICK ON SAVE BUTTON  ########################################
                // Click on Save button   
                editEquipmentAdminHelper.ClickElement("SaveBtn");
                editEquipmentAdminHelper.WaitForWorkAround(3000);

                //ClickOn Equipment
                editEquipmentAdminHelper.ClickElement("ClickOneQUIP");

                //Click On Clone
                editEquipmentAdminHelper.ClickElement("ClickOnClone");

                //Verify 
                //Verify 
                editEquipmentAdminHelper.VerifyPageText("Equipment is cloned successfully");
                editEquipmentAdminHelper.VerifyPageText("Clone of Equipment");
                editEquipmentAdminHelper.ClickElement("ClickDelClone");
                editEquipmentAdminHelper.AcceptAlert();
                editEquipmentAdminHelper.WaitForWorkAround(3000);
                editEquipmentAdminHelper.VerifyPageText("Equipment deleted successfully.");
                editEquipmentAdminHelper.WaitForWorkAround(3000);
            }
        }
    }
}
