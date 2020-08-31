namespace CrawlerGeradorDeArquivos.Crawler
{
    class CrawlerLerolero
    {
        private readonly CrawlerBase crawler;
        public CrawlerLerolero(CrawlerBase crawler)
        {
            this.crawler = crawler;
        }
        public string Get()
        {
            crawler.GoToUrl(@"https://lerolero.com");
            return crawler.getTextFromElementClassName("sentence-exited");
        }
    }
}
