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
    public class ClonePDFTemplate : DriverTestCase
    {
        [TestMethod]
        public void clonePDFTemplate()
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
            PDFImportWizardHelper pDFImportWizardHelper = new PDFImportWizardHelper(GetWebDriver());

            // Variable
            String name = "Test" + RandomNumber(1,99);


            //Login with valid username and password
            Login(username[0], password[0]);
            Console.WriteLine("Logged in as: " + username[0] + " / " + password[0]);

            //Verify Page title
            VerifyTitle("Dashboard");
            Console.WriteLine("Redirected at Dashboard screen.");

              
            //Redirect to PDF Template
            GetWebDriver().Navigate().GoToUrl("https://www.pegasus-test.com/selcorp/seloffice/pdf_templates");
            pDFImportWizardHelper.WaitForWorkAround(6000);

            var Click = "//table[@id='list1']/tbody/tr[2]";
            if (pDFImportWizardHelper.IsElementPresent(Click))
            {
                Console.WriteLine(pDFImportWizardHelper.IsElementPresent(Click));

                pDFImportWizardHelper.ClickElement("ClickOnPDFToClone");
                pDFImportWizardHelper.ClickElement("ClickOnCloneBtn");
                pDFImportWizardHelper.AcceptAlert();
                pDFImportWizardHelper.WaitForWorkAround(2000);
                pDFImportWizardHelper.VerifyPageText("PDF Template is cloned successfully");
                pDFImportWizardHelper.WaitForWorkAround(2000);
                pDFImportWizardHelper.VerifyPageText("View - Clone of ID");
                pDFImportWizardHelper.WaitForWorkAround(2000);
            }

            else
            {

                //Click On PDF Package
                pDFImportWizardHelper.ClickElement("ClickOnPDFPackage");

                //Enter PDF Name
                pDFImportWizardHelper.TypeText("EnterPDFName", "New PDF");

                //Select Module
                pDFImportWizardHelper.Select("SelectModule", "20");
                pDFImportWizardHelper.WaitForWorkAround(2000);

                //Select Module
                pDFImportWizardHelper.Select("SelectPDFTemplate", "6031");

                //SelectCatory
                pDFImportWizardHelper.Select("SelectCatory", "290");

                //Click Checkbox
                pDFImportWizardHelper.ClickElement("DisplayeInTabs");

                //Click on  Can Share
                pDFImportWizardHelper.ClickElement("CanShare");

                //CanEmail
                pDFImportWizardHelper.ClickElement("CanEmail");

                //Click on Save button
                pDFImportWizardHelper.ClickElement("ClickOnSave");
                pDFImportWizardHelper.VerifyPageText("PDF Package Template Created Successfully.");
                pDFImportWizardHelper.WaitForWorkAround(4000);

   //###################  CLone 
                pDFImportWizardHelper.ClickElement("ClickOnPDFTemplates");

                //Redirect to PDF Template
                GetWebDriver().Navigate().GoToUrl("https://www.pegasus-test.com/selenium_corp/selenium_office/pdf_templates");

                //Enter Name To search
                pDFImportWizardHelper.TypeText("EnterPDFNameToSrch", "New PDF");
                pDFImportWizardHelper.ClickElement("ClickOnPDFToClone");
                pDFImportWizardHelper.WaitForWorkAround(2000);
                pDFImportWizardHelper.ClickElement("ClickOnCloneBtn");
                pDFImportWizardHelper.WaitForWorkAround(2000);
                pDFImportWizardHelper.AcceptAlert();
                pDFImportWizardHelper.WaitForWorkAround(2000);
                pDFImportWizardHelper.VerifyPageText("PDF Template is cloned successfully");
                pDFImportWizardHelper.WaitForWorkAround(2000);
                pDFImportWizardHelper.VerifyPageText("View - Clone of ID");
                pDFImportWizardHelper.WaitForWorkAround(2000);

            }
        }
    }
}
