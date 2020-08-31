using CrawlerGeradorDeArquivos.Models;
using CrawlerGeradorDeArquivos.Crawler;
using System;

namespace CrawlerGeradorDeArquivos
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("No dia mais claro, na noite mais escura, nenhum mal escapará a minha visão\n");

            try
            {
                //Processar args
                ArgsProcessor argsProcessor = new ArgsProcessor();
                Properties properties = argsProcessor.Process(args);

                string textQuote = null;
                int textSize = 0;
                using (CrawlerBase crawler = new CrawlerBase())
                {
                    //Obter Lerolero
                    try
                    {
                        CrawlerLerolero crawlerLerolero = new CrawlerLerolero(crawler);
                        textQuote = crawlerLerolero.Get();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Rapaz, deu ruim no crawler do lerolero! vou usar a estratégia de fallback");
                        textQuote = AleatoryQuotes();
                    }
                    Console.WriteLine("\nLerolero: " + textQuote);

                    //Verificar tamanho em bytes
                    try
                    {
                        CrawlerByteCounter crawlerByteCounter = new CrawlerByteCounter(crawler);
                        textSize = crawlerByteCounter.Get(textQuote);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Rapaz, deu ruim no crawler do bytecounter! vou usar a estratégia de fallback");
                        textSize = ByteSizeOfString(textQuote);
                    }
                    Console.WriteLine("\nBytes: " + textSize);
                }

                //Salvar arquivo
                FileWriter fileWriter = new FileWriter(properties);
                Report report = fileWriter.WriteText(textQuote, textSize);

                //Exibir relatório
                report.Print();
            }catch(Exception ex)
            {
                Console.WriteLine("----------------");
                Console.WriteLine("ERRO: " + ex.Message);
                Console.WriteLine("----------------");
            }

            //Aguardar pelo comando de sair
            Exit();
        }

        private static void Exit()
        {
            Console.WriteLine("Aperte uma tecla para encerrar");
            Console.ReadKey();
            Environment.Exit(0);
        }

        public static int ByteSizeOfString(string txt)
        {
            /*Console.WriteLine("UNICODE ->" + System.Text.ASCIIEncoding.Unicode.GetByteCount(txt));
            Console.WriteLine("ASCII ->" + System.Text.ASCIIEncoding.ASCII.GetByteCount(txt));
            Console.WriteLine("UTF8 ->" + System.Text.ASCIIEncoding.UTF8.GetByteCount(txt));*/

            return System.Text.ASCIIEncoding.UTF8.GetByteCount(txt);
        }

        private static string AleatoryQuotes()
        {
            string[] quoteList = new string[] {
                "No futuro, os computadores podem pesar não mais que 1.5 toneladas. (1949)",
                "Não há razão para qualquer indivíduo ter um computador em casa. (1977)",
                "Você quer passar o resto da sua vida vendendo água com açúcar ou quer uma chance de mudar o mundo? (Steve Jobs)",
                "Algumas pessoas acham que foco significa dizer sim para a coisa em que você vai se focar. Mas não é nada disso. Significa dizer não às centenas de outras boas ideias que existem. Você precisa selecionar cuidadosamente. (Steve Jobs, 2008)",
                "Vírus de computadores são uma lenda urbana. (Peter Norton, 1988)",
                "Estou fazendo um sistema operacional gratuito (apenas um hobby, não será grande e profissional como GNU) para 386/486 AT. (Linus Torvalds, 1991)",
                "640K é mais memória do que qualquer pessoa vai precisar. (Bill Gates, 1981)" };
            Random r = new Random();
            int rand = r.Next(0, 6);

            return quoteList[rand];
        }
    }
}
