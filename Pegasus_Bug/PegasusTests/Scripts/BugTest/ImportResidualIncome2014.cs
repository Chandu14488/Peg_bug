using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PegasusTests.PageHelper;
using PegasusTests.PageHelper.Comm;

namespace PegasusTests.Scripts.ClientsTests
{
    [TestClass]
    public class ImportResidualIncome2014 : DriverTestCase
    {
        [TestMethod]
        public void importResidualIncome2014()
        {
       

            var oXMLData = new XMLParse();
            oXMLData.LoadXML("../../Config/ApplicationSettings.xml");

            //Initializing the objects
            var loginHelper = new LoginHelper(GetWebDriver());
            var clientHelper = new ClientsHelper(GetWebDriver());
            var importAndCalculationRIHelper = new ImportAndCalculationRIHelper(GetWebDriver());
            var loginAsCorpHelper = new LoginAsCorpHelper(GetWebDriver());


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
            importAndCalculationRIHelper.ClickElement("ClickResidualIncomeTab");

            //Click to Import
            importAndCalculationRIHelper.redirectToPage();

            //Click On Import New button
            importAndCalculationRIHelper.ClickElement("ClickOnImportNew");

            //Processor
            importAndCalculationRIHelper.Select("ProcessorType", "First Data North");
            importAndCalculationRIHelper.WaitForWorkAround(3000);

            //Reporting Period 
            importAndCalculationRIHelper.Select("ReportingPeriod", "11");

            //Reporting Year
            importAndCalculationRIHelper.Select("ReportingYear", "2014");

            //File Date
            importAndCalculationRIHelper.ClickElement("FileDate");
            importAndCalculationRIHelper.ClickElement("ClickOnDate");

            
            var FileName = GetPathToFile()+"FirstDataNorth_ResidualSamples - Small.csv";
            importAndCalculationRIHelper.Upload("SelectBrowseCSVFile", FileName);
            importAndCalculationRIHelper.WaitForWorkAround(4000);

            //Import
            importAndCalculationRIHelper.ClickElement("ClickOnImportBtn");
            importAndCalculationRIHelper.WaitForWorkAround(5000);

//##################################  SET FILTER  ##################################

            //Select Filter ReportingPeriod
            importAndCalculationRIHelper.Select("SelectFiletReportingPeriod", "November 2015");

            // Select Processor Filer
            importAndCalculationRIHelper.Select("SelectProcessorFiler", "First Data North");

            //Select Filter FileFormat
            importAndCalculationRIHelper.Select("FilterFileFormat", "First Data North");

            //Select Filter ReportingPeriod
            importAndCalculationRIHelper.TypeText("FileName", "FDN_Samples");

            //Select Status
            importAndCalculationRIHelper.Select("SelectStatus", "Imported");
                                                               
        }
    }
}
