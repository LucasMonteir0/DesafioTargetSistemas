using System.Text.Json;
using System.Globalization;
using System.Text.Json.Serialization;

public class Desafio1Comissao
{
    private class Venda
    {
        [JsonPropertyName("vendedor")]
        public string? Vendedor { get; set; }

        [JsonPropertyName("valor")]
        public decimal Valor { get; set; }
    }

    private class DadosVendas
    {
        [JsonPropertyName("vendas")]
        public List<Venda>? Vendas { get; set; }
    }

    private static decimal CalcularComissaoPorVenda(decimal valorVenda)
    {
        if (valorVenda < 100.00m)
        {
            return 0.00m;
        }
        else if (valorVenda < 500.00m)
        {
            return valorVenda * 0.01m;
        }
        else
        {
            return valorVenda * 0.05m;
        }
    }


    public static void Executar()
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("--- Desafio 1: Cálculo de Comissões de Vendas ---");
        Console.ResetColor();
        string jsonContent;
        const string filePath = "Desafio1Comissao/dados.json";

        try
        {
            Console.WriteLine("Lendo dados, aguarde um momento");
            jsonContent = File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), filePath));
        }
        catch (FileNotFoundException)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"ERRO: Arquivo '{filePath}' não encontrado.");
            Console.WriteLine("Por favor, crie o arquivo dados.json na pasta de execução do programa com o conteúdo JSON fornecido.");
            Console.ResetColor();
            return;
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Ocorreu um erro ao ler o arquivo '{filePath}': {ex.Message}");
            Console.ResetColor();
            return;
        }

        try
        {
            var dados = JsonSerializer.Deserialize<DadosVendas>(jsonContent);

            if (dados?.Vendas == null || dados.Vendas.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Erro: Não foi possível carregar os dados de vendas ou a lista está vazia.");
                Console.ResetColor();
                return;
            }

            var comissaoTotalPorVendedor = new Dictionary<string, decimal>();

            foreach (var venda in dados.Vendas)
            {
                if (string.IsNullOrWhiteSpace(venda.Vendedor)) continue;

                decimal comissao = CalcularComissaoPorVenda(venda.Valor);

                if (comissaoTotalPorVendedor.ContainsKey(venda.Vendedor))
                {
                    comissaoTotalPorVendedor[venda.Vendedor] += comissao;
                }
                else
                {
                    comissaoTotalPorVendedor.Add(venda.Vendedor, comissao);
                }
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nCálculo de Comissões por Vendedor:");
            Console.WriteLine("-----------------------------------");
            Console.ResetColor();

            foreach (var kvp in comissaoTotalPorVendedor.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{kvp.Key,-18}: {kvp.Value.ToString("C", CultureInfo.DefaultThreadCurrentCulture)}");
            }
            Console.WriteLine("-----------------------------------");
            Console.WriteLine($"Total de Vendas Processadas: {dados.Vendas.Count}");

        }
        catch (JsonException ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Erro ao desserializar o JSON: {ex.Message}");
            Console.ResetColor();
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Ocorreu um erro inesperado: {ex.Message}");
            Console.ResetColor();
        }
    }
}