
using System;

public class MetaSimples : Meta
{
    private bool _concluida;

    public MetaSimples(string nome, string descricao, int pontos)
        : base(nome, descricao, pontos)
    {
        _concluida = false;
    }

    public override int RegistrarEvento()
    {
        if (!_concluida)
        {
            _concluida = true;
            Console.WriteLine("Parabéns! Meta concluída!");
            return ObterPontos();
        }

        Console.WriteLine("Esta meta já foi concluída.");
        return 0;
    }

    public override bool EstaConcluida()
    {
        return _concluida;
    }

    public override string ObterDetalhes()
    {
        string status = _concluida ? "[X]" : "[ ]";
        return $"{status} {base.ObterDetalhes()}";
    }

    public override string ObterRepresentacaoEmTexto()
    {
        return $"MetaSimples:{ObterNome()}|{ObterDescricao()}|{ObterPontos()}|{_concluida}";
    }

    public void DefinirConclusao(bool concluida)
    {
        _concluida = concluida;
    }
}
