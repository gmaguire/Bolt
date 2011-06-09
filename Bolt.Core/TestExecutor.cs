using Bolt.Core.JsTestResultCollectors;
using OpenQA.Selenium;

namespace Bolt.Core
{
    public static class TestExecutor
    {
        public static void Execute(IWebDriver webDriver, JsTestPageInfo testPageInfo)
        {
            webDriver.Navigate().GoToUrl(testPageInfo.Url);

            var resultCollector = ResultCollectorFactory.Create();
            testPageInfo.Results = resultCollector.GetResults(webDriver);
        }
    }
}
