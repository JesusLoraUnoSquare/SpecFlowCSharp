using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using TestingProject.CommonFunctions;
using TestingProject.Entities;

namespace TestingProject.PageObjects.Results
{
    class Results
    {
        //Driver element
        private IWebDriver driver;
        private EntCommons commons;
        private EntHomePage entHomePage;
        private EntStorePage entStorePage;
        /// <summary>
        /// Initialize the class
        /// </summary>
        /// <param name="driver"></param>
        public Results(IWebDriver driver, EntCommons commons, EntHomePage entHomePage)
        {
            this.driver = driver;
            this.commons = commons;
            this.entHomePage = entHomePage;
            this.entStorePage = new EntStorePage();
        }


        /// <summary>
        /// Validation of items
        /// </summary>
        /// <returns></returns>
        public EntItem ValidateIfItemIsShowed()
        {
            EntItem item = new EntItem();
            try
            {
                Thread.Sleep(2000);
                ValidateElement.ValidateIfElementExists(driver, By.ClassName(entStorePage.ClassListResult));

                // Get products
                IList<IWebElement> allElementsDescription = driver.FindElements(By.CssSelector(entStorePage.ClassListResult));
                //loop through all elements and i get the first
                foreach (IWebElement element in allElementsDescription)
                {
                    item.Description = element.Text;
                    break;
                   
                }

                // Get products
                IList<IWebElement> allElementsPrices = driver.FindElements(By.CssSelector(entStorePage.ClassListResultPrice));
                //loop through all elements and i get the first
                foreach (IWebElement elementPrice in allElementsPrices)
                {
                    item.Price = elementPrice.GetAttribute("innerText");
                    break;

                }

                if(item.Price!="" && item.Description != "")
                {
                    item.Exists = true;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "|" + ex.StackTrace + "|" + ex.InnerException);
            }
            return item;
        }

        public void ClickFirstElement()
        {
            // Get products
            IList<IWebElement> allElements = driver.FindElements(By.CssSelector(entStorePage.ClassLinkToItem));
            //loop through all elements and i get the first
            foreach (IWebElement element in allElements)
            {
                element.Click();
                break;

            }
        }


    }
}
