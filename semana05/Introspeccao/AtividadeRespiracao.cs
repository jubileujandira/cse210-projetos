
using System;

class AtividadeRespiracao : Atividade
{
    public AtividadeRespiracao() : base(
        "Respiração",
        "Esta atividade ajudará você a relaxar, inspirando e expirando lentamente. Limpe sua mente e concentre-se na sua respiração.")
    {
    }

    public void Executar()
    {
        Iniciar();

        int duracao = ObterDuracao();
        int tempoDecorrido = 0;

        while (tempoDecorrido < duracao)
        {
            int tempoInspirar = Math.Min(4, duracao - tempoDecorrido);

            Console.Write("Inspire... ");
            MostrarContagem(tempoInspirar);
            tempoDecorrido += tempoInspirar;

            if (tempoDecorrido >= duracao)
            {
                break;
            }

            int tempoExpirar = Math.Min(4, duracao - tempoDecorrido);

            Console.Write("Expire... ");
            MostrarContagem(tempoExpirar);
            tempoDecorrido += tempoExpirar;
        }

        Finalizar();
    }
}
