using System;
using System.Collections.Generic;
using System.Linq;
using Bolt.Core.JsTestResultCollectors.Extensions;
using OpenQA.Selenium;

namespace Bolt.Core.JsTestResultCollectors
{
    public class QUnitTestResultCollector : IJsTestResultCollector
    {
        private const string ResultsElement = "qunit-testresult";

        public IList<ITestResult> GetResults(IWebDriver webDriver)
        {
            var testResults = new List<ITestResult>();
            var element = webDriver.GetElementWhenRendered(x => x.FindElement(By.Id(ResultsElement)));

            if (element != null)
            {
                var testOutputs = webDriver.FindElements(By.XPath("//*[contains(@id,'test-output')]"));
                testResults.AddRange(testOutputs.Select(GetTestResultFromTestOutPut));
            }

            return testResults;
        }

        private static ITestResult GetTestResultFromTestOutPut(IWebElement testOutput)
        {
            var testResult = new TestResult();
            var classAttribute = testOutput.GetAttribute("class");
            var moduleName = testOutput.FindElement(By.ClassName("module-name")).Text.Trim();
            var testName = testOutput.FindElement(By.ClassName("test-name")).Text.Trim();
            var testMessages = GetAggregatedQunitAssertMessages(testOutput);

            testResult.Result = classAttribute.Equals("pass") ? UnitTestResult.Passed : UnitTestResult.Failed;
            testResult.Message = testMessages;
            testResult.TestName = string.Format("{0} : {1}", moduleName, testName);

            return testResult;
        }

        private static string GetAggregatedQunitAssertMessages(IWebElement testOutput)
        {
            var assertMessages = from listItem in testOutput.FindElements(By.ClassName("fail"))
                            select listItem.FindElement(By.ClassName("test-message")).Text;
            return string.Join(Environment.NewLine, assertMessages);
        }
    }
}