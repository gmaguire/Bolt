using System;
using OpenQA.Selenium;

namespace Bolt.Core.JsTestResultCollectors.Extensions
{
    public static class WebDriverExtensions
    {
        private const int Interval = 100;

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
                    // do nothing
                }

                System.Threading.Thread.Sleep(Interval);

                timeout += Interval;
            }

            return null;
        }
    }
}
