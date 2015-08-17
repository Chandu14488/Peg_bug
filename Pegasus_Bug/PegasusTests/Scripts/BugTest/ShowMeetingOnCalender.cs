using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PegasusTests.PageHelper;
using PegasusTests.PageHelper.Comm;

namespace PegasusTests.Scripts.ClientsTests
{
    [TestClass]
    public class ShowMeetingOnCalender : DriverTestCase
    {
        [TestMethod]
        public void showMeetingOnCalender()
        {
            string[] username = null;
            string[] password = null;

            var oXMLData = new XMLParse();
            oXMLData.LoadXML("../../Config/ApplicationSettings.xml");

            username = oXMLData.getData("settings/Credentials", "username");
            password = oXMLData.getData("settings/Credentials", "password");

            //Initializing the objects
            var loginHelper = new LoginHelper(GetWebDriver());
            var bulkUpdateOffice = new BulkUpdateOffice(GetWebDriver());
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

/*            //Click on Clients in Topmenu
            clientBugsHelper.ClickElement("ClickleadTab");

           //Click On Create
            clientBugsHelper.ClickElement("ClickOnCreate");

            //Enter First Name
            bulkUpdateOffice.TypeText("LeadFirstName", "Lead");

            //Enter Last Name
            bulkUpdateOffice.TypeText("LastName", "Meeting");

            //Enter Lead Company
            bulkUpdateOffice.TypeText("LeadCompanyNmae", "Lead Meeting");


            //LeadPhnNumber
            bulkUpdateOffice.TypeText("LeadPhnNumber", "6757656756");

            //LeadEmail
            bulkUpdateOffice.TypeText("LeadEmail", "Test123@yopmail.com");


            //Click on ClickOnDublicate
            bulkUpdateOffice.ClickOnDublicate();
            bulkUpdateOffice.WaitForWorkAround(3000);            */                

            //Click on Clients in Topmenu
            clientBugsHelper.ClickElement("ClickleadTab");
            bulkUpdateOffice.WaitForWorkAround(3000);                               


            //SrchLeadCompany
            bulkUpdateOffice.TypeText("SrchLeadCompany", "Lead Meeting");

            //Serch Email Leda
            bulkUpdateOffice.TypeText("SrchEmail", "Test123@yopmail.com");
            clientBugsHelper.WaitForWorkAround(3000);

            //Click On Opp Check Box
            bulkUpdateOffice.ClickElement("ClickOnLead");

            //Click on Email
            bulkUpdateOffice.ClickElement("ClickOnAddMeeting");

            //Enter Document Name
            bulkUpdateOffice.TypeText("EnterSubjectMeeting", "Test Meeting");

            //Click On Start Date
            bulkUpdateOffice.ClickElement("ClickOnStartDate");

            //Click On Start Date
            bulkUpdateOffice.ClickElement("SelectDate");


            //Click On Start Date
       //     bulkUpdateOffice.ClickElement("ClickOnEndDate");
            bulkUpdateOffice.WaitForWorkAround(2000);

            //Click On Start Date
      //      bulkUpdateOffice.ClickElement("SeletEndDate");

            //Enter Document Description
            bulkUpdateOffice.frame("Description");

            //Swtich Top Default
            GetWebDriver().SwitchTo().DefaultContent();

            //Upload file
            bulkUpdateOffice.UploadFile("//*[@id='DocumentFile']", "D:\\pegqa\\TestAutomationProject\\PegasusTests\\Files\\1.pdf");
            bulkUpdateOffice.WaitForWorkAround(3000);

            //Click on Send Email button
            bulkUpdateOffice.ClickElement("ClickOnSaveMeeting");
            bulkUpdateOffice.WaitForWorkAround(3000);
            bulkUpdateOffice.VerifyPageText("Meeting saved successfully.");
            bulkUpdateOffice.WaitForWorkAround(3000);


            //Click on Calender meeting
            bulkUpdateOffice.ClickElement("ClickOnCalender");
            bulkUpdateOffice.WaitForWorkAround(3000);
            bulkUpdateOffice.VerifyPageText("Related To");
            bulkUpdateOffice.VerifyPageText("Description");
            bulkUpdateOffice.WaitForWorkAround(2000);

           
        }
    }
}
