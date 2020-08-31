using System;
using System.Collections.Generic;
using System.Text;

namespace CrawlerGeradorDeArquivos.Models
{
    class Report
    {
        public string FileName { get; set; }

        public int FileSize { get; set; }

        public string FilePath { get; set; }

        public int Iteractions { get; set; }

        public TimeSpan TimeElapsed { get; set; }

        public void Print()
        {
            Console.WriteLine("");
            Console.WriteLine("============RELATORIO============");
            Console.WriteLine("Nome:" + FileName);
            Console.WriteLine("Tamanho do arquivo: " + FileSize + " MB");
            Console.WriteLine("Path:" + FilePath);
            Console.WriteLine("Iterações: " + Iteractions);
            Console.WriteLine("Tempo total: " + TimeElapsed);
            Console.WriteLine("Tempo médio: " + TimeElapsed / Iteractions);
            Console.WriteLine("=================================");
            Console.WriteLine("");
        }
    }
}
