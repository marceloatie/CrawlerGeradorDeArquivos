using CrawlerGeradorDeArquivos.Models;
using System;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace CrawlerGeradorDeArquivos
{
    class FileWriter
    {
        private readonly Properties _properties;

        public FileWriter(Properties properties)
        {
            _properties = properties;
        }

        public Report WriteText(string text, int textSize)
        {
            if (textSize <= 0)
            {
                throw new Exception("O tamanho do texto informado é zero");
            }

            int kilobyte = 1024;
            int megabyte = 1024 * kilobyte;
            long maxFileSize = _properties.MaxFileSize * megabyte;
            int maxBufferSize = _properties.MaxBufferSize * megabyte;
            string localFile = _properties.Path;
            if (!_properties.Path.EndsWith(@"\"))
            {
                localFile += @"\";
            }
            localFile += _properties.FileName;
            
            long actualFileSize = 0;
            int iteractionCount = 0;
            
            Stopwatch stopwatch = new Stopwatch();

            using (StreamWriter writer = File.CreateText(localFile))
            {
                StringBuilder sb = new StringBuilder("", maxBufferSize);
                stopwatch.Start();
                while (actualFileSize < maxFileSize)
                {
                    long actualBufferSize = 0;
                    while (actualFileSize < maxFileSize && actualBufferSize <= (maxBufferSize - textSize))
                    {
                        sb.Append(text);
                        actualBufferSize += textSize;
                        actualFileSize += textSize;
                    }
                    writer.Write(sb);
                    writer.Flush();
                    sb.Clear();
                    iteractionCount++;    
                }
                stopwatch.Stop();
            }

            Report report = new Report();
            report.FileName = Path.GetFileName(localFile);
            report.FileSize = (int)(new FileInfo(localFile).Length / megabyte);
            report.FilePath = Path.GetDirectoryName(localFile);
            report.Iteractions = iteractionCount;
            report.TimeElapsed = stopwatch.Elapsed;

            return report;
        }
    }
}
