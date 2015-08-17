using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PegasusTests.PageHelper;
using PegasusTests.PageHelper.Comm;

namespace PegasusTests.Scripts.ClientsTests
{
    [TestClass]
    public class ConvertLeadToClientFromPDFTab : DriverTestCase
    {
        [TestMethod]
        public void convertLeadToClientFromPDFTab()
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
            var clientHelperNewSkin = new ClientHelperNewSkin(GetWebDriver());

            //VARIABLE
            var name = "TestEmployee" + GetRandomNumber();


            //Login with valid username and password
            Login(username[0], password[0]);
            Console.WriteLine("Logged in as: " + username[0] + " / " + password[0]);

            //Verify Page title
            VerifyTitle("Dashboard");
            Console.WriteLine("Redirected at Dashboard screen.");

            //Click on Agent in Topmenu
            clientHelperNewSkin.ClickElement("ClickOnLeadTab");

            //Redirect To 
            GetWebDriver().Navigate().GoToUrl("https://www.pegasus-test.com/selcorp/seloffice/leads/create");

            //Select Lead Status
            clientHelperNewSkin.Select("SelectLeadStatus", "New");

            //LeadResponsibility
            clientHelperNewSkin.Select("LeadResponsibility", "637");


            //Click on Save
            clientHelperNewSkin.ClickElement("ClickSaveClient");
            clientHelperNewSkin.WaitForWorkAround(4000);

            //Enter First Name 
            clientHelperNewSkin.TypeText("EnterFirstNameLaed", "Test Lead");

            //EnterLastName
            clientHelperNewSkin.TypeText("EnterLastName", "Tester");


            var Company = "My Company" + RandomNumber(1,999);
            //Enter Company Nmae
            clientHelperNewSkin.TypeText("EnterCompanyName",Company);

            //Click on Save
            clientHelperNewSkin.ClickElement("ClickSaveClient");
            clientHelperNewSkin.WaitForWorkAround(4000);



            var LocDub = "//button[text()='Create Duplicate']";
            if (clientHelperNewSkin.IsElementPresent(LocDub))
            {
                clientHelperNewSkin.Click(LocDub);
            }

            //Clivc PDF
            clientHelperNewSkin.WaitForWorkAround(4000);
            clientHelperNewSkin.Click("//a[text()='PDFs']");

            //Click on Convert
            clientHelperNewSkin.ClickElement("ClickOnConvert");

            //Yes Move To Recycle Bin
            clientHelperNewSkin.ClickElement("ClickOnYes");

            //Click Convert Save Lead
            clientHelperNewSkin.Click("//div[@class='modal-footer']/button[@type='submit']");
            clientHelperNewSkin.WaitForWorkAround(4000);


            //Verify 
            clientHelperNewSkin.VerifyPageText("Lead is converted and moved to recyclebin.");
            clientHelperNewSkin.WaitForWorkAround(4000);

            //Redirect To Recycle bin
            GetWebDriver().Navigate().GoToUrl("https://www.pegasus-test.com/selcorp/seloffice/opportunities/recyclebin");

            //Enter Lead To Search
            clientHelperNewSkin.TypeText("EnterLeadToSerach",Company);
            clientHelperNewSkin.WaitForWorkAround(4000);

            //Verify 
            clientHelperNewSkin.VerifyText("VerifyTextComapny", Company);
            clientHelperNewSkin.WaitForWorkAround(4000);

             
           }
      }
 }
    

