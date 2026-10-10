
using System;
using System.Collections.Generic;
using System.Diagnostics;

class AtividadeReflexao : Atividade
{
    private List<string> _mensagens = new List<string>
    {
        "Pense em uma ocasião em que você defendeu outra pessoa.",
        "Pense em uma ocasião em que você fez algo realmente difícil.",
        "Pense em uma ocasião em que você ajudou alguém necessitado.",
        "Pense em uma ocasião em que você fez algo altruísta."
    };

    private List<string> _perguntas = new List<string>
    {
        "Por que essa experiência foi significativa para você?",
        "Você já fez algo assim antes?",
        "Como você começou?",
        "Como você se sentiu quando terminou?",
        "O que tornou esse momento diferente?",
        "O que você aprendeu com essa experiência?",
        "O que você aprendeu sobre si mesmo?",
        "Como pode aplicar essa experiência no futuro?"
    };

    public AtividadeReflexao() : base(
        "Reflexão",
        "Esta atividade ajudará você a refletir sobre momentos em que demonstrou força e resiliência.")
    {
    }

    public void Executar()
    {
        Iniciar();

        Random random = new Random();

        Console.WriteLine();
        Console.WriteLine(_mensagens[random.Next(_mensagens.Count)]);
        Console.WriteLine();
        Console.WriteLine("Reflita sobre esta experiência.");
        MostrarAnimacao(3);

        Console.WriteLine("Agora considere as seguintes perguntas:");
        MostrarContagem(3);

        Stopwatch relogio = Stopwatch.StartNew();

        while (relogio.Elapsed.TotalSeconds < ObterDuracao())
        {
            string pergunta = _perguntas[random.Next(_perguntas.Count)];

            Console.WriteLine();
            Console.WriteLine($"> {pergunta}");

            int tempoRestante = Math.Max(
                1,
                (int)Math.Ceiling(
                    ObterDuracao() - relogio.Elapsed.TotalSeconds
                )
            );

            MostrarAnimacao(Math.Min(5, tempoRestante));
        }

        relogio.Stop();
        Finalizar();
    }
}
