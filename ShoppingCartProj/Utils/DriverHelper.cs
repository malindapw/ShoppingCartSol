using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace ShoppingCartProj.Utils
{
    public class DriverHelper
    {
        public IWebDriver Driver { get; set; }
    }
}
