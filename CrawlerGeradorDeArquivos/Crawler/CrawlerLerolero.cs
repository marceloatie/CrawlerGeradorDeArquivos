using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using System.Linq;
using OpenQA.Selenium.IE;
using System.IO;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace Crawler
{
    class CrawlerLerolero
    {
        public string Get()
        {
            using (var crawler = new Crawler())
            {
                return crawler.GetLeroLero();
            }
        }
    }
}
