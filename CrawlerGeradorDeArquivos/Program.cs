﻿using CrawlerGeradorDeArquivos.Models;
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
                CrawlerByteCounter crawlerByteCounter = new CrawlerByteCounter(crawler);
                textSize = crawlerByteCounter.Get(textQuote);
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
    }
}
