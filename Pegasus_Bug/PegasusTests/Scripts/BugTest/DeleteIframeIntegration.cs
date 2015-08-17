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
    public class DeleteIframeIntegration : DriverTestCase
    {
        [TestMethod]
        public void deleteIframeIntegration()
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
            CreateIframeAdminHelper createIframeAdminHelper = new CreateIframeAdminHelper(GetWebDriver());

            // Variable
            String name = "Delete" + RandomNumber(99,999);
            String usrname = "Test.Tester" + RandomNumber(1, 99);

            //Login with valid username and password
            Login(username[0], password[0]);
            Console.WriteLine("Logged in as: " + username[0] + " / " + password[0]);

            //Verify Page title
            VerifyTitle("Dashboard");
            Console.WriteLine("Redirected at Dashboard screen.");


            //Redirect To Create 
            GetWebDriver().Navigate().GoToUrl("https://www.pegasus-test.com/selcorp/seloffice/iframes/create");
            createIframeAdminHelper.WaitForWorkAround(4000);



            //Enter Tab Name
            createIframeAdminHelper.TypeText("TabName", name);

//#################################   APP SETTING   ######################3


            //Click on Generate API Code
            createIframeAdminHelper.TypeText("UserNameInputFieldName", usrname);
            createIframeAdminHelper.WaitForWorkAround(4000);

            //Select  Status
            createIframeAdminHelper.TypeText("PasswordInputFieldNmae", "1qaz!QAZ");


            //Select responsibilities
            createIframeAdminHelper.TypeText("LoginURL", "https://www.pegasus-test.com/selenium_corp/selenium_office/login");

            //Click on mainportal
            createIframeAdminHelper.ClickElement("mainportal");

            //cLICK on Save  
            createIframeAdminHelper.ClickElement("SaveBtn");
            createIframeAdminHelper.WaitForWorkAround(5000);
            createIframeAdminHelper.VerifyPageText("Iframe Created Successfully.");

            //Search 
            createIframeAdminHelper.TypeText("TabNameSearch", name);
            createIframeAdminHelper.WaitForWorkAround(4000);

            //Clcik on delete
            createIframeAdminHelper.ClickElement("ClickOnDelete");
            createIframeAdminHelper.AcceptAlert();
            createIframeAdminHelper.WaitForWorkAround(4000);
            createIframeAdminHelper.VerifyPageText("Iframe deleted successfully.");

        }
    }
}
