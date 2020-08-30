using CrawlerGeradorDeArquivos.Models;
using System;

namespace CrawlerGeradorDeArquivos
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            //Processar args
            ArgsProcessor argsProcessor = new ArgsProcessor();
            Properties properties = argsProcessor.process(args);
            if(properties == null) exit();
            //Obter Lerolero
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
