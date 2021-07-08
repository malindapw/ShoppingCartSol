using Gherkin.Ast;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using ShoppingCartProj.Utils;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace ShoppingCartProj.Hooks
{
    [Binding]
    class WebDriverHook
    {
        private DriverHelper _driverHelper;

        public WebDriverHook(DriverHelper driverHelper)
        {
            _driverHelper = driverHelper;
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            var browserType = TestContext.Parameters["browser"];
            var webAppUrl = TestContext.Parameters["webAppUrl"];
            _driverHelper.Driver = new WebDriverFactory().GetWebDriver(browserType);
            _driverHelper.Driver.Navigate().GoToUrl(webAppUrl);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            _driverHelper.Driver.Close();
            _driverHelper.Driver.Dispose();
        }
    }
}
