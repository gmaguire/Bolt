using System.Collections.Generic;

namespace Bolt.Generation.JsTestUrlCollectors
{
    public class DummyUrlCollector : IJsTestUrlCollector
    {
        public IList<string> GetUrls()
        {
            return  new List<string>() { "index.html" };
        }
    }
}
