using CrawlerGeradorDeArquivos.Models;
using CrawlerGeradorDeArquivos.Crawler;
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
            Properties properties = argsProcessor.Process(args);
            if (properties == null) Exit();

            string textQuote = null;
            int textSize = 0;
            using (CrawlerBase crawler = new CrawlerBase())
            {
                //Obter Lerolero
                CrawlerLerolero crawlerLerolero = new CrawlerLerolero(crawler);
                textQuote = crawlerLerolero.Get();
                Console.WriteLine("\nLerolero: " + textQuote + "\n");
                if (textQuote == null) Exit();

                //Verificar tamanho em bytes
                try
                {
                    CrawlerByteCounter crawlerByteCounter = new CrawlerByteCounter(crawler);
                    textSize = crawlerByteCounter.Get(textQuote);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message + "\n");
                    Console.WriteLine("Rapaz, deu ruim no crawler! vou usar a estratégia de fallback");
                    textSize = ByteSizeOfString(textQuote);
                }
                Console.WriteLine("\nBytes: " + textSize + "\n");
            }

            //Salvar arquivo
            FileWriter fileWriter = new FileWriter(properties);
            Report report = fileWriter.WriteText(textQuote, textSize);

            //Exibir relatório
            report.Print();

            //Aguardar pelo comando de sair
            Exit();
        }

        private static void Exit()
        {
            Console.WriteLine("Aperte uma tecla para encerrar");
            Console.ReadKey();
            Environment.Exit(0);
        }

        private static int ByteSizeOfString(string txt)
        {
            /*Console.WriteLine("UNICODE ->" + System.Text.ASCIIEncoding.Unicode.GetByteCount(txt));
            Console.WriteLine("ASCII ->" + System.Text.ASCIIEncoding.ASCII.GetByteCount(txt));
            Console.WriteLine("UTF8 ->" + System.Text.ASCIIEncoding.UTF8.GetByteCount(txt));*/

            return System.Text.ASCIIEncoding.UTF8.GetByteCount(txt);
        }
    }
}
