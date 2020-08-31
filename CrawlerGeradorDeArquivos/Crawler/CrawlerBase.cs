using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using System;

namespace CrawlerGeradorDeArquivos.Crawler
{
    class CrawlerBase : IDisposable
    {
        private readonly RemoteWebDriver _remoteWebDriver;

        public CrawlerBase()
        {
            FirefoxOptions ffoptions = new FirefoxOptions();
            ffoptions.AddArguments("--headless");

            RemoteWebDriver remoteWebDriver = new FirefoxDriver(ffoptions);

            if (remoteWebDriver == null) throw new ArgumentNullException("remoteWebDriver");
            _remoteWebDriver = remoteWebDriver;
        }

        public void GoToUrl(string url)
        {
            try
            {
                Uri webSiteUri = new Uri(url, UriKind.Absolute);
                _remoteWebDriver.Navigate().GoToUrl(webSiteUri);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public string getTextFromElementClassName(string className)
        {
            IWebElement element = _remoteWebDriver.FindElement(By.ClassName(className));
            return element.Text;
        }

        public string getTextFromElementId(string className)
        {
            IWebElement element = _remoteWebDriver.FindElement(By.Id(className));
            return element.Text;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_remoteWebDriver != null)
                {
                    _remoteWebDriver.Quit();
                }
            }
        }
    }
}