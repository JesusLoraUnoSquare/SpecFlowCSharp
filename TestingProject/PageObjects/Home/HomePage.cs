using OpenQA.Selenium;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using TestingProject.Abstracts;
using TestingProject.CommonFunctions;
using TestingProject.Entities;
using TestingProject.Interfaces;

namespace TestingProject.PageObjects
{
    class HomePage: WebPage,INavigationPage
    {
        //Driver element
        private IWebDriver driver;
        private EntCommons commons;
        private EntHomePage entHomePage;
        /// <summary>
        /// Initialize the class
        /// </summary>
        /// <param name="driver"></param>
        public HomePage(IWebDriver driver, EntCommons commons, EntHomePage entHomePage)
        {
            this.driver = driver;
            this.commons = commons;
            this.entHomePage = entHomePage;
        }

        public override void CloseWindow()
        {
            Thread.Sleep(5000);
            driver.Close();
            driver.Quit();
        }

        /// <summary>
        /// Go to page home
        /// </summary>
        public void goToPage()
        {
            ReadJson jsonData = new ReadJson();
            EntCommons entCommons = jsonData.ReadJsonFile();

            //I get the employee's information
            RestCore restCore = new RestCore();
            RestRequest restRequest = restCore.CreateRequestWithHeaders("GET", "https://dummy.restapiexample.com/api/v1/employees");
            restRequest = restCore.CreateRequestBody(restRequest, "");
            EntEmployees entEmployees = restCore.ExecuteRequest(restRequest);


            driver.Navigate().GoToUrl(entCommons.url);
            driver.Manage().Window.Maximize();
        }

        /// <summary>
        /// Search an item usign the searchbar
        /// </summary>
        /// <param name="itemToSearch"></param>
        public void searchItem(string itemToSearch)
        {
            Thread.Sleep(3000);
            ValidateElement.ValidateIfElementExists(driver, By.Id(entHomePage.IdSearchBox));
            driver.FindElement(By.Id(entHomePage.IdSearchBox)).Clear();
            driver.FindElement(By.Id(entHomePage.IdSearchBox)).SendKeys(itemToSearch);
            driver.FindElement(By.Id(entHomePage.IdSearchBox)).SendKeys(Keys.Enter);
        }

    }
}
