using System.Collections.Generic;
using Bolt.Core.JsTestResultCollectors;

namespace Bolt.Core
{
    public class JsTestPageInfo
    {
        public string Url { get; set; }

        public IList<ITestResult> Results { get; set; }
    }
}
