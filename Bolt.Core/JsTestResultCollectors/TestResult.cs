namespace Bolt.Core.JsTestResultCollectors
{
    public class TestResult : ITestResult
    {
        public string TestName { get; set; }

        public UnitTestResult Result { get; set; }

        public string Message { get; set; }
    }
}