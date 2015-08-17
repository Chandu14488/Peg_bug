using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PegasusTests.PageHelper;
using PegasusTests.PageHelper.Comm;

namespace PegasusTests.Scripts.ClientsTests
{
    [TestClass]
    public class BulkUpdateSaleAgent : DriverTestCase
    {
        [TestMethod]
        public void bulkUpdateSaleAgent()
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
            var filePath = @"D:\pegqa\TestAutomationProject\PegasusTests\Screenshots\EXLFile\AgentImport.xlsx";
            Console.WriteLine("FILE = " + filePath);

            //Variable random
            var name = "TESTCLIENT" + GetRandomNumber();


            //Login with valid username and password
            Login(username[0], password[0]);
            Console.WriteLine("Logged in as: " + username[0] + " / " + password[0]);

            //Verify Page title
            VerifyTitle("Dashboard");
            Console.WriteLine("Redirected at Dashboard screen.");

            //Click on Click On Partner Agent
            GetWebDriver().Navigate().GoToUrl("https://www.pegasus-test.com/selcorp/seloffice/sales_agents");
            saleAgentHelper.WaitForWorkAround(3000);

            //Click On Sale Agnet ChkBox
            saleAgentHelper.ClickElement("ClickOnSaleAgnetChkBox");

            //ClickOnBulkUpdate
            saleAgentHelper.ClickElement("ClickOnBulkUpdate");

            
//############ ChangeDepartment

            saleAgentHelper.ClickElement("ChangeDepartment");

            //Select Department
            saleAgentHelper.Select("SelectDepartmentSaleAgnet", "IT");

            
            //ClickOnBulkUpdate
            saleAgentHelper.ClickDisplayed("//a[@title='Update']");
            saleAgentHelper.AcceptAlert();
            

            
//############ Change  Role
            
            //ClickOnBulkUpdate
            saleAgentHelper.ClickElement("ClickOnSaleAgnetChkBox");
            saleAgentHelper.ClickElement("ClickOnBulkUpdate");

            saleAgentHelper.ClickElement("ChangeRole");

            //Select Department
         //   saleAgentHelper.Select("SelectRoleSaleAgent", "Manager");

            
            //ClickOnBulkUpdate
            saleAgentHelper.ClickDisplayed("//a[@title='Update']");
            saleAgentHelper.AcceptAlert();

  //############ Change Team

           //ClickOnBulkUpdate
            saleAgentHelper.ClickElement("ClickOnSaleAgnetChkBox");
            saleAgentHelper.ClickElement("ClickOnBulkUpdate");

            //
            saleAgentHelper.ClickElement("ChangeTeam");

            //Select Department
        //    saleAgentHelper.Select("SelectTeam","A Team");

            
            //ClickOnBulkUpdate
            saleAgentHelper.ClickDisplayed("//a[@title='Update']");
            saleAgentHelper.AcceptAlert();

 //############ ChangeDepartment

             //ClickOnBulkUpdate
            saleAgentHelper.ClickElement("ClickOnSaleAgnetChkBox");
            saleAgentHelper.ClickElement("ClickOnBulkUpdate");


            saleAgentHelper.ClickElement("ChangeStatus");

            //Select Department
            saleAgentHelper.Select("SelectStatus","Active");

            //ClickOnBulkUpdate
            saleAgentHelper.ClickDisplayed("//a[@title='Update']");
            saleAgentHelper.AcceptAlert();
            saleAgentHelper.WaitForWorkAround(3000);

      
        }
    }
    }
