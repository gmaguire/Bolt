using System;
using System.Collections.Generic;
using System.IO;

namespace Bolt.Generation.JsTestUrlCollectors
{
    public class TextFileUrlCollector : IJsTestUrlCollector
    {
        public string UrlTextFileName
        { 
            get
            {
                // TODO: Pull the UrlTextFile name from the config. If not in the config, return the default
                return "Urls.txt";
            }
        }

        public IList<string> GetUrls(string jsWebSitePath)
        {
            var filePath = Path.Combine(jsWebSitePath, UrlTextFileName);

            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException(string.Format("Cannot find file '{0}' in JavaScript Unit Test site path.", filePath));
            }

            var urlList = new List<String>();
            using (var reader = new StreamReader(filePath))
            {
                var line = reader.ReadLine();
                if (!String.IsNullOrWhiteSpace(line))
                {
                    urlList.Add(line);
                }
            }

            return urlList;
        }
    }
}
