class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        Video video1 = new Video("Aprendendo C#", "Leandro Moura", 420);
        video1.AdicionarComentario(new Comentario("Gabriel", "Muito bom!"));
        video1.AdicionarComentario(new Comentario("Victor", "Gostei do vídeo."));
        video1.AdicionarComentario(new Comentario("Manu", "Excelente explicação!"));
        videos.Add(video1);

        Video video2 = new Video("Introdução à Programação", "João Silva", 650);
        video2.AdicionarComentario(new Comentario("Carlos", "Muito interessante."));
        video2.AdicionarComentario(new Comentario("Ana", "Aprendi bastante."));
        video2.AdicionarComentario(new Comentario("Pedro", "Ótima aula!"));
        videos.Add(video2);

        Video video3 = new Video("Programação Orientada a Objetos", "Maria Santos", 800);
        video3.AdicionarComentario(new Comentario("Lucas", "Excelente conteúdo."));
        video3.AdicionarComentario(new Comentario("Paulo", "Muito bem explicado."));
        video3.AdicionarComentario(new Comentario("José", "Obrigado pela aula!"));
        videos.Add(video3);

        foreach (Video video in videos)
        {
            Console.WriteLine($"Título: {video.ObterTitulo()}");
            Console.WriteLine($"Autor: {video.ObterAutor()}");
            Console.WriteLine($"Duração: {video.ObterDuracao()} segundos");
            Console.WriteLine($"Número de comentários: {video.ObterNumeroComentarios()}");
            Console.WriteLine("Comentários:");

            foreach (Comentario comentario in video.ObterComentarios())
            {
                Console.WriteLine($"{comentario.ObterNome()}: {comentario.ObterTexto()}");
            }

            Console.WriteLine();
        }
    }
}