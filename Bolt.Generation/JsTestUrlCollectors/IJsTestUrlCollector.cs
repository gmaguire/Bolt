using System.Collections.Generic;

namespace Bolt.Generation.JsTestUrlCollectors
{
    public interface IJsTestUrlCollector
    {
        IList<string> GetUrls();
    }
}
