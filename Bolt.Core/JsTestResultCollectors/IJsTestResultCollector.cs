using System.Collections.Generic;
using OpenQA.Selenium;

namespace Bolt.Core.JsTestResultCollectors
{
    public interface IJsTestResultCollector
    {
        IList<ITestResult> GetResults(IWebDriver webDriver);
    }
}