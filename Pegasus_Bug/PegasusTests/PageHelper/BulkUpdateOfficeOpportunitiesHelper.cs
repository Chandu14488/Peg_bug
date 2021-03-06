﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using PegasusTests.Locators;
using PegasusTests.PageHelper.Comm;

namespace PegasusTests.PageHelper
{
    public class BulkUpdateOfficeOpportunitiesHelper : DriverHelper
    {
        public LocatorReader locatorReader;

        public BulkUpdateOfficeOpportunitiesHelper(IWebDriver idriver)
            : base(idriver)
        {
            locatorReader = new LocatorReader("BulkUpdateOpportunitiesOffice.xml");
        }

        //Click to given xml node
        public void ClickElement(string XmlNode)
        {
            var locator = locatorReader.ReadLocator(XmlNode);
            Click(locator);
        }

        //Type into given xml node
        public void TypeText(string XmlNode, string text)
        {
            var locator = locatorReader.ReadLocator(XmlNode);
            WaitForElementPresent(locator, 20);
            SendKeys(locator, text);
        }

        //Verify text of given xml node
        public void VerifyText(string XmlNode, string text)
        {
            var locator = locatorReader.ReadLocator(XmlNode);
            var value = GetText(locator);
            Assert.IsTrue(value.Contains(text));
        }

        //Select by value
        public void Select(string xmlNode, string value)
        {
            var locator = locatorReader.ReadLocator(xmlNode);
            SelectDropDown(locator, value);
        }

        internal void Upload(string Field, string FileName)
        {
            var locator = locatorReader.ReadLocator(Field);
            Console.WriteLine(FileName);
            GetWebDriver().FindElement(ByLocator(locator)).SendKeys(FileName);
            WaitForWorkAround(3000);
        }


        public void drawSign()
        {
            GetWebDriver().FindElement(By.XPath("//*[@id='signatureDiv']/div[1]/div[4]/canvas")).Click();
            //  GetWebDriver().FindElement(ByLocator("//*[@id='signatureDiv']/div[1]/div[4]/canvas")).Click();
        }

        //Click Dublicate
        public void ClickOnDublicate()
        {
            var locator = "//*[@id='LeadCreateForm']/div[2]/div[3]/a[1]/span[1]";
            var dublicate = "//*[@id='message']/div[4]/div/a[1]/span[1]";
            Click(locator);
            WaitForWorkAround(3000);

            if (IsElementPresent(dublicate))
            {

                Click(dublicate);
                WaitForWorkAround(3000);

            }
        }


        //Click Dublicate
        public void ClickDublicateOpp()
        {
            var LocSave = "//span[text()='Save']";
            var LocDubSave = "//span[text()='Create Duplicate']";
            Click(LocSave);
            WaitForWorkAround(3000);

            if (IsElementPresent(LocDubSave))
            {
                Click(LocDubSave);
                WaitForWorkAround(2000);
            }
        
        
        }

        //Switch frame 
        public void frame(string text)
        {
          //  var  locator = "";
            GetWebDriver().SwitchTo().Frame(0);
            GetWebDriver().FindElement(ByLocator("//body")).SendKeys(text);
        
        }



        }
    }
