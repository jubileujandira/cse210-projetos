
using System;
using System.Collections.Generic;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;

        List<Atividade> atividades = new List<Atividade>();

        Corrida corrida = new Corrida(
            new DateTime(2026, 10, 15), 30, 5.0);

        Ciclismo ciclismo = new Ciclismo(
            new DateTime(2026, 10, 15), 45, 20.0);

        Natacao natacao = new Natacao(
            new DateTime(2026, 10, 15), 30, 20);

        atividades.Add(corrida);
        atividades.Add(ciclismo);
        atividades.Add(natacao);

        Console.WriteLine("====================================");
        Console.WriteLine("  MONITORAMENTO DE EXERCÍCIOS");
        Console.WriteLine("====================================");
        Console.WriteLine();

        foreach (Atividade atividade in atividades)
        {
            Console.WriteLine(atividade.ObterResumo());
            Console.WriteLine();
        }
    }
}
