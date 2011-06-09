using Bolt.Core;
using Bolt.Core.JsTestResultCollectors;
using Bolt.Core.WebServers;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System.Linq;

namespace Bolt.Tests
{
    [TestFixture]
    public class JavascriptUnitTests
    {
        private readonly IWebServer _server = WebServerFactory.Create();
        private readonly IWebDriver _webDriver = new FirefoxDriver();

        [TestFixtureSetUp]
        public void Setup()
        {
            _server.Launch(new WebServerStartInfo() 
                                    { 
                                        LocalPath = @"C:\Code\GitHub\Bolt\Bolt.QunitDemo", 
                                        Port = 12345 
                                    });
        }

        [TestFixtureTearDown]
        public void Teardown()
        {
            _webDriver.Quit();
           _server.Shutdown();
        }

        
        [Test]
        public void Test_Generate_Test0()
        {
            var testPageInfo = new JsTestPageInfo()
            {
                Url = "http://localhost:12345/index.html"
            };

            TestExecutor.Execute(_webDriver, testPageInfo);
            var testResult = testPageInfo.Results.FirstOrDefault();

            // TODO: Aggregate all results
            Assert.NotNull(testResult);
            Assert.IsTrue(testResult.Result == UnitTestResult.Passed, testResult.Message);
        }
        
    }
}