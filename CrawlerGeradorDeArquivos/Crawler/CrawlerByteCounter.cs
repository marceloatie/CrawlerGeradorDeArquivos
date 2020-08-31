namespace CrawlerGeradorDeArquivos.Crawler
{
    class CrawlerByteCounter
    {
        private readonly CrawlerBase crawler;
        public CrawlerByteCounter(CrawlerBase crawler)
        {
            this.crawler = crawler;
        }
        public int Get(string text)
        {
            crawler.GoToUrl(@"https://mothereff.in/byte-counter#"+ text);
            string txtBytes = crawler.getTextFromElementId("bytes");
            return int.Parse(txtBytes.Replace(" bytes", ""));
        }
    }
}
