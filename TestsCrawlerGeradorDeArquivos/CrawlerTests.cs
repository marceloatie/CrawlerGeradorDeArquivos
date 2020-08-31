using Microsoft.VisualStudio.TestTools.UnitTesting;
using CrawlerGeradorDeArquivos;
using CrawlerGeradorDeArquivos.Crawler;

namespace TestsCrawlerGeradorDeArquivos
{
    [TestClass]
    public class CrawlerTests
    {
        [TestMethod]
        public void LeroleroTest()
        {
            string txt;
            using (CrawlerBase crawler = new CrawlerBase())
            {
                CrawlerLerolero crawlerLerolero = new CrawlerLerolero(crawler);
                txt = crawlerLerolero.Get();
            }
            Assert.IsTrue(txt.Length > 0);
        }

        [TestMethod]
        public void ByteCounterTest()
        {
            int byteSize;
            using (CrawlerBase crawler = new CrawlerBase())
            {
                CrawlerByteCounter crawlerByteCounter = new CrawlerByteCounter(crawler);
                byteSize = crawlerByteCounter.Get("Ol�");
            }
            Assert.AreEqual(byteSize, 4);
        }

        [TestMethod]
        public void ByteCounterFallbackTest()
        {
            int byteSize;
            byteSize = Program.ByteSizeOfString("Ol�");
            Assert.AreEqual(byteSize, 4);
        }

    }
}
