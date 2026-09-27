// Projeto: Programa de Memorização de Escrituras
//
// Para ir além dos requisitos básicos, o programa seleciona
// aleatoriamente apenas palavras que ainda não foram ocultadas.
// Isso evita selecionar novamente palavras que já estão escondidas.

class Program
{
    static void Main(string[] args)
    {
        Referencia referencia = new Referencia("Provérbios", 3, 5, 6);

        string texto = "Confia no Senhor de todo o teu coração e não te estribes no teu próprio entendimento. Reconhece-o em todos os teus caminhos e ele endireitará as tuas veredas.";

        Escritura escritura = new Escritura(referencia, texto);

        while (!escritura.EstaCompletamenteOculta())
        {
            Console.Clear();

            Console.WriteLine(escritura.ObterTextoExibicao());
            Console.WriteLine();
            Console.WriteLine("Pressione Enter para continuar ou digite 'sair' para encerrar.");

            string entrada = Console.ReadLine() ?? "";

            if (entrada.ToLower() == "sair")
            {
                return;
            }

            escritura.OcultarPalavrasAleatorias(3);
        }

        Console.Clear();
        Console.WriteLine(escritura.ObterTextoExibicao());
        Console.WriteLine();
        Console.WriteLine("Todas as palavras foram ocultadas.");
    }
}