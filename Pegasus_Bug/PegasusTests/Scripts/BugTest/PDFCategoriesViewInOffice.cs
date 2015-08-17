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
    public class PDFCategoriesViewInOffice : DriverTestCase
    {
        [TestMethod]
        public void pDFCategoriesViewInOffice()
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
            LoginAsCorpHelper loginAsCorpHelper = new LoginAsCorpHelper(GetWebDriver());
            CreatePDFCategoriesHelper createPDFCategoriesHelper = new CreatePDFCategoriesHelper(GetWebDriver());
            
            //Variable random
           
            String  name = "Test" + RandomNumber(1, 99);


            //Login with valid credential  Username
            loginAsCorpHelper.TypeText("EnterUsername", "selcorp");

            //Login with valid credential password
            loginAsCorpHelper.TypeText("EnterPassword", "seWelcome2");

            //Click On Login Button
            loginAsCorpHelper.ClickElement("ClickOnLoginButton");
            loginAsCorpHelper.WaitForWorkAround(3000);

            //Verify Page title
            VerifyTitle("Dashboard");
            Console.WriteLine("Redirected at Dashboard screen.");

            //Click on Agent in Topmenu
            createPDFCategoriesHelper.ClickElement("ClickOnPDFTemplateTab");


//################################# ADD NEW CATEGORY  #############################################

            //Click on Click On Partner Agent
            createPDFCategoriesHelper.redirectToPage();

            //Click on PDF Category
       //     createPDFCategoriesHelper.ClickElement("ClickOnPDFCategory");

            //Click on Click create button
            createPDFCategoriesHelper.ClickElement("ClickOnCreateBtn");
            createPDFCategoriesHelper.WaitForWorkAround(6000);

            //Enter Name
            createPDFCategoriesHelper.TypeText("EnterName", name);

            //Click on Save Button
            createPDFCategoriesHelper.ClickElement("ClickOnSaveBtn");
            
            //Verify text present
            createPDFCategoriesHelper.VerifyPageText("Category Created Successfully");
            createPDFCategoriesHelper.WaitForWorkAround(3000);


            //Redirect To Url
            GetWebDriver().Navigate().GoToUrl("https://www.pegasus-test.com/selenium_corp/selenium_office/logout");
            createPDFCategoriesHelper.WaitForWorkAround(3000);

            //Login with valid username and password
            Login(username[0], password[0]);
            Console.WriteLine("Logged in as: " + username[0] + " / " + password[0]);

            //Redirect To Admin
            GetWebDriver().Navigate().GoToUrl("https://www.pegasus-test.com/selenium_corp/selenium_office/admin");
  

            //Click on PDF Tab
            createPDFCategoriesHelper.ClickElement("ClickOnPDFTab");

            //Reirect to PDF Category
            GetWebDriver().Navigate().GoToUrl("https://www.pegasus-test.com/selenium_corp/selenium_office/pdf_templates/categories");
        
           //Verify Text 
            createPDFCategoriesHelper.VerifyPageText("name");
            createPDFCategoriesHelper.WaitForWorkAround(4000);
        
        }

    }
}
