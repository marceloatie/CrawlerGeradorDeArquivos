using System;
using System.Collections.Generic;
using System.Text;

namespace CrawlerGeradorDeArquivos.Models
{
    class Properties
    {
        private int maxBufferSize;
        public int MaxBufferSize
        {
            get { return maxBufferSize; }
            set { maxBufferSize = value; }
        }

        private long maxFileSize;
        public long MaxFileSize
        {
            get { return maxFileSize; }
            set { maxFileSize = value; }
        }

        private string path;
        public string Path
        {
            get { return path; }
            set { path = value; }
        }

        private string fileName;
        public string FileName
        {
            get { return fileName; }
            set { fileName = value; }
        }
    }
}
