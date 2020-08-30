using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using System;

namespace Crawler
{
    public class Crawler : IDisposable
    {
        private readonly RemoteWebDriver _remoteWebDriver;


        public Crawler()
        {
            FirefoxOptions ffoptions = new FirefoxOptions();
            ffoptions.AddArguments("--headless");

            RemoteWebDriver remoteWebDriver = new FirefoxDriver(ffoptions);

            if (remoteWebDriver == null) throw new ArgumentNullException("remoteWebDriver");
            _remoteWebDriver = remoteWebDriver;
        }

        public Crawler(RemoteWebDriver remoteWebDriver)
        {
            if (remoteWebDriver == null) throw new ArgumentNullException("remoteWebDriver");
            _remoteWebDriver = remoteWebDriver;
        }

        public string GetLeroLero()
        {
            Uri webSiteUri = new Uri("https://lerolero.com", UriKind.Absolute);

            if (webSiteUri == null) throw new ArgumentNullException("webSiteUri");
            _remoteWebDriver.Navigate().GoToUrl(webSiteUri);
            IWebElement element = _remoteWebDriver.FindElement(By.ClassName("sentence-exited"));

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