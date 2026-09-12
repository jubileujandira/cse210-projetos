using System;
using System.Collections.Generic;

public class GeradorDePerguntas
{
    public List<string> _perguntas = new List<string>()
    {
        "Quem foi a pessoa mais interessante com quem você interagiu hoje?",
        "Qual foi a melhor parte do seu dia?",
        "Como você viu a mão do Senhor em sua vida hoje?",
        "Qual foi a emoção mais forte que você sentiu hoje?",
        "O que você gostaria de ter feito diferente hoje?",
        "Qual foi uma coisa nova que você aprendeu hoje?"
    };

    public string ObterPerguntaAleatoria()
    {
        Random random = new Random();
        int indice = random.Next(_perguntas.Count);

        return _perguntas[indice];
    }
}