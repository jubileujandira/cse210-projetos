using System;

public class Entrada
{
    public string _data = "";
    public string _textoPergunta = "";
    public string _textoResposta = "";
    public string _humor = "";

    public void Exibir()
    {
        Console.WriteLine($"Data: {_data}");
        Console.WriteLine($"Pergunta: {_textoPergunta}");
        Console.WriteLine($"Resposta: {_textoResposta}");
        Console.WriteLine($"Humor: {_humor}");
        Console.WriteLine();
    }
}