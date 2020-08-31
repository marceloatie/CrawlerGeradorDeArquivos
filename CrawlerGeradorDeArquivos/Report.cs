using System;
using System.Collections.Generic;
using System.Text;

namespace CrawlerGeradorDeArquivos.Models
{
    class Report
    {
        private string fileName;
        public string FileName
        {
            get { return fileName; }
            set { fileName = value; }
        }

        private int fileSize;
        public int FileSize
        {
            get { return fileSize; }
            set { fileSize = value; }
        }

        private string filePath;
        public string FilePath
        {
            get { return filePath; }
            set { filePath = value; }
        }

        private int iteractions;
        public int Iteractions
        {
            get { return iteractions; }
            set { iteractions = value; }
        }

        private TimeSpan timeElapsed;
        public TimeSpan TimeElapsed
        {
            get { return timeElapsed; }
            set { timeElapsed = value; }
        }

        public void Print()
        {
            Console.WriteLine("");
            Console.WriteLine("============RELATORIO============");
            Console.WriteLine("Nome:" + FileName);
            Console.WriteLine("Tamanho do arquivo: " + FileSize + " MB");
            Console.WriteLine("Path:" + FilePath);
            Console.WriteLine("Iterações: " + iteractions);
            Console.WriteLine("Tempo total: " + TimeElapsed);
            Console.WriteLine("Tempo médio: " + TimeElapsed / iteractions);
            Console.WriteLine("=================================");
            Console.WriteLine("");
        }
    }
}
