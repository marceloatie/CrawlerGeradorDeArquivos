using System;

namespace CrawlerGeradorDeArquivos.Crawler
{
    public class CrawlerLerolero
    {
        private readonly CrawlerBase crawler;
        public CrawlerLerolero(CrawlerBase crawler)
        {
            this.crawler = crawler;
        }
        public string Get()
        {
            try
            {
                crawler.GoToUrl(@"https://lerolero.com");
                return crawler.getTextFromElementClassName("sentence-exited");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
