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
            string msg = crawlerLerolero.Get();
            Console.WriteLine("\nLerolero: " + msg + "\n");
            if (msg == null) exit();
            
            //Verificar tamanho em bytes
            //Salvar arquivo
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
