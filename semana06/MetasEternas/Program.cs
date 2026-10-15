
using System;
using System.Text;

class Program
{
    // CRIATIVIDADE:
    // Além dos requisitos básicos, foi implementado um sistema
    // de níveis para motivar o usuário a continuar cumprindo
    // suas metas. A cada 500 pontos, o usuário sobe de nível.
    // O programa também mostra quantos pontos faltam para
    // alcançar o próximo nível e apresenta uma mensagem
    // especial quando o usuário sobe de nível.

    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.InputEncoding = Encoding.UTF8;

        GerenciadorDeMetas gerenciador = new GerenciadorDeMetas();

        int opcao = 0;

        Console.WriteLine("==================================");
        Console.WriteLine("     PROGRAMA DE METAS ETERNAS     ");
        Console.WriteLine("==================================");

        while (opcao != 6)
        {
            Console.WriteLine("\n--- MENU PRINCIPAL ---");

            gerenciador.MostrarPontuacao();

            Console.WriteLine("\n1. Criar nova meta");
            Console.WriteLine("2. Listar metas");
            Console.WriteLine("3. Registrar evento");
            Console.WriteLine("4. Salvar metas");
            Console.WriteLine("5. Carregar metas");
            Console.WriteLine("6. Sair");

            Console.Write("\nEscolha uma opção: ");

            string entrada = Console.ReadLine() ?? "";

            if (!int.TryParse(entrada, out opcao))
            {
                Console.WriteLine("Digite uma opção válida.");
                continue;
            }

            switch (opcao)
            {
                case 1:
                    gerenciador.CriarMeta();
                    break;

                case 2:
                    gerenciador.ListarMetas();
                    break;

                case 3:
                    gerenciador.RegistrarEvento();
                    break;

                case 4:
                    gerenciador.SalvarMetas();
                    break;

                case 5:
                    gerenciador.CarregarMetas();
                    break;

                case 6:
                    Console.WriteLine(
                        "\nObrigado por utilizar o Programa de Metas Eternas!");
                    Console.WriteLine(
                        "Continue avançando em seus objetivos!");
                    break;

                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }
        }
    }
}
