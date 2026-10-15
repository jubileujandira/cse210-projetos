
using System;

public class MetaEterna : Meta
{
    private int _vezesRealizada;

    public MetaEterna(string nome, string descricao, int pontos)
        : base(nome, descricao, pontos)
    {
        _vezesRealizada = 0;
    }

    public override int RegistrarEvento()
    {
        _vezesRealizada++;

        Console.WriteLine("Parabéns! Você avançou em sua meta eterna!");

        return ObterPontos();
    }

    public override bool EstaConcluida()
    {
        return false;
    }

    public override string ObterDetalhes()
    {
        return $"[ ] {base.ObterDetalhes()} - Realizada {_vezesRealizada} vez(es)";
    }

    public override string ObterRepresentacaoEmTexto()
    {
        return $"MetaEterna:{ObterNome()}|{ObterDescricao()}|{ObterPontos()}|{_vezesRealizada}";
    }

    public void DefinirVezesRealizada(int vezes)
    {
        _vezesRealizada = vezes;
    }
}
