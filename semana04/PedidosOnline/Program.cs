Endereco endereco1 = new Endereco(
    "123 Main Street",
    "Orlando",
    "Florida",
    "EUA"
);

Cliente cliente1 = new Cliente("Carlos Silva", endereco1);

Pedido pedido1 = new Pedido(cliente1);

pedido1.AdicionarProduto(new Produto("Notebook", "P001", 850.00, 1));
pedido1.AdicionarProduto(new Produto("Mouse", "P002", 25.00, 2));
pedido1.AdicionarProduto(new Produto("Teclado", "P003", 45.00, 1));


Endereco endereco2 = new Endereco(
    "Avenida Boa Viagem, 1000",
    "Recife",
    "Pernambuco",
    "Brasil"
);

Cliente cliente2 = new Cliente("Mariana Santos", endereco2);

Pedido pedido2 = new Pedido(cliente2);

pedido2.AdicionarProduto(new Produto("Monitor", "P004", 300.00, 1));
pedido2.AdicionarProduto(new Produto("Fone de Ouvido", "P005", 50.00, 2));


Console.WriteLine("===== PEDIDO 1 =====");
Console.WriteLine(pedido1.ObterEtiquetaEmbalagem());
Console.WriteLine(pedido1.ObterEtiquetaEnvio());
Console.WriteLine($"Total: ${pedido1.CalcularTotal():F2}");

Console.WriteLine();
Console.WriteLine("====================");
Console.WriteLine();

Console.WriteLine("===== PEDIDO 2 =====");
Console.WriteLine(pedido2.ObterEtiquetaEmbalagem());
Console.WriteLine(pedido2.ObterEtiquetaEnvio());
Console.WriteLine($"Total: ${pedido2.CalcularTotal():F2}");