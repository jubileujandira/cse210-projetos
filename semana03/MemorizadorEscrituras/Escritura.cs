public class Escritura
{
    private Referencia _referencia;
    private List<Palavra> _palavras;

    public Escritura(Referencia referencia, string texto)
    {
        _referencia = referencia;
        _palavras = new List<Palavra>();

        string[] palavras = texto.Split(' ');

        foreach (string palavra in palavras)
        {
            _palavras.Add(new Palavra(palavra));
        }
    }

    public void OcultarPalavrasAleatorias(int quantidade)
    {
        Random random = new Random();

        // Seleciona somente palavras que ainda não estão ocultas.
        List<Palavra> palavrasVisiveis = _palavras
            .Where(palavra => !palavra.EstaOculta())
            .ToList();

        int quantidadeParaOcultar = Math.Min(quantidade, palavrasVisiveis.Count);

        for (int i = 0; i < quantidadeParaOcultar; i++)
        {
            int indice = random.Next(palavrasVisiveis.Count);

            palavrasVisiveis[indice].Ocultar();
            palavrasVisiveis.RemoveAt(indice);
        }
    }

    public string ObterTextoExibicao()
    {
        string texto = "";

        foreach (Palavra palavra in _palavras)
        {
            texto += palavra.ObterTextoExibicao() + " ";
        }

        return $"{_referencia.ObterTextoExibicao()} {texto.Trim()}";
    }

    public bool EstaCompletamenteOculta()
    {
        foreach (Palavra palavra in _palavras)
        {
            if (!palavra.EstaOculta())
            {
                return false;
            }
        }

        return true;
    }
}