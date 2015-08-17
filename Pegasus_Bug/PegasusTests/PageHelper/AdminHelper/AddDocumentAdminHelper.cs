using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using PegasusTests.Locators;
using PegasusTests.PageHelper.Comm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PegasusTests.PageHelper
{
    public class AddDocumentAdminHelper : DriverHelper
    {
        public LocatorReader locatorReader;

        public AddDocumentAdminHelper(IWebDriver idriver)
            : base(idriver)
        {
            locatorReader = new LocatorReader("AddDocumentsAdmin.xml");
        }

        

// ###########################  XML  ##############


        //Type into given xml node
        public void TypeText(string Field, string text)
        {
            String locator = locatorReader.ReadLocator(Field);
            WaitForElementPresent(locator, 20);
            SendKeys(locator, text);
        }

        //Verify text of given xml node
        public void VerifyText(string XmlNode, string text)
        {
            String locator = locatorReader.ReadLocator(XmlNode);
            String value = GetText(locator);
            Assert.IsTrue(value.Contains(text));
        }

        //Select by value
        public void Select(string xmlNode, string value)
        {
            String locator = locatorReader.ReadLocator(xmlNode);
            SelectDropDown(locator, value);
        }

        //Click 

        public void ClickElement(string xmlNode)
        {
            String locator = locatorReader.ReadLocator(xmlNode);
            WaitForElementPresent(locator, 20);
            Click(locator);
        }


        //Redirect To URL
        public void RedirectToPage()
        {
            GetWebDriver().Navigate().GoToUrl("https://www.pegasus-test.com/selenium_corp/selenium_office/groups");
        }

        //Redirect To Url
        public void RedirectToAdmin()
        {
            GetWebDriver().Navigate().GoToUrl("https://www.pegasus-test.com/selenium_corp/selenium_office/admin");
        }



        public void Upload(string Field, string Filename)
    {
        String locator = locatorReader.ReadLocator(Field);
        GetWebDriver().FindElement(ByLocator(locator)).SendKeys(Filename);
        WaitForWorkAround(3000);
    
    }



    }
}
