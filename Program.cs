using BlackFriday;

internal class Program
{
    private static void Main()
    {
        List<Produto> listaProdutos = new List<Produto> {
            new Produto {
                Nome = "Notebook Dell",
                Preco = 2834.53
            },
            new Produto {
                Nome = "Teclado Microsoft",
                Preco = 148.00
            }
        };

        Console.Clear();
        Console.WriteLine("Bem-vindo a BlackFriday do Eduardo Store");
        Console.WriteLine("Os produtos abaixo, sofreram alteraçções em seus valores:");
        ListarProdutos(listaProdutos);
        EscolheProduto(listaProdutos);  
    }

    private static void ListarProdutos(List<Produto> listaProdutos)
    {
        foreach (var produto in listaProdutos)
        {
            Console.WriteLine($"- {produto.Nome}: ${produto.Preco.ToString("N2")}");
        }
    }

    private static void EscolheProduto(List<Produto> listaProdutos)
    {
        Produto? produtoEscolhido;
        Console.WriteLine("\nFicou interassado ? Digite o valor para descobrir o desconto.");
        Console.WriteLine("**Caso deseja sair, digite '00'**");
        
        do
        {
            var usuarioPreco = Console.ReadLine();

            if(usuarioPreco == null || usuarioPreco == "")
                Main();

            if(usuarioPreco == "00")
                return;
            
            produtoEscolhido = listaProdutos.Where(p => p.Preco == Convert.ToDouble(usuarioPreco)).FirstOrDefault();

            if (produtoEscolhido == null)
            {
                Console.WriteLine("Produto não encontrado. Tente novamente, caso deseje sair digite '00'");
            }
            else
            {
                double valorProdutoComDesconto = produtoEscolhido.Preco * 0.6;
                double valorDesconto = produtoEscolhido.Preco - valorProdutoComDesconto;
                ListarDesconto(produtoEscolhido, valorProdutoComDesconto, valorDesconto);
                UsuarioDesejaContinuar();
            }
        } while (produtoEscolhido == null);
    }

    private static void ListarDesconto(Produto produtoEscolhido, double valorProdutoComDesconto, double valorDesconto)
    {
        Console.WriteLine($"Produto Escolhido: {produtoEscolhido.Nome}");
        Console.WriteLine($"Valor original: {produtoEscolhido.Preco.ToString("N2")}");
        Console.WriteLine($"Com o desconto: {valorProdutoComDesconto.ToString("N2")}");
        Console.WriteLine($"Valor do desconto: {valorDesconto.ToString("N2")}");
        Console.WriteLine("\nDeseja verificar outro produto ? " +
                            "\nY - Sim" +
                            "\nN - Não");
    }

    private static void UsuarioDesejaContinuar()
    {
        ConsoleKeyInfo escolhaUsuario = new();
        do
        {
            escolhaUsuario = Console.ReadKey();
            
            if(escolhaUsuario.Key.ToString().ToLower() == "y")
                Main();
            else if(escolhaUsuario.Key.ToString().ToLower() == "n" ||
                    escolhaUsuario.Key.ToString().ToLower() == "escape")
                return;
            else if(escolhaUsuario.Key.ToString().ToLower() != "enter"
                && escolhaUsuario.Key.ToString().ToLower() != "backspace"){
                Console.WriteLine("\nDesculpe não entendi. Tecle novamente");
                UsuarioDesejaContinuar();
            }
        } while (escolhaUsuario.Key.ToString().ToLower() == "enter" || escolhaUsuario.Key.ToString().ToLower() == "backspace");
      
    }
}