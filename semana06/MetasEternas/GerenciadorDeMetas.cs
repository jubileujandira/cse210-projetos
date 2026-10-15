
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

public class GerenciadorDeMetas
{
    private List<Meta> _metas = new List<Meta>();
    private int _pontuacao = 0;

    public void MostrarPontuacao()
    {
        int nivel = (_pontuacao / 500) + 1;

        Console.WriteLine($"\nPontuação atual: {_pontuacao} pontos");
        Console.WriteLine($"Nível atual: {nivel}");
        Console.WriteLine($"Faltam {500 - (_pontuacao % 500)} pontos para o próximo nível.");
    }

    public void CriarMeta()
    {
        Console.WriteLine("\nTipos de metas:");
        Console.WriteLine("1. Meta simples");
        Console.WriteLine("2. Meta eterna");
        Console.WriteLine("3. Meta de lista de tarefas");

        int tipo = LerInteiro("Escolha o tipo de meta: ", 1);

        if (tipo < 1 || tipo > 3)
        {
            Console.WriteLine("Tipo de meta inválido.");
            return;
        }

        Console.Write("Nome da meta: ");
        string nome = Console.ReadLine() ?? "";

        Console.Write("Descrição da meta: ");
        string descricao = Console.ReadLine() ?? "";

        int pontos = LerInteiro("Quantidade de pontos: ", 0);

        if (tipo == 1)
        {
            _metas.Add(new MetaSimples(nome, descricao, pontos));
        }
        else if (tipo == 2)
        {
            _metas.Add(new MetaEterna(nome, descricao, pontos));
        }
        else
        {
            int quantidade = LerInteiro(
                "Quantas vezes precisa realizar a meta? ", 1);

            int bonus = LerInteiro(
                "Quantidade de pontos de bônus: ", 0);

            _metas.Add(new MetaListaDeTarefas(
                nome, descricao, pontos, quantidade, bonus));
        }

        Console.WriteLine("\nMeta criada com sucesso!");
    }

    public void ListarMetas()
    {
        Console.WriteLine("\n--- SUAS METAS ---");

        if (_metas.Count == 0)
        {
            Console.WriteLine("Nenhuma meta cadastrada.");
            return;
        }

        for (int i = 0; i < _metas.Count; i++)
        {
            Console.WriteLine(
                $"{i + 1}. {_metas[i].ObterDetalhes()}");
        }
    }

    public void RegistrarEvento()
    {
        if (_metas.Count == 0)
        {
            Console.WriteLine("Cadastre uma meta primeiro.");
            return;
        }

        ListarMetas();

        int escolha = LerInteiro(
            "\nQual meta deseja registrar? ", 1);

        if (escolha > _metas.Count)
        {
            Console.WriteLine("Meta inválida.");
            return;
        }

        int nivelAnterior = (_pontuacao / 500) + 1;

        int pontosGanhos = _metas[escolha - 1].RegistrarEvento();

        _pontuacao += pontosGanhos;

        Console.WriteLine($"Você ganhou {pontosGanhos} pontos!");

        int novoNivel = (_pontuacao / 500) + 1;

        if (novoNivel > nivelAnterior)
        {
            Console.WriteLine(
                $"\nPARABÉNS! Você alcançou o nível {novoNivel}!");
        }

        MostrarPontuacao();
    }

    public void SalvarMetas()
    {
        Console.Write("Nome do arquivo para salvar: ");
        string arquivo = Console.ReadLine() ?? "";

        if (string.IsNullOrWhiteSpace(arquivo))
        {
            Console.WriteLine("Nome de arquivo inválido.");
            return;
        }

        try
        {
            using (StreamWriter saida = new StreamWriter(
                arquivo, false, Encoding.UTF8))
            {
                saida.WriteLine(_pontuacao);

                foreach (Meta meta in _metas)
                {
                    saida.WriteLine(
                        meta.ObterRepresentacaoEmTexto());
                }
            }

            Console.WriteLine("Metas salvas com sucesso!");
        }
        catch (Exception erro)
        {
            Console.WriteLine(
                $"Erro ao salvar arquivo: {erro.Message}");
        }
    }

    public void CarregarMetas()
    {
        Console.Write("Nome do arquivo para carregar: ");
        string arquivo = Console.ReadLine() ?? "";

        if (!File.Exists(arquivo))
        {
            Console.WriteLine("Arquivo não encontrado.");
            return;
        }

        try
        {
            string[] linhas = File.ReadAllLines(
                arquivo, Encoding.UTF8);

            if (linhas.Length == 0)
            {
                Console.WriteLine("O arquivo está vazio.");
                return;
            }

            int pontuacaoCarregada = int.Parse(linhas[0]);
            List<Meta> metasCarregadas = new List<Meta>();

            for (int i = 1; i < linhas.Length; i++)
            {
                string[] tipoEConteudo = linhas[i].Split(':', 2);

                if (tipoEConteudo.Length != 2)
                    throw new FormatException("Formato de meta inválido.");

                string tipo = tipoEConteudo[0];
                string[] dados = tipoEConteudo[1].Split('|');

                if (tipo == "MetaSimples" && dados.Length == 4)
                {
                    MetaSimples meta = new MetaSimples(
                        dados[0], dados[1], int.Parse(dados[2]));

                    meta.DefinirConclusao(bool.Parse(dados[3]));
                    metasCarregadas.Add(meta);
                }
                else if (tipo == "MetaEterna" && dados.Length == 4)
                {
                    MetaEterna meta = new MetaEterna(
                        dados[0], dados[1], int.Parse(dados[2]));

                    meta.DefinirVezesRealizada(int.Parse(dados[3]));
                    metasCarregadas.Add(meta);
                }
                else if (tipo == "MetaListaDeTarefas" && dados.Length == 6)
                {
                    MetaListaDeTarefas meta = new MetaListaDeTarefas(
                        dados[0], dados[1], int.Parse(dados[2]),
                        int.Parse(dados[3]), int.Parse(dados[4]));

                    meta.DefinirQuantidadeAtual(int.Parse(dados[5]));
                    metasCarregadas.Add(meta);
                }
                else
                {
                    throw new FormatException("Tipo de meta desconhecido.");
                }
            }

            _pontuacao = pontuacaoCarregada;
            _metas = metasCarregadas;

            Console.WriteLine("Metas carregadas com sucesso!");
            MostrarPontuacao();
        }
        catch (Exception erro)
        {
            Console.WriteLine(
                $"Erro ao carregar arquivo: {erro.Message}");
        }
    }

    private int LerInteiro(string mensagem, int minimo)
    {
        while (true)
        {
            Console.Write(mensagem);
            string entrada = Console.ReadLine() ?? "";

            if (int.TryParse(entrada, out int numero)
                && numero >= minimo)
            {
                return numero;
            }

            Console.WriteLine(
                $"Digite um número inteiro maior ou igual a {minimo}.");
        }
    }
}
