using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PegasusTests.PageHelper;
using PegasusTests.PageHelper.Comm;

namespace PegasusTests.Scripts.ClientsTests
{
    [TestClass]
    public class ImportClientsFromCSV : DriverTestCase
    {
        [TestMethod]
        public void importClientsFromCSV()
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
            var clientBugsHelper = new ClientBugsHelper(GetWebDriver());

            //Variable

            var FirstName = "Test" + RandomNumber(1, 99);
            var LastName = "Tester" + RandomNumber(1, 99);
            var Number = "12345678" + RandomNumber(10, 99);

            //Login with valid username and password
            Login(username[0], password[0]);
            Console.WriteLine("Logged in as: " + username[0] + " / " + password[0]);

            //Verify Page title
            VerifyTitle("Dashboard");
            Console.WriteLine("Redirected at Dashboard screen.");

            //Click on Clients in Topmenu
            clientBugsHelper.ClickElement("ClientTab");
            clientBugsHelper.WaitForElementPresent("ClickOnImport", 20);

      
            //Click On Import
            clientBugsHelper.ClickElement("ClickOnImport");
            clientBugsHelper.WaitForWorkAround(2000);
             
            //Upload
            var Path = GetPathToFile() + "clientsamples(2).csv";
            clientBugsHelper.uploadCSVClient("SelectFile", Path);
            clientBugsHelper.WaitForWorkAround(3000);

            //Click On Import
            clientBugsHelper.ClickElement("ClickOnImportClint");
            clientBugsHelper.WaitForWorkAround(3000);

            //Select Client Import
        //  clientBugsHelper.Select("SelectClientImport","47");
            clientBugsHelper.WaitForWorkAround(3000);

            //Residual Import Sel
            //clientBugsHelper.Select("ResidualImportSel", "");

            //ClickImprtProcess
            clientBugsHelper.ClickElement("ClickImprtProcess");
            clientBugsHelper.WaitForWorkAround(10000);



        }
    }
}
