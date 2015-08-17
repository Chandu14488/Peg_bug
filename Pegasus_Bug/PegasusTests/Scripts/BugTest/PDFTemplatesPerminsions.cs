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
    public class PDFTemplatesPerminsions : DriverTestCase
    {
        [TestMethod]
        public void pDFTemplatesPerminsions()
        {
            string[] username = null;
            string[] password = null;

            XMLParse oXMLData = new XMLParse();
            oXMLData.LoadXML("../../Config/ApplicationSettings.xml");

            username = oXMLData.getData("settings/Credentials", "username");
            password = oXMLData.getData("settings/Credentials", "password");

            //Initializing the objects
            var loginHelper = new LoginHelper(GetWebDriver());
            var clientHelper = new ClientsHelper(GetWebDriver());
            var clientBugsHelper = new ClientBugsHelper(GetWebDriver());

            // Variable
            var name = "Test" + RandomNumber(1,99);


            //Login with valid username and password
            Login(username[0], password[0]);
            Console.WriteLine("Logged in as: " + username[0] + " / " + password[0]);

            //Verify Page title
            VerifyTitle("Dashboard");
            Console.WriteLine("Redirected at Dashboard screen.");


//#######################  MOVE HOVER TO THE WELCOME
            //Click on Move over
          //  clientBugsHelper.ClickElement("MouserHoverWelcome");

            //Click On  Admin
            GetWebDriver().Navigate().GoToUrl("https://www.pegasus-test.com/selenium_corp/selenium_office/admin");

//################################# PDF TEMPLATE TAB #############################################

            //Click on Terminal And Equipment Tab
            clientBugsHelper.ClickElement("ClickOnPDFTab");
              
            //Redirect
            GetWebDriver().Navigate().GoToUrl("https://www.pegasus-test.com/selenium_corp/selenium_office/pdf_templates");

            //Click on PDF
            clientBugsHelper.ClickElement("ClickPDF");

            //Click On Permisions
            clientBugsHelper.ClickElement("ClickOnPermisions");
            clientBugsHelper.WaitForWorkAround(3000);


            //Click On None Of These
            clientBugsHelper.ClickElement("ClickOnNoneOfThese");

            //Click on Updtae
            clientBugsHelper.ClickElement("ClickOnUpdate");
            clientBugsHelper.WaitForWorkAround(2000);

            //Verify Text
            clientBugsHelper.VerifyPageText("Pdf Permissions Updated Successfully.");

   

        }
    }
}
