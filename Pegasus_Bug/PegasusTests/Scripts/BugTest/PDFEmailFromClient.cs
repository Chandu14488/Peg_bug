using Microsoft.VisualStudio.TestTools.UnitTesting;
using PegasusTests.PageHelper;
using PegasusTests.PageHelper.Comm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PegasusTests.Scripts.ClientsTests
{
    [TestClass]
    public class PDFEmailFromClient : DriverTestCase
    {
        [TestMethod]
        public void pDFEmailFromClient()
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
            CreatePDFsHelper createPDFsHelper = new CreatePDFsHelper(GetWebDriver());

            //Login with valid username and password
            Login(username[0], password[0]);
            Console.WriteLine("Logged in as: " + username[0] + " / " + password[0]);

            //Verify Page title
            VerifyTitle("Dashboard");
            Console.WriteLine("Redirected at Dashboard screen.");

            createPDFsHelper.WaitForWorkAround(4000);

            //Click On Client Tab
            createPDFsHelper.ClickElement("ClientTab");

          //Enter Client in search field
     //       createPDFsHelper.TypeText("CompanyNameSrch", "DBAName201505252332461287");

            //Click on Client
            createPDFsHelper.ClickElement("ClickOnClinet");

            //Click On PDF Tabs
            createPDFsHelper.ClickElement("ClickOnPDFTabs");

            //Click on Share Link
            createPDFsHelper.ClickElement("ClickOnEmail");

            //Click on Share Agreement
            createPDFsHelper.ClickElement("ConirmAndContinue");
            createPDFsHelper.WaitForWorkAround(7000);

            //Accept To Share
            createPDFsHelper.ClickElement("ClickOnSendPDFEmail");
            createPDFsHelper.WaitForWorkAround(7000);

            //Verify the message
            createPDFsHelper.VerifyPageText("E-Mail Sent Successfully.");


        }
    }
}
