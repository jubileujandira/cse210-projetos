using System;
using System.Collections.Generic;
using System.IO;

public class Diario
{
    public List<Entrada> _entradas = new List<Entrada>();

    public void AdicionarEntrada(Entrada novaEntrada)
    {
        _entradas.Add(novaEntrada);
    }

    public void ExibirTodos()
    {
        Console.WriteLine();
        Console.WriteLine("=== Meu Diário ===");

        foreach (Entrada entrada in _entradas)
        {
            entrada.Exibir();
        }
    }

    public void SalvarNoArquivo(string nomeArquivo)
    {
        using (StreamWriter arquivoSaida = new StreamWriter(nomeArquivo))
        {
            foreach (Entrada entrada in _entradas)
            {
                arquivoSaida.WriteLine(
                    $"{entrada._data}|{entrada._textoPergunta}|{entrada._textoResposta}|{entrada._humor}"
                );
            }
        }
    }

    public void CarregarDoArquivo(string nomeArquivo)
    {
        _entradas.Clear();

        string[] linhas = File.ReadAllLines(nomeArquivo);

        foreach (string linha in linhas)
        {
            string[] partes = linha.Split("|");

            Entrada entrada = new Entrada();
            entrada._data = partes[0];
            entrada._textoPergunta = partes[1];
            entrada._textoResposta = partes[2];
            entrada._humor = partes[3];

            _entradas.Add(entrada);
        }
    }
}