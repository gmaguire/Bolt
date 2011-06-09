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
            // Todo: Make better :)

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
            var moduleName = testOutput.FindElement(By.ClassName("module-name")).Text;
            var testName = testOutput.FindElement(By.ClassName("test-name")).Text;

            testResult.Result = classAttribute.Equals("pass") ? UnitTestResult.Passed : UnitTestResult.Failed;

            testResult.TestName = string.Format("{0} : {1}", moduleName, testName);

            return testResult;
        }
    }
}