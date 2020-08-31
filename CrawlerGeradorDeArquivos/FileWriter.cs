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

        public void WriteText(string text, int textSize)
        {
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

            Console.WriteLine("Nome:" + Path.GetFileName(localFile));
            Console.WriteLine("Tamanho do arquivo: " + new FileInfo(localFile).Length / megabyte + " MB");
            Console.WriteLine("Path:" + Path.GetDirectoryName(localFile));
            Console.WriteLine("Iterações: " + iteractionCount);
            Console.WriteLine("Tempo total: " + stopwatch.Elapsed);
            Console.WriteLine("Tempo médio: " + stopwatch.Elapsed / iteractionCount);
            Console.WriteLine("");
        }
    }
}
