using Crawler;
using CrawlerGeradorDeArquivos.Models;
using System;

namespace CrawlerGeradorDeArquivos
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("No dia mais claro, na noite mais escura, nenhum mal escapará a minha visão\n");
            
            //Processar args
            ArgsProcessor argsProcessor = new ArgsProcessor();
            Properties properties = argsProcessor.process(args);
            if(properties == null) exit();
            
            //Obter Lerolero
            CrawlerLerolero crawlerLerolero = new CrawlerLerolero();
            string textQuote = crawlerLerolero.Get();
            Console.WriteLine("\nLerolero: " + textQuote + "\n");
            if (textQuote == null) exit();

            //Verificar tamanho em bytes
            CrawlerByteCounter crawlerByteCounter = new CrawlerByteCounter();
            int textSize = crawlerByteCounter.Get(textQuote);
            Console.WriteLine("\nBytes: " + textSize + "\n");

            //Salvar arquivo
            FileWriter fileWriter = new FileWriter(properties);
            fileWriter.WriteText(textQuote, textSize);

            //Exibir relatório
            //Aguardar pelo comando de sair
            exit();
        }

        private static void exit()
        {
            Console.WriteLine("Aperte uma tecla para encerrar");
            Console.ReadKey();
            Environment.Exit(0);
        }
    }
}
