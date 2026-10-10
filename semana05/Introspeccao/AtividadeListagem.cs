
using System;
using System.Collections.Generic;
using System.Diagnostics;

class AtividadeListagem : Atividade
{
    private List<string> _perguntas = new List<string>
    {
        "Quem são as pessoas que você aprecia?",
        "Quais são seus pontos fortes pessoais?",
        "Quem são as pessoas que você ajudou esta semana?",
        "Quando você sentiu o Espírito Santo neste mês?",
        "Quem são alguns dos seus heróis pessoais?"
    };

    public AtividadeListagem() : base(
        "Listagem",
        "Esta atividade ajudará você a refletir sobre as coisas boas da sua vida, listando o máximo de coisas que puder.")
    {
    }

    public void Executar()
    {
        Iniciar();

        Random random = new Random();

        Console.WriteLine();
        Console.WriteLine(_perguntas[random.Next(_perguntas.Count)]);
        Console.WriteLine();

        Console.WriteLine("Você terá alguns segundos para pensar...");
        MostrarContagem(5);

        Console.WriteLine();
        Console.WriteLine("Comece a listar suas respostas:");
        Console.WriteLine();

        int quantidade = 0;
        Stopwatch relogio = Stopwatch.StartNew();

        while (relogio.Elapsed.TotalSeconds < ObterDuracao())
        {
            Console.Write("> ");
            string resposta = Console.ReadLine() ?? "";

            if (!string.IsNullOrWhiteSpace(resposta))
            {
                quantidade++;
            }
        }

        relogio.Stop();

        Console.WriteLine();
        Console.WriteLine($"Você listou {quantidade} itens!");
        Finalizar();
    }
}
