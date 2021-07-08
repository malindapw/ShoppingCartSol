using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using ShoppingCartProj.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCartProj.Pages
{
    class ProductsPage
    {
        private DriverHelper _driverHelper;

        private static By PRODUCT_HEADER = By.CssSelector("#center_column h1");
        private static By PRODUCT_QUANTITY_SELOCTOR = By.CssSelector("form#buy_block input#quantity_wanted");
        private static By PRODUCT_SIZE_DROPDOWN_SELOCTOR = By.CssSelector("#group_1");
        private static By ADDTOCART_BUTTON_SELOCTOR = By.Id("add_to_cart");

        public ProductsPage(DriverHelper driverHelper) => _driverHelper = driverHelper;

        public void SelectQuantity(string quantity)
        {
            _driverHelper.Driver.FindElement(PRODUCT_QUANTITY_SELOCTOR).Clear();
            _driverHelper.Driver.FindElement(PRODUCT_QUANTITY_SELOCTOR).SendKeys(quantity);
        }

        public void SelectSize(string size)
        {
            SelectElement OptionSelect = new SelectElement(_driverHelper.Driver.FindElement(PRODUCT_SIZE_DROPDOWN_SELOCTOR));
            IList<IWebElement> allElements = OptionSelect.Options;
            foreach (IWebElement element in allElements)
            {
                if (element.Text == size)
                {
                    element.Click();
                }
            }
        }

        public void SelectColor(string color)
        {
            _driverHelper.Driver.FindElement(By.Name(color)).Click();
        }

        public void AddToCart()
        {
            _driverHelper.Driver.FindElement(ADDTOCART_BUTTON_SELOCTOR).Click();
        }

        public string GetHeaderText()
        {
            return _driverHelper.Driver.FindElement(PRODUCT_HEADER).Text;
        }
    }
}
