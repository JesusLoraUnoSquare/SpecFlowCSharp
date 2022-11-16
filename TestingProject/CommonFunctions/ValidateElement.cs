using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace TestingProject.CommonFunctions
{
    class ValidateElement
    {
        public static bool ValidateIfElementExists(IWebDriver webDriver, By by)
        {
            bool result = false;

            for (int i = 0; i < 5; i++)
            {
                try
                {
                    webDriver.FindElement(by);
                    result = true;
                    break;
                }
                catch (Exception ex)
                {

                }
                Thread.Sleep(1000);
            }


            return result;

        }
        //public static void ValidateIfElementExists(IWebDriver webDriver,By by)
        //{
        //    DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(webDriver);
        //    fluentWait.Timeout = TimeSpan.FromSeconds(5);
            
        //    fluentWait.PollingInterval = TimeSpan.FromMilliseconds(250);
        //    fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));

        //    IWebElement searchResult = fluentWait.Until(x => x.FindElement(by));

        //}
    }
}
