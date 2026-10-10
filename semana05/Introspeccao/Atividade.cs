
using System;
using System.Threading;

class Atividade
{
    private string _nome;
    private string _descricao;
    private int _duracao;

    public Atividade(string nome, string descricao)
    {
        _nome = nome;
        _descricao = descricao;
    }

    public int ObterDuracao()
    {
        return _duracao;
    }

    public void Iniciar()
    {
        Console.Clear();
        Console.WriteLine($"Bem-vindo à atividade de {_nome}.");
        Console.WriteLine();
        Console.WriteLine(_descricao);
        Console.WriteLine();

        Console.Write("Quanto tempo, em segundos, deseja realizar a atividade? ");
        while (!int.TryParse(Console.ReadLine(), out _duracao) || _duracao <= 0)
        {
            Console.Write("Digite um número de segundos maior que zero: ");
        }

        Console.Clear();
        Console.WriteLine("Prepare-se para começar...");
        MostrarAnimacao(3);
    }

    public void Finalizar()
    {
        Console.WriteLine();
        Console.WriteLine("Muito bem! Você concluiu a atividade.");
        MostrarAnimacao(3);

        Console.WriteLine();
        Console.WriteLine($"Você completou {_duracao} segundos da atividade de {_nome}.");
        MostrarAnimacao(3);
    }

    public void MostrarAnimacao(int segundos)
    {
        string[] simbolos = { "|", "/", "-", "\\" };

        for (int i = 0; i < segundos * 4; i++)
        {
            Console.Write(simbolos[i % simbolos.Length]);
            Thread.Sleep(250);
            Console.Write("\b \b");
        }

        Console.WriteLine();
    }

    public void MostrarContagem(int segundos)
    {
        for (int i = segundos; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }

        Console.WriteLine();
    }
}
