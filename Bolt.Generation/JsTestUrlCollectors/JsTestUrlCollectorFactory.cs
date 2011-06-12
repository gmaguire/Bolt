namespace Bolt.Generation.JsTestUrlCollectors
{
    public static class JsTestUrlCollectorFactory
    {
        public static IJsTestUrlCollector Create()
        {
            // TODO : Return the approrpriate test url collector
            return new TextFileUrlCollector();
        }
    }
}
