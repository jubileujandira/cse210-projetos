
using System;

class Program
{
    static void Main(string[] args)
    {
        // Criatividade: o programa registra quantas atividades
        // foram concluídas durante a execução e apresenta
        // um resumo quando o usuário decide sair.

        int atividadesConcluidas = 0;
        string opcao = "";

        while (opcao != "4")
        {
            Console.Clear();
            Console.WriteLine("===== PROGRAMA DE INTROSPECÇÃO =====");
            Console.WriteLine();
            Console.WriteLine("Escolha uma atividade:");
            Console.WriteLine("1. Respiração");
            Console.WriteLine("2. Reflexão");
            Console.WriteLine("3. Listagem");
            Console.WriteLine("4. Sair");
            Console.WriteLine();
            Console.Write("Digite sua opção: ");

            opcao = Console.ReadLine() ?? "";

            switch (opcao)
            {
                case "1":
                    AtividadeRespiracao respiracao = new AtividadeRespiracao();
                    respiracao.Executar();
                    atividadesConcluidas++;
                    break;

                case "2":
                    AtividadeReflexao reflexao = new AtividadeReflexao();
                    reflexao.Executar();
                    atividadesConcluidas++;
                    break;

                case "3":
                    AtividadeListagem listagem = new AtividadeListagem();
                    listagem.Executar();
                    atividadesConcluidas++;
                    break;

                case "4":
                    Console.Clear();
                    Console.WriteLine("Obrigado por utilizar o programa!");
                    Console.WriteLine(
                        $"Você concluiu {atividadesConcluidas} atividade(s) nesta sessão."
                    );
                    break;

                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }

            if (opcao != "4")
            {
                Console.WriteLine();
                Console.WriteLine("Pressione Enter para voltar ao menu...");
                Console.ReadLine();
            }
        }
    }
}
