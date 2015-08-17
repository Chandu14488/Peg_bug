using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PegasusTests.PageHelper;
using PegasusTests.PageHelper.Comm;

namespace PegasusTests.Scripts.ClientsTests
{
    [TestClass]
    public class EditTask : DriverTestCase
    {
        [TestMethod]
        public void editTask()
        {
            string[] username = null;
            string[] password = null;

            var oXMLData = new XMLParse();
            oXMLData.LoadXML("../../Config/ApplicationSettings.xml");

            username = oXMLData.getData("settings/Credentials", "username");
            password = oXMLData.getData("settings/Credentials", "password");

            //Initializing the objects
            var loginHelper = new LoginHelper(GetWebDriver());
            var clientBugsHelper = new ClientBugsHelper(GetWebDriver());

            //Login with valid username and password
            Login(username[0], password[0]);
            Console.WriteLine("Logged in as: " + username[0] + " / " + password[0]);

            //Verify Page title
            VerifyTitle("Dashboard");
            Console.WriteLine("Redirected at Dashboard screen.");
       
            //Redirect To Url
            GetWebDriver().Navigate().GoToUrl("https://www.pegasus-test.com/selcorp/seloffice/tasks/create");
            clientBugsHelper.WaitForWorkAround(4000);


            //Enter Subject
            clientBugsHelper.TypeText("Subject", "This is Task");

            //Task Start Date
            clientBugsHelper.TypeText("TaskStartDate", "2015-07-02");

            //Task End Date
            clientBugsHelper.TypeText("TaskDueDate", "2015-09-08");

            //Click on Save
            clientBugsHelper.ClickElement("ClickSaveBtn");
            clientBugsHelper.WaitForWorkAround(5000);

            //Redirect To Url
            GetWebDriver().Navigate().GoToUrl("https://www.pegasus-test.com/selcorp/seloffice/tasks");
            clientBugsHelper.WaitForWorkAround(4000);

            //Search Task
            clientBugsHelper.TypeText("TaskSearch", "This is Task");
            Thread.Sleep(3000);

            //Click on Task To Edit
            clientBugsHelper.ClickElement("ClickOnTaskEdit");

            //Click on Edit Buttomn
            clientBugsHelper.ClickElement("ClickEditBtn");

            //Enter Subject
            clientBugsHelper.TypeText("Subject", "Edit Task");

            //Task Start Date
   //         clientBugsHelper.TypeText("TaskStartDate", "2015-08-02");

            //Task End Date
//            clientBugsHelper.TypeText("TaskDueDate", "2015-11-08");

            //Click On Save
            clientBugsHelper.Click("//button[@title='Save']");
            clientBugsHelper.WaitForWorkAround(4000);
            clientBugsHelper.VerifyPageText("Task Updated Success.");



        }
    }
}
