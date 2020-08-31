using System;
using System.Collections.Generic;
using System.Text;

namespace CrawlerGeradorDeArquivos.Models
{
    public class Properties
    {
        public int MaxBufferSize { get; set; }

        public long MaxFileSize { get; set; }

        public string Path { get; set; }

        public string FileName { get; set; }
    }
}
