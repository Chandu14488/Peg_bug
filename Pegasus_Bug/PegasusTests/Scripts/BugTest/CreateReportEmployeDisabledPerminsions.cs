using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PegasusTests.PageHelper;
using PegasusTests.PageHelper.Comm;

namespace PegasusTests.Scripts.ClientsTests
{
    [TestClass]
    public class CreateReportEmployeDisabledPerminsions : DriverTestCase
    {
        [TestMethod]
        public void createReportEmployeDisabledPerminsions()
        {
            string[] username = null;
            string[] password = null;

            var oXMLData = new XMLParse();
            oXMLData.LoadXML("../../Config/ApplicationSettings.xml");

            username = oXMLData.getData("settings/Credentials", "username5");
            password = oXMLData.getData("settings/Credentials", "password5");

            //Initializing the objects
            var loginHelper = new LoginHelper(GetWebDriver());
            var clientHelper = new ClientsHelper(GetWebDriver());
            var createReportHelper = new CreateReportHelper(GetWebDriver());

            //Variable

            var mail = "Test" + RandomNumber(1, 99) + "@yopmail.com";
            var numb = "12345678" + RandomNumber(10, 99);


            //Login with valid username and password
            Login(username[0], password[0]);
            Console.WriteLine("Logged in as: " + username[0] + " / " + password[0]);

            //Verify Page title
            VerifyTitle("Dashboard");
            Console.WriteLine("Redirected at Dashboard screen.");

            //Click on Clients in Topmenu
            createReportHelper.ClickElement("ClickReportTab");


//################################# CREATE A CONTACT   #############################################

            //Click On Create
            createReportHelper.ClickElement("ClickOnCreate");

// #################### CREATE REPORT    ############################

            //Report name
            String report = "Test Report" + RandomNumber(9,666);
            createReportHelper.TypeText("Name", report);

            //Select Module
            createReportHelper.Select("SelectModule", "20");

            //Enter Description 
            createReportHelper.TypeText("EnterDEscription", "THIS IS TESTING DESCRIPTION");

            //Click on ClientWithDocument
            createReportHelper.ClickElement("ClientWithDocument");

            //Click On Total Email With Client
            createReportHelper.ClickElement("TotalEmailWithClient");

            //Click On Total Task WithClient
            createReportHelper.ClickElement("TotalTaskWithClient");

            //Click On Total Client With Email
            createReportHelper.ClickElement("TotalClientWithEmail");

            //Click On Total Client With Task
            createReportHelper.ClickElement("TotalClientWithTask");

            //Click On Total Meeting With Clients
            createReportHelper.ClickElement("TotalMeetingWithClients");

            //Click On Total Clients With Meeting
            createReportHelper.ClickElement("TotalClientsWithMeeting");

            //Click On Total Document With Client
            createReportHelper.ClickElement("TotalDocumentWithClient");

//################ Appointment Status Tool

            // Click ON AppointmentRadiobtn
            createReportHelper.ClickElement("ClickONAppointmentRadiobtn");

            //Click On MeetingcChkBox
            createReportHelper.ClickElement("ClickOnMeetingcChkBox");
            createReportHelper.WaitForWorkAround(3000);

            //Click On Task
            createReportHelper.ClickElement("ClickOnTask");

//###################################  AVERAGE TIME TAKEM   ##################################

            //Click on Average Time Taken tab
            createReportHelper.ClickElement("ClickOnAvgtimetakn");

            //Select From
            createReportHelper.Select("SelectFrom", "Converted New");

            //Select To 
            createReportHelper.Select("SelectTo", "Converted New");

//##############################  COVERTED CLIENT   #################################

            //Click On Converted Client
            createReportHelper.ClickElement("ClickOnConvertedClient");

            //Click On Lead Convertion Ratio To Client
            createReportHelper.ClickElement("LeadConvertionRatioToClient");

            //Click On Opportunities Converstion RatioTioClient
            createReportHelper.ClickElement("OpportunitiesConverstionRatioTioClient");

            //Click Total Coverted Opportinuties
            createReportHelper.ClickElement("TotalCovertedOpportinuties");


//#################### FILTER SELECT TIME PERIOD

            //SelectTimePeriod
            createReportHelper.Select("SelectTimePeriod", "Yesterday");

            //Status
            createReportHelper.ClickElement("Status");

            //Click Status
            createReportHelper.ClickElement("SelectStatus");

            //Source
            createReportHelper.ClickElement("Source");

            //Click SelectSource
            createReportHelper.ClickElement("SelectSource");

            //Responsibilities
            //    createReportHelper.ClickElement("Responsibilities");

            //Click SelectResponsibilites
            //     createReportHelper.ClickElement("SelectResponsibilites");

            //PartnerAgent
            createReportHelper.ClickElement("PartnerAgent");

            //Click Status
            createReportHelper.ClickElement("SelectPartnerAgent");

            //PartnerAssociation
            createReportHelper.ClickElement("PartnerAssociation");

            //Click SelectPartnerAssociation
            createReportHelper.ClickElement("SelectPartnerAssociation");

            //SalesManager
            createReportHelper.ClickElement("SalesManager");

            //Click SelectSaleManager
            createReportHelper.ClickElement("SelectSaleManager");


            //Click On Time Period checkbox
            createReportHelper.ClickElement("TimePeriod");

            //Select Time Period
            //     createReportHelper.Select("SelectTimePerioddd", "week");

            //Click on Custom Check box
            createReportHelper.ClickElement("SelectCustomField");

            //Select Custom field
            //    createReportHelper.Select("SelectCustomFielddd", "");

//#############  PERMISSIONS

            //Click 
            createReportHelper.ClickElement("TeamUp");

            //Click 
            createReportHelper.ClickElement("TeamUpWrite");

            //Click 
            createReportHelper.ClickElement("TeamUpDel");

            //Click 
            createReportHelper.ClickElement("TeamDownWrite");

            //Click 
            createReportHelper.ClickElement("TeamDown");

            //Click 
            createReportHelper.ClickElement("TeamDownWrite");

            //Click 
            createReportHelper.ClickElement("TeamOther");

            //Click 
            createReportHelper.ClickElement("TeamOtherWrite");

            //Click 
            createReportHelper.ClickElement("GroupRead");

            //Click 
            createReportHelper.ClickElement("GroupWrite");

            //Click 
            createReportHelper.ClickElement("OtherRead");

            //Click 
            createReportHelper.ClickElement("OtherWrite");

            //CLICK Do Save
            createReportHelper.ClickElement("SaveReports");
            createReportHelper.WaitForWorkAround(3000);
        }
    }
}
