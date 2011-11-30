using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Bolt.Core.JsTestResultCollectors.Extensions
{
    public static class WebDriverExtensions
    {
        public static IWebElement GetElementWhenRendered(this IWebDriver driver, Func<IWebDriver, IWebElement> matchingFunction, long timeOutMax = 10000)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(timeOutMax));
            return wait.Until(matchingFunction);
        }
    }
}
