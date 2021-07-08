using OpenQA.Selenium;
using ShoppingCartProj.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCartProj.Pages
{
    class HomePage
    {
        private DriverHelper _driverHelper;

        private static By BEST_SELLERS_TAB_SELECTOR = By.CssSelector("#center_column h1");
        private static By TAB_CONTENT_SELECTOR = By.CssSelector(".tab-content");

        public HomePage(DriverHelper driverHelper) => _driverHelper = driverHelper;

        public void SelectBestSellerTab()
        {
            _driverHelper.Driver.FindElement(BEST_SELLERS_TAB_SELECTOR).Click();
        }

        public void SelectProduct(string itemName)
        {
            _driverHelper.Driver.FindElement(By.LinkText(itemName)).Click();
        }

    }
}
