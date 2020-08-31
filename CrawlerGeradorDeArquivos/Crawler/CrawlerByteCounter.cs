using System;

namespace CrawlerGeradorDeArquivos.Crawler
{
    public class CrawlerByteCounter
    {
        private readonly CrawlerBase crawler;
        public CrawlerByteCounter(CrawlerBase crawler)
        {
            this.crawler = crawler;
        }
        public int Get(string text)
        {
            int size;
            try
            {
                crawler.GoToUrl(@"https://mothereff.in/byte-counter#" + text);
                string txtBytes = crawler.getTextFromElementId("bytes");
                size = int.Parse(txtBytes.Replace(" bytes", ""));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return size;
        }
    }
}
