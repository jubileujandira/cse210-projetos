
using System;

public class MetaListaDeTarefas : Meta
{
    private int _quantidadeNecessaria;
    private int _quantidadeAtual;
    private int _bonus;

    public MetaListaDeTarefas(
        string nome,
        string descricao,
        int pontos,
        int quantidadeNecessaria,
        int bonus)
        : base(nome, descricao, pontos)
    {
        _quantidadeNecessaria = quantidadeNecessaria;
        _quantidadeAtual = 0;
        _bonus = bonus;
    }

    public override int RegistrarEvento()
    {
        if (EstaConcluida())
        {
            Console.WriteLine("Esta meta já foi concluída!");
            return 0;
        }

        _quantidadeAtual++;

        int pontosGanhos = ObterPontos();

        Console.WriteLine("Progresso registrado com sucesso!");

        if (EstaConcluida())
        {
            pontosGanhos += _bonus;

            Console.WriteLine("Parabéns! Você concluiu sua meta!");
            Console.WriteLine($"Bônus recebido: {_bonus} pontos!");
        }

        return pontosGanhos;
    }

    public override bool EstaConcluida()
    {
        return _quantidadeAtual >= _quantidadeNecessaria;
    }

    public override string ObterDetalhes()
    {
        string status = EstaConcluida() ? "[X]" : "[ ]";

        return $"{status} {base.ObterDetalhes()} - " +
               $"Concluída {_quantidadeAtual}/{_quantidadeNecessaria} vezes";
    }

    public override string ObterRepresentacaoEmTexto()
    {
        return $"MetaListaDeTarefas:{ObterNome()}|" +
               $"{ObterDescricao()}|" +
               $"{ObterPontos()}|" +
               $"{_quantidadeNecessaria}|" +
               $"{_bonus}|" +
               $"{_quantidadeAtual}";
    }

    public void DefinirQuantidadeAtual(int quantidade)
    {
        _quantidadeAtual = quantidade;
    }
}
