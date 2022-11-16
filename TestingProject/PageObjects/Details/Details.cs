using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using TestingProject.CommonFunctions;
using TestingProject.Entities;

namespace TestingProject.PageObjects.Details
{
    class Details
    {
        //Driver element
        private IWebDriver driver;
        private EntCommons commons;
        private EntHomePage entHomePage;
        private EntDetailsItem entDetailsItem;
        private EntItem entItem;
        /// <summary>
        /// Initialize the class
        /// </summary>
        /// <param name="driver"></param>
        public Details(IWebDriver driver, EntCommons commons, EntHomePage entHomePage,EntItem _entItem)
        {
            this.driver = driver;
            this.commons = commons;
            this.entHomePage = entHomePage;
            entDetailsItem = new EntDetailsItem();
            entItem = _entItem;
        }

        public bool CheckPriceElement()
        {
            bool result = false;
            string priceShowedInDetails = "";
            // Get products
            IList<IWebElement> allElements = driver.FindElements(By.CssSelector(entDetailsItem.ClassPriceItem));
            //loop through all elements and i get the first
            foreach (IWebElement element in allElements)
            {
                priceShowedInDetails = element.GetAttribute("innerText");
        
                break;

            }

            if ((priceShowedInDetails!="" && entItem.Price!="") && (priceShowedInDetails == entItem.Price))
            {
                result = true;
            }

            return result;
        }

        public void AddItemToCart()
        {
            Thread.Sleep(3000);
            ValidateElement.ValidateIfElementExists(driver, By.CssSelector(entDetailsItem.IdButtonAddToCart));
            driver.FindElement(By.CssSelector(entDetailsItem.IdButtonAddToCart)).Click();
            Thread.Sleep(3000);
            ValidateElement.ValidateIfElementExists(driver, By.CssSelector(entDetailsItem.IdNoThanks));
            driver.FindElement(By.CssSelector(entDetailsItem.IdNoThanks)).Click();
            Thread.Sleep(3000);
            ValidateElement.ValidateIfElementExists(driver, By.CssSelector(entDetailsItem.CssSelectorViewCart));
            driver.FindElement(By.CssSelector(entDetailsItem.CssSelectorViewCart)).Click();



        }
    }
}
