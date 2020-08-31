# Crawler e Gerador de Arquivos!

Este projeto foi desenvolvido usando o Visual Studio Community 2019 e o selenium como crawler (não consegui usar o system.windows.forms.webbrowser em uma aplicação console). 

**Será necessário ter o firefox instalado**

# Parametros

Os parametros aceitos via linha de comando são
  - ``--path`` Esperado apenas o caminho até um diretório (ex. C:\temp\ )
  - ``--filename`` Caso não seja informado, gera no formato yyyy-MM-dd-HHmmss-arquivo-gerado.txt
  - ``--filesize`` Tamanho em Mb
  - ``--buffersize`` Tamanho em Mb

Exemplo ``--path c:\temp\``

Exemplo ``--path c:\temp\ --filename teste.txt --filesize 200 --buffersize 1``

A ordem dos parametros não são consideradas

Se o arquivo já existir, ele será sobrescrito.

# Testes unitários

Os testes unitários estão em um projeto separado (mas dentro da mesma solução), basta executar o "Run Tests" desse projeto de testes
