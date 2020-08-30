using CrawlerGeradorDeArquivos.Models;
using System;

namespace CrawlerGeradorDeArquivos
{
    class ArgsProcessor
    {
        public Properties process(string[] args)
        {
            Properties properties = new Properties
            {
                MaxBufferSize = 1,
                MaxFileSize = 100,
                FileName = DateTime.Now.ToString("yyyy-MM-dd-HHmmss") + "-arquivo-gerado.txt"
            };


            for (int i =0; i < args.Length -1; i++)
            {
                //Console.WriteLine(i + " -> " + args[i]);
                switch (args[i])
                {
                    case "--buffersize":
                        i++;
                        properties.MaxBufferSize = int.Parse(args[i]);
                        break;
                    case "--filesize":
                        i++;
                        properties.MaxFileSize = int.Parse(args[i]);
                        break;
                    case "--path":
                        i++;
                        properties.Path = args[i];
                        break;
                    case "--filename":
                        i++;
                        properties.FileName = args[i];
                        break;
                }
            }
            
            Console.WriteLine("Buffer máximo: " + properties.MaxBufferSize + "MB");
            Console.WriteLine("Arquivo máximo: " + properties.MaxFileSize + "MB");
            Console.WriteLine("Caminho do arquivo: " + properties.Path);
            Console.WriteLine("Nome do arquivo: " + properties.FileName);
            Console.WriteLine("");

            if (properties.Path == null)
            {
                Console.WriteLine("Parametro --path não foi informado");
                return null;
            }

            return properties;
        }
    }
}
