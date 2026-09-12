using System;

class Program
{
    static void Main(string[] args)
    {
        Diario meuDiario = new Diario();
        GeradorDePerguntas gerador = new GeradorDePerguntas();

        int opcao = 0;

        // Criatividade: além dos requisitos básicos, cada entrada também
        // registra o humor do usuário naquele dia.
        while (opcao != 5)
        {
            Console.WriteLine();
            Console.WriteLine("=== PROGRAMA DE DIÁRIO ===");
            Console.WriteLine("1. Escrever nova entrada");
            Console.WriteLine("2. Exibir diário");
            Console.WriteLine("3. Salvar diário");
            Console.WriteLine("4. Carregar diário");
            Console.WriteLine("5. Sair");
            Console.Write("Escolha uma opção: ");

            string escolha = Console.ReadLine();
            opcao = int.Parse(escolha);

            if (opcao == 1)
            {
                string pergunta = gerador.ObterPerguntaAleatoria();

                Console.WriteLine();
                Console.WriteLine(pergunta);
                Console.Write("> ");
                string resposta = Console.ReadLine();

                Console.Write("Como você está se sentindo hoje? ");
                string humor = Console.ReadLine();

                Entrada novaEntrada = new Entrada();
                novaEntrada._data = DateTime.Now.ToShortDateString();
                novaEntrada._textoPergunta = pergunta;
                novaEntrada._textoResposta = resposta;
                novaEntrada._humor = humor;

                meuDiario.AdicionarEntrada(novaEntrada);

                Console.WriteLine("Entrada adicionada com sucesso!");
            }
            else if (opcao == 2)
            {
                meuDiario.ExibirTodos();
            }
            else if (opcao == 3)
            {
                Console.Write("Digite o nome do arquivo: ");
                string nomeArquivo = Console.ReadLine();

                meuDiario.SalvarNoArquivo(nomeArquivo);

                Console.WriteLine("Diário salvo com sucesso!");
            }
            else if (opcao == 4)
            {
                Console.Write("Digite o nome do arquivo: ");
                string nomeArquivo = Console.ReadLine();

                meuDiario.CarregarDoArquivo(nomeArquivo);

                Console.WriteLine("Diário carregado com sucesso!");
            }
            else if (opcao == 5)
            {
                Console.WriteLine("Até logo!");
            }
            else
            {
                Console.WriteLine("Opção inválida.");
            }
        }
    }
}