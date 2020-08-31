using CrawlerGeradorDeArquivos;
using CrawlerGeradorDeArquivos.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestsCrawlerGeradorDeArquivos
{
    [TestClass]
    public class ArgsProcessorTests
    {
        [TestMethod]
        public void FillProperties()
        {
            ArgsProcessor ap = new ArgsProcessor();
            Properties properties = ap.Process(new string[] { "--path", @"C:\temp\", "--filename", "test.txt", "--filesize", "999", "--buffersize", "4" });
            Assert.AreEqual(properties.Path, @"C:\temp\");
            Assert.AreEqual(properties.FileName, "test.txt");
            Assert.AreEqual(properties.MaxFileSize, 999);
            Assert.AreEqual(properties.MaxBufferSize, 4);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Parametro --path não foi informado")]
        public void PathRequired()
        {
            ArgsProcessor ap = new ArgsProcessor();
            ap.Process(new string[] { });
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Parametro --filesize não permitido")]
        public void FileSizeValidation()
        {
            ArgsProcessor ap = new ArgsProcessor();
            ap.Process(new string[] { "--path", @"C:\temp\", "--filesize", "-1" });
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Parametro --buffersize não permitido")]
        public void BufferSizeValidation()
        {
            ArgsProcessor ap = new ArgsProcessor();
            ap.Process(new string[] { "--path", @"C:\temp\", "--buffersize", "-1" });
        }
    }
}
