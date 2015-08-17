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
    public class EditOmahaPDFCorp : DriverTestCase
    {
        [TestMethod]
        public void editOmahaPDFCorp()
        {
            string[] username = null;
            string[] password = null;

            XMLParse oXMLData = new XMLParse();
            oXMLData.LoadXML("../../Config/ApplicationSettings.xml");

            username = oXMLData.getData("settings/Credentials", "username2");
            password = oXMLData.getData("settings/Credentials", "password2");

            //Initializing the objects
            var loginHelper = new LoginHelper(GetWebDriver());
            var clientHelper = new ClientsHelper(GetWebDriver());
            var loginAsCorpHelper = new LoginAsCorpHelper(GetWebDriver());
            var createPDFCategoriesHelper = new CreatePDFCategoriesHelper(GetWebDriver());
             var clientBugsHelper = new ClientBugsHelper(GetWebDriver());
            //Variable random
           
            String  name = "Test" + RandomNumber(1, 99);



            //Login with valid username and password
            Login(username[0], password[0]);
            Console.WriteLine("Logged in as: " + username[0] + " / " + password[0]);

            //Verify Page title
            VerifyTitle("Dashboard");
            Console.WriteLine("Redirected at Dashboard screen.");


            //Click on Click On Partner Agent
            GetWebDriver().Navigate().GoToUrl("https://www.pegasus-test.com/selenium_corp/pdf_templates");
            clientBugsHelper.WaitForWorkAround(4000);

            //Enter Name 
            clientBugsHelper.TypeText("OmahaFirst", "First Data - Omaha");
            clientBugsHelper.WaitForWorkAround(4000);

            //Click on Omaha
            clientBugsHelper.ClickElement("ClickOnEdit");
            clientBugsHelper.WaitForElementPresent("EnterName",30);

            // Enter Name
            clientBugsHelper.TypeText("EnterName", "First Data - Omaha");

            //Click On Save
            clientBugsHelper.ClickElement("ClickOnSaveBtnPDFTemp");
            clientBugsHelper.WaitForWorkAround(4000);





      
  
        }
    }
}
