namespace Bolt.Core.JsTestResultCollectors
{
    public interface ITestResult
    {
        string TestName { get; set; }

        UnitTestResult Result { get; set; }

        string Message { get; set; }
    }
}