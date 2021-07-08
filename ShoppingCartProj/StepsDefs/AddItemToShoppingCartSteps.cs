using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using ShoppingCartProj.Model;
using ShoppingCartProj.Pages;
using ShoppingCartProj.Utils;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace ShoppingCartProj.StepsDefs
{
    [Binding]
    class AddItemToShoppingCartSteps
    {
        private DriverHelper _driverHelper;
        private HomePage _homePage;
        private ProductsPage _productsPage;
        private ScenarioContext _scenarioContext;

        public AddItemToShoppingCartSteps(DriverHelper driverHelper)
        {
            _driverHelper = driverHelper;
            _homePage = new HomePage(_driverHelper);
            _productsPage = new ProductsPage(_driverHelper);
        }

        [When(@"I select ""(.*)"" list")]
        public void WhenISelectList(string tabs)
        {

            //wait unitl page loads 
            var wait = new WebDriverWait(_driverHelper.Driver, new TimeSpan(0, 0, 10));
            wait.Until(c => c.FindElement(By.Id("center_column")));

            // select an item from Best Sellers List
            //_driver.FindElement(By.CssSelector("a.blockbestsellers")).Click();
            _homePage.SelectBestSellerTab();
            wait.Until(c => c.FindElement(By.Id("blockbestsellers")));
        }

        [When(@"I select ""(.*)"" from the list")]
        public void WhenISelectFromTheList(string productName)
        {
            //slect the item to open the item details 
            var wait = new WebDriverWait(_driverHelper.Driver, new TimeSpan(0, 0, 10));
            _homePage.SelectProduct(productName);
            wait.Until(c => c.FindElement(By.Id("center_column")));
            
        }

        [Then(@"the details of the item ""(.*)"" is displayed")]
        public void ThenTheDetailsOfTheItemIsDisplayed(string productName)
        {
            Assert.AreEqual(productName, _productsPage.GetHeaderText());
        }

        [When(@"I add the item with following details")]
        public void WhenIAddTheItemWithFollowingDetails(Table table)
        {

            var tableData = table.CreateInstance<Product>();

            _productsPage.SelectQuantity(tableData.Quantity);

            _productsPage.SelectSize(tableData.Size);

            _productsPage.SelectColor(tableData.Color);

            _productsPage.AddToCart();
            
        }
            

        [Then(@"item ""(.*)"" is added to the cart")]
        public void ThenItemIsAddedToTheCart(string p0)
        {
            var wait = new WebDriverWait(_driverHelper.Driver, new TimeSpan(0, 0, 10));
            wait.Until(c => c.FindElement(By.Id("layer_cart")));
            Assert.AreEqual("There are 2 items in your cart.", _driverHelper.Driver.FindElement(By.CssSelector("[class='layer_cart_cart col-xs-12 col-md-6'] h2")).Text);
        }

    }
}
