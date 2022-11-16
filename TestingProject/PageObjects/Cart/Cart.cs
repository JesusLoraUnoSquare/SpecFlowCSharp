using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using TestingProject.Entities;

namespace TestingProject.PageObjects.Cart
{
    class Cart
    {  
        //Driver element
        private IWebDriver driver;
        private EntCommons commons;
        private EntHomePage entHomePage;
        private EntDetailsItem entDetailsItem;
        private EntCart entCart;
        EntItem entItem;
        /// <summary>
        /// Initialize the class
        /// </summary>
        /// <param name="driver"></param>
        public Cart(IWebDriver driver, EntCommons commons, EntHomePage entHomePage, EntItem _entItem)
        {
            this.driver = driver;
            this.commons = commons;
            this.entHomePage = entHomePage;
            entItem=_entItem;
            entDetailsItem = new EntDetailsItem();
            entCart = new EntCart();
        }

        public bool ValidatePriceCart()
        {
            bool result = false;
            // Get price
            string priceShowedInCart = driver.FindElement(By.CssSelector(entCart.Selectorprice)).GetAttribute("innerText");
            
            if ((priceShowedInCart != "" && entItem.Price != "") && (priceShowedInCart == entItem.Price))
            {
                result = true;
            }

            return result;
        }

        public void DeleteItemFromCart()
        {
            driver.FindElement(By.CssSelector(entCart.SelectorDeleteItem)).Click();

            
        }
    }
}
