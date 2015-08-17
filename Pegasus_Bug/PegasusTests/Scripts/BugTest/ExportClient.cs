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
    public class ExportClient : DriverTestCase
    {
        [TestMethod]
        public void exportClient()
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
         //   createPDFsHelper.ClickElement("ClientTab");
            GetWebDriver().Navigate().GoToUrl("https://www.pegasus-test.com/selcorp/seloffice/clients");
            createPDFsHelper.WaitForWorkAround(4000);

            //Click Export Btn
            createPDFsHelper.ClickElement("ExportBtn");

            //Click on Export to csv 
            createPDFsHelper.ClickElement("ExportToExcel");
            createPDFsHelper.WaitForWorkAround(4000);
            

        }
    }
}
