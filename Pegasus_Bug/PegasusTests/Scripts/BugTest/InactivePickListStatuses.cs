﻿using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PegasusTests.PageHelper;
using PegasusTests.PageHelper.Comm;

namespace PegasusTests.Scripts.ClientsTests
{
    [TestClass]
    public class InactivePickListStatuses : DriverTestCase
    {
        [TestMethod]
        public void inactivePickListStatuses()
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

           //Redirect To URL
            GetWebDriver().Navigate().GoToUrl("https://www.pegasus-test.com/selenium_corp/selenium_office/admin");

            //Click on System Tab
     //       clientBugsHelper.ClickElement("ClickOnSystemTab");

            //Redirect To PickList
            GetWebDriver().Navigate().GoToUrl("https://www.pegasus-test.com/selenium_corp/selenium_office/pick-lists");

            //Enter Name To Seacrch
            clientBugsHelper.TypeText("EnterNamePicklist", "Statuses");

            //Enter Name To Seacrch
            clientBugsHelper.TypeText("EnterModule", "Clients");
            clientBugsHelper.WaitForWorkAround(4000);

            //Click On Statuses
            clientBugsHelper.ClickElement("ClickOnStatuses");
            clientBugsHelper.WaitForElementPresent("ClickOnAddBtn",20);

            //Clcik on Add button
            clientBugsHelper.ClickElement("ClickOnAddBtn");

            //Enter PickList Value
            var name = "Test" + RandomNumber(99, 99000);
            clientBugsHelper.TypeText("EnterPickListValue", name);

            //Click PickList Save Button
            clientBugsHelper.ClickElement("PickListSaveBtn");
            clientBugsHelper.WaitForWorkAround(3000);

            //Refresh
            GetWebDriver().Navigate().Refresh();
            clientBugsHelper.WaitForWorkAround(3000);

            //Click on Inactive button
            clientBugsHelper.PicInactive(name);
            clientBugsHelper.WaitForWorkAround(3000);


            //Replace Picklist
            clientBugsHelper.SelectDropDownByText("//*[@id='PickListValueReplaceItem']", "Declined");
            clientBugsHelper.WaitForWorkAround(3000);

            //PicklistSaveBtnReplace
            clientBugsHelper.ClickElement("PicklistSaveBtnReplace");
         

            //ACcep Alert
            clientBugsHelper.AcceptAlert();
            clientBugsHelper.WaitForWorkAround(3000);

            //Ver
        //    clientBugsHelper.VerifyStatusInactve(name);
        //    clientBugsHelper.WaitForWorkAround(3000);

            //Verify The picklist value is added successfully
            //clientBugsHelper.VerifyPageText("The picklist value is added successfully");
            clientBugsHelper.WaitForWorkAround(3000);


        }
    }
}
