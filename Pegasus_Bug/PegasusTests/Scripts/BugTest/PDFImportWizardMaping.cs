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
    public class PDFImportWizardMaping : DriverTestCase
    {
        [TestMethod]
        public void pDFImportWizardMaping()
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

            //Click on Clients in Topmenu
//            clientHelper.clickClients();

            //Click to open client info
   //         clientHelper.OpenClient();

//#######################  MOVE HOVER TO THE WELCOME
            //Click on Move over
            pDFImportWizardHelper.ClickElement("MoveHover");

            //Click On  Admin
            pDFImportWizardHelper.RedirectToAdmin();

//################################# PDF TEMPLATE TAB #############################################

            //Click on Terminal And Equipment Tab
            pDFImportWizardHelper.ClickElement("ClickOnPDFTemplates");
              
            //Redirect
            pDFImportWizardHelper.RedirectToPage();


            //Click on Import  button
            pDFImportWizardHelper.ClickElement("ClickOnImport");

            //Accept Alrt
            pDFImportWizardHelper.AcceptAlert();

            //Click on Click Here Link
            pDFImportWizardHelper.ClickElement("ClickOnClickHereLink");

            //Click On Close Icon
            pDFImportWizardHelper.ClickElement("ClickOnCloseIcon");

            //Choose Module
            pDFImportWizardHelper.Select("ChooseModule", "20");

            //Upload PDF File\
            String filename = "D:\\pegqa\\TestAutomationProject\\PegasusTests\\Files\\2.pdf";
            pDFImportWizardHelper.upload("SelectFile", filename);

            //Click On Import
            pDFImportWizardHelper.ClickElement("ClickOnImport");
            //pDFImportWizardHelper.AcceptAlert();
            pDFImportWizardHelper.WaitForWorkAround(3000);

            //Click on Client Type
            pDFImportWizardHelper.ClickElement("ClickOnClientRadioBtn");

            //Click On Next
            pDFImportWizardHelper.ClickElement("ClickOnNext");
            pDFImportWizardHelper.WaitForWorkAround(1000);
            
            //Select Category
            pDFImportWizardHelper.Select("SelectCategory", "292");

            //Click on Save button
            pDFImportWizardHelper.ClickElement("ClickOnSaveBtn");
            pDFImportWizardHelper.WaitForWorkAround(4000);





        }
    }
}
