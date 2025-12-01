using System.Text.Json;
using System.Globalization;
using System.Text.Json.Serialization;
using DesafioTargetSistemas.commons;
using DesafioTargetSistemas.Desafio1Comissao.models;


namespace DesafioTargetSistemas.Desafio1Comissao;

public class Desafio1Comissao
{

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
        const string filePath = "Desafio1Comissao/dados.json";        
 
        try
        {
            var dados = FileHelper.ConverterParaJson<DadosVendas>(filePath);

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

                if (!comissaoTotalPorVendedor.TryAdd(venda.Vendedor, comissao))
                {
                    comissaoTotalPorVendedor[venda.Vendedor] += comissao;
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