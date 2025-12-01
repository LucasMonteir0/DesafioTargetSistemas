using System.Globalization;

public class Program
{
    public static void Main(string[] args)
    {
        CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("pt-BR");
        CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("pt-BR");

        bool sair = false;
        while (!sair)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("=============================================");
            Console.WriteLine("    Desafios Técnicos em C# - Menu Principal");
            Console.WriteLine("=============================================");
            Console.ResetColor();
            Console.WriteLine("\nSelecione o desafio que deseja executar:");
            Console.WriteLine("1. Calculadora de Comissões de Vendas (Desafio 1)");
            Console.WriteLine("2. Sistema de Movimentação de Estoque (Desafio 2)");
            Console.WriteLine("3. Calculadora de Multa e Juros por Atraso (Desafio 3)");
            Console.WriteLine("0. Sair");
            Console.Write("\nDigite a opção: ");

            string? input = Console.ReadLine();
            Console.WriteLine();

            switch (input)
            {
                case "1":
                    Desafio1Comissao.Executar();
                    break;
                case "2":
                    
                    break;
                case "3":
            
                    break;
                case "0":
                    sair = true;
                    Console.WriteLine("Saindo do programa. Até mais!");
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Opção inválida. Pressione qualquer tecla para tentar novamente.");
                    Console.ResetColor();
                    Console.ReadKey();
                    break;
            }

            if (!sair)
            {
                Console.WriteLine("\nPressione qualquer tecla para voltar ao Menu Principal...");
                Console.ReadKey();
            }
        }
    }
}