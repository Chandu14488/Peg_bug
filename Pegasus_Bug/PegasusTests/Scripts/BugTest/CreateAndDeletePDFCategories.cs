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
    public class CreateAndDeletePDFCategories : DriverTestCase
    {
        [TestMethod]
        public void createAndDeletePDFCategories()
        {
           string[] username = null;
           string[] password = null;

            XMLParse oXMLData = new XMLParse();
            oXMLData.LoadXML("../../Config/ApplicationSettings.xml");

            username = oXMLData.getData("settings/Credentials", "username2");
            password = oXMLData.getData("settings/Credentials", "password2");

            //Initializing the objects
            LoginHelper loginHelper = new LoginHelper(GetWebDriver());
            ClientsHelper clientHelper = new ClientsHelper(GetWebDriver());
            LoginAsCorpHelper loginAsCorpHelper = new LoginAsCorpHelper(GetWebDriver());
            CreatePDFCategoriesHelper createPDFCategoriesHelper = new CreatePDFCategoriesHelper(GetWebDriver());
            
            //Variable random
           
            String  name = "Test" + RandomNumber(1, 99);


            //Login with valid username and password
            Login(username[0], password[0]);
            Console.WriteLine("Logged in as: " + username[0] + " / " + password[0]);

            //Verify Page title
            VerifyTitle("Dashboard");
            Console.WriteLine("Redirected at Dashboard screen.");

            //Verify Page title
            VerifyTitle("Dashboard");
            Console.WriteLine("Redirected at Dashboard screen.");

            //Redirect To 
            GetWebDriver().Navigate().GoToUrl("https://www.pegasus-test.com/selcorp/pdf_templates/categories");
            createPDFCategoriesHelper.WaitForWorkAround(6000);

            //Click on Click create button
            createPDFCategoriesHelper.ClickElement("ClickOnCreateBtn");
            createPDFCategoriesHelper.WaitForWorkAround(6000);
            

            //Enter Name
            createPDFCategoriesHelper.TypeText("EnterName", name);

            //Click on Save Button
            createPDFCategoriesHelper.ClickElement("ClickOnSaveBtn");
            createPDFCategoriesHelper.WaitForWorkAround(6000);

            //Verify text present
            createPDFCategoriesHelper.VerifyPageText("Category Created Successfully");

            //Clcik on Delete
            createPDFCategoriesHelper.SearchAndClick(name);
            createPDFCategoriesHelper.AcceptAlert();
            createPDFCategoriesHelper.ClickDisplayed("//a[@title='Save']");
            createPDFCategoriesHelper.WaitForWorkAround(4000);
         //   GetWebDriver().Navigate().Refresh();

         
           createPDFCategoriesHelper.VerifyPageText("Category Replaced Successfully.");

        }
    }
}
