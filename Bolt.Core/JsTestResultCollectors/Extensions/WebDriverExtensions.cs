using System;
using OpenQA.Selenium;

namespace Bolt.Core.JsTestResultCollectors.Extensions
{
    public static class WebDriverExtensions
    {
        public static IWebElement GetElementWhenRendered(this IWebDriver driver, Func<IWebDriver, IWebElement> matchingFunction, int timeout = 0, int timeOutMax = 10000)
        {
            while (timeout < timeOutMax)
            {
                try
                {
                    var element = matchingFunction(driver);
                    if (element != null) return element;
                }
                catch (NoSuchElementException)
                {
                    //do nothing
                }

                System.Threading.Thread.Sleep(250);

                timeout += 250;
            }

            return null;
        }
    }
}
