using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;
using TechTalk.SpecFlow;
using TestingProject.Entities;
using TestingProject.PageObjects;
using TestingProject.PageObjects.Cart;
using TestingProject.PageObjects.Details;
using TestingProject.PageObjects.Results;

namespace TestingProject.Steps
{
    [Binding]
    public class ShoppingCartSteps
    {
        EntCommons entCommons = new EntCommons();
        EntHomePage entHomePage = new EntHomePage();
        EntItem item = new EntItem();

        private IWebDriver driver;

        [Given(@"I open the web page")]
        public void GivenIOpenTheWebPage()
        {
            driver =  new ChromeDriver();
            driver.Manage().Window.Maximize();
        }

        [When(@"I go to Amazon\.com")]
        public void WhenIGoToAmazon_Com()
        {
            try
            {
                //Go to home page
                HomePage homePage = new HomePage(driver, entCommons, entHomePage);
                homePage.goToPage();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "|" + ex.StackTrace + "|" + ex.InnerException);
            }
        }


        [When(@"Search for (.*)")]
        public void WhenSearchForIphone(string dataToSearch)
        {
            try
            {
                //Go to home page
                HomePage homePage = new HomePage(driver, entCommons, entHomePage);
                //Search the item
                homePage.searchItem(dataToSearch);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "|" + ex.StackTrace + "|" + ex.InnerException);
            }
        }
        
       
        [Then(@"Verify Item is displayed on the screen and  locate the first one and store the price")]
        public void ThenVerifyItemIsDisplayedOnTheScreenAndLocateTheFirstOne()
        {
            Results results = new Results(driver, entCommons, entHomePage);
            item = results.ValidateIfItemIsShowed();
            Assert.AreEqual(true, item.Exists);
        }
        
        
        [Then(@"Click on the First Result")]
        public void ThenClickOnTheFirstResult()
        {
            Results results = new Results(driver, entCommons, entHomePage);
           results.ClickFirstElement();
        }
        
        [Then(@"Once in the details page compare this price vs the above one \(first stored price\)")]
        public void ThenOnceInTheDetailsPageCompareThisPriceVsTheAboveOneFirstStoredPrice()
        {
            Details entDetailsItem = new Details(driver, entCommons, entHomePage, item);
            bool result= entDetailsItem.CheckPriceElement();
            Assert.AreEqual(true, result);


        }
        
        [Then(@"Click on Add to Cart\.")]
        public void ThenClickOnAddToCart_()
        {
            Details entDetailsItem = new Details(driver, entCommons, entHomePage, item);
            entDetailsItem.AddItemToCart();
        }

        [When(@"Go to Cart and verify again the price of the phone")]
        public void WhenGoToCartAndVerifyAgainThePriceOfThePhone()
        {
            Cart entCart = new Cart(driver, entCommons, entHomePage, item);
            bool result = entCart.ValidatePriceCart();
            Assert.AreEqual(true, result);
        }

        [Then(@"Delete Item")]
        public void ThenDeleteItem()
        {
            Cart entCart = new Cart(driver, entCommons, entHomePage, item);
            entCart.DeleteItemFromCart();
        }

        [Then(@"I close the web navigator")]
        public void ThenICloseTheWebNavigator()
        {
            //Go to home page
            HomePage homePage = new HomePage(driver, entCommons, entHomePage);
            //Search the item
            homePage.CloseWindow();
        }

    }
}
