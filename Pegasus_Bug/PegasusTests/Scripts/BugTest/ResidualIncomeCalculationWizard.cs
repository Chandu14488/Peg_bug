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
    public class ResidualIncomeCalculationWizard : DriverTestCase
    {
        [TestMethod]
        public void residualIncomeCalculationWizard()
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
            var loginAsCorpHelper = new LoginAsCorpHelper(GetWebDriver());
            var resdiualIncmeSkipHelper = new ResdiualIncmeSkipHelper(GetWebDriver());
            var resdiualIncmeFstDataNrthHelperRevnueShareSet = new ResdiualIncmeFstDataNrthHelperRevnueShareSet(GetWebDriver());
            var clientBugsHelper = new ClientBugsHelper(GetWebDriver());


            //Login with valid credential  Username
            loginAsCorpHelper.TypeText("EnterUsername", "selcorp");

            //Login with valid credential password
            loginAsCorpHelper.TypeText("EnterPassword", "seWelcome2");

            //Click On Login Button
            loginAsCorpHelper.ClickElement("ClickOnLoginButton");


            //Verify Page title
            VerifyTitle("Dashboard");
            Console.WriteLine("Redirected at Dashboard screen.");

             //Click on Residual Income tab
             resdiualIncmeFstDataNrthHelperRevnueShareSet.ClickElement("ClickResidualIncomeTab");

            //Click to Import
            resdiualIncmeFstDataNrthHelperRevnueShareSet.redirectToPage();

            //Click On Import New button
            resdiualIncmeFstDataNrthHelperRevnueShareSet.ClickElement("ClickOnImportNew");

            //Processor
            resdiualIncmeFstDataNrthHelperRevnueShareSet.Select("ProcessorType", "First Data North");
            resdiualIncmeFstDataNrthHelperRevnueShareSet.WaitForWorkAround(3000);

            //Reporting Period 
            resdiualIncmeFstDataNrthHelperRevnueShareSet.Select("ReportingPeriod", "11");

            resdiualIncmeFstDataNrthHelperRevnueShareSet.Select("SelectYr", "2016");

            //File Date
            clientBugsHelper.ClickElement("ClickOnFileDate");

            //Click on Date
            clientBugsHelper.ClickElement("SelectDate");

            var FileName = "D:\\pegqa\\TestAutomationProject\\PegasusTests\\Files\\FirstDataNorth_ResidualSamples - Small.csv";
            resdiualIncmeFstDataNrthHelperRevnueShareSet.Upload("SelectBrowseCSVFile", FileName);
            resdiualIncmeFstDataNrthHelperRevnueShareSet.WaitForWorkAround(4000);

            //Import
            resdiualIncmeFstDataNrthHelperRevnueShareSet.ClickElement("ClickOnImportBtn");
            resdiualIncmeFstDataNrthHelperRevnueShareSet.WaitForWorkAround(5000);

//##################################  SET FILTER  ##################################

            //Select Filter ReportingPeriod
            resdiualIncmeFstDataNrthHelperRevnueShareSet.Select("SelectFiletReportingPeriod", "November 2016");

            // Select Processor Filer
            resdiualIncmeFstDataNrthHelperRevnueShareSet.Select("SelectProcessorFiler", "First Data North");

            //Select Filter FileFormat
            resdiualIncmeFstDataNrthHelperRevnueShareSet.Select("FilterFileFormat", "First Data North");

            //Select Filter ReportingPeriod
            resdiualIncmeFstDataNrthHelperRevnueShareSet.TypeText("FileName", "FirstDataNorth_ResidualSamples - Small");   

            //Select Status
            resdiualIncmeFstDataNrthHelperRevnueShareSet.Select("SelectStatus", "Imported");

//#############   CALCULATION WIZARD


            //Click On Calculation wizard
            resdiualIncmeFstDataNrthHelperRevnueShareSet.ClickElement("ClickOnCalculation");
            resdiualIncmeFstDataNrthHelperRevnueShareSet.WaitForWorkAround(4000);

            //Click On Step1
            resdiualIncmeFstDataNrthHelperRevnueShareSet.ClickElement("ClickOnSkipRecal1");
            resdiualIncmeFstDataNrthHelperRevnueShareSet.WaitForWorkAround(6000);

            //Click on skip step 2
            resdiualIncmeFstDataNrthHelperRevnueShareSet.ClickElement("ClickSkipStp2Recal");
            resdiualIncmeFstDataNrthHelperRevnueShareSet.WaitForWorkAround(6000);

    

            // Publish Payout
            resdiualIncmeFstDataNrthHelperRevnueShareSet.ClickElement("PublishPayout");
            //     resdiualIncmeFstDataNrthHelper.elementpre();
            resdiualIncmeFstDataNrthHelperRevnueShareSet.WaitForWorkAround(8000);


            //##################################  SET FILTER  ##################################

            //Select Filter ReportingPeriod
            resdiualIncmeFstDataNrthHelperRevnueShareSet.Select("SelectFiletReportingPeriod", "November 2016");

            // Select Processor Filer
            resdiualIncmeFstDataNrthHelperRevnueShareSet.Select("SelectProcessorFiler", "First Data North");

            //Select Filter FileFormat
            resdiualIncmeFstDataNrthHelperRevnueShareSet.Select("FilterFileFormat", "First Data North");

            //Select Filter ReportingPeriod
            resdiualIncmeFstDataNrthHelperRevnueShareSet.TypeText("FileName", "FirstDataNorth_ResidualSamples - Small");

            //Select Status
            resdiualIncmeFstDataNrthHelperRevnueShareSet.Select("SelectStatus", "Published");
            resdiualIncmeFstDataNrthHelperRevnueShareSet.WaitForWorkAround(4000);


        }
    }
}
