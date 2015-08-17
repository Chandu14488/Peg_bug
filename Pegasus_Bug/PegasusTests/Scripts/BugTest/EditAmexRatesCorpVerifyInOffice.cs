using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PegasusTests.PageHelper;
using PegasusTests.PageHelper.Comm;

namespace PegasusTests.Scripts.Corp
{
    [TestClass]
    public class EditAmexRatesCorpVerifyInOffice : DriverTestCase
    {
        [TestMethod]
        public void editAmexRatesCorpVerifyInOffice()
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
            var createAmexRateHelper = new CreateAmexRateHelper(GetWebDriver());

            //Variable
            var Num = "1" + RandomNumber(1, 999);
            var Nam = "New" + RandomNumber(1, 999);
            var name = "Test" + RandomNumber(1, 99);
            var NewNum = "1"+RandomNumber(1, 99);

            //Login with valid username and password
            createAmexRateHelper.TypeText("EnterUsername", "selcorp");

            //Login with valid username and password
            createAmexRateHelper.TypeText("EnterPassword", "seWelcome2");

            //Login Button
            createAmexRateHelper.Click("//button[text()='Login']");
            createAmexRateHelper.WaitForWorkAround(4000);

            //Verify Page title
            VerifyTitle("Dashboard");
            Console.WriteLine("Redirected at Dashboard screen.");
          
            //Redirect TO cRETAE
            GetWebDriver().Navigate().GoToUrl("https://www.pegasus-test.com/selcorp/masterdata/manage_amex_rates");

            //Enter Processor name
            createAmexRateHelper.TypeText("MCCCode", Num);

            //Enter ProcessorCode
            createAmexRateHelper.TypeText("AmexRate", name);

            //Enter Amex Per Rate
            createAmexRateHelper.TypeText("AmexPerItem", Nam);

            //Click On Save Btn
            createAmexRateHelper.Click("//a[@title='Save']");
            createAmexRateHelper.WaitForWorkAround(3000);

            //Verify Text The Amex Rates is successfully created!!
            createAmexRateHelper.VerifyPageText("The Amex Rates is successfully created!!");

            //Search with  MCC Codes
            createAmexRateHelper.TypeText("SecrhMCCCodes", Num);
            createAmexRateHelper.WaitForWorkAround(2000);

            //Click on Edit Save
            createAmexRateHelper.ClickElement("ClickOnEDit");

            //Enter ProcessorCode
            createAmexRateHelper.TypeText("AmexRate", NewNum);

            //Enter Amex Per Rate
            createAmexRateHelper.TypeText("AmexPerItem", NewNum);

            //Click on Edit Save
            createAmexRateHelper.Click("//a[@title='Save']");
            createAmexRateHelper.WaitForWorkAround(2000);

            //Verify The Amex Rates is successfully updated!!
            createAmexRateHelper.VerifyPageText("The Amex Rates is successfully updated!!");
            createAmexRateHelper.WaitForWorkAround(2000);

            //Click To Push To Office Frm Corp
            createAmexRateHelper.ClickElement("PushOfficeFrmCorp");
            createAmexRateHelper.AcceptAlert();
            createAmexRateHelper.WaitForWorkAround(4000);
            createAmexRateHelper.VerifyPageText("Amex Rates successfully pushed to offices.");

            //Logout
            GetWebDriver().Navigate().GoToUrl("https://www.pegasus-test.com/selenium_corp/selenium_office/logout");

            //Login with valid username and password
            Login(username[0], password[0]);
            Console.WriteLine("Logged in as: " + username[0] + " / " + password[0]);

            //Redirect To Admin
      //      GetWebDriver().Navigate().GoToUrl("https://www.pegasus-test.com/selenium_corp/selenium_office/admin");

            //Click on Master Data
      //      createAmexRateHelper.ClickElement("ClickOnMaterOff");

            //Redirect 
            GetWebDriver().Navigate().GoToUrl("https://www.pegasus-test.com/selcorp/seloffice/amex_rates");


            //Search with  MCC Codes
            createAmexRateHelper.TypeText("SecrhMCCCodes", Num);
            createAmexRateHelper.WaitForWorkAround(2000);
  
            //Verify
            createAmexRateHelper.VerifyPageText(NewNum);
            createAmexRateHelper.WaitForWorkAround(3000);

        }
    }
}