namespace Bolt.Core.JsTestResultCollectors
{
    public static class ResultCollectorFactory
    {
        public static IJsTestResultCollector Create()
        {
            // TODO: Return the appropriate collector
            return new QUnitTestResultCollector();
        }
    }
}
