public class Palavra
{
    private string _texto;
    private bool _oculta;

    public Palavra(string texto)
    {
        _texto = texto;
        _oculta = false;
    }

    public void Ocultar()
    {
        _oculta = true;
    }

    public bool EstaOculta()
    {
        return _oculta;
    }

    public string ObterTextoExibicao()
    {
        if (_oculta)
        {
            string resultado = "";

            foreach (char caractere in _texto)
            {
                if (char.IsLetter(caractere))
                {
                    resultado += "_";
                }
                else
                {
                    resultado += caractere;
                }
            }

            return resultado;
        }

        return _texto;
    }
}