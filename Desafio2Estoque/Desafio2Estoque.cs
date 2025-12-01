using System.Text.Json;
using System.Text.Json.Serialization;
using DesafioTargetSistemas.commons;
using DesafioTargetSistemas.Desafio2Estoque.enums;
using DesafioTargetSistemas.Desafio2Estoque.models;

public class Desafio2Estoque
{
    private static List<Produto> _estoque = [];

    private static int _contadorMovimentacao = 1;
    private static readonly List<Movimentacao> _historicoMovimentacoes = [];


    private static void CarregarEstoqueInicial()
    {
        const string filePath = "Desafio2Estoque/dados.json";


        if (_estoque.Count == 0)
        {
            var dados = FileHelper.ConverterParaJson<DadosDesafio2>(filePath);

            if (dados?.Estoque == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Erro: Não foi possível carregar os dados do estoque.");
                Console.ResetColor();
                return;
            }

            _estoque = dados.Estoque;

            Console.WriteLine("Estoque inicial carregado com sucesso.");
        }
    }

    private static void RealizarMovimentacao()
    {
        Console.WriteLine("\n--- Realizar Nova Movimentação ---");

        ExibirEstoqueAtual();
        Console.Write("Digite o Código do Produto para movimentar: ");
        if (!int.TryParse(Console.ReadLine(), out int codigo))
        {
            Console.WriteLine("Código inválido.");
            return;
        }

        var produto = _estoque.FirstOrDefault(p => p.CodigoProduto == codigo);
        if (produto == null)
        {
            Console.WriteLine($"Produto com código {codigo} não encontrado.");
            return;
        }

        Console.Write("Digite o Tipo de Movimentação (E para Entrada / S para Saída): ");
        string? tipoInput = Console.ReadLine()?.ToUpper();

        TipoMovimentacao tipoMovimentacao;

        if (tipoInput == "E")
        {
            tipoMovimentacao = TipoMovimentacao.Entrada;
        }
        else if (tipoInput == "S")
        {
            tipoMovimentacao = TipoMovimentacao.Saida;
        }
        else
        {
            Console.WriteLine("Tipo de movimentação inválido. Use 'E' ou 'S'.");
            return;
        }

        Console.Write("Digite a Descrição da Movimentação: ");
        string? descricao = Console.ReadLine();

        Console.Write("Digite a Quantidade a movimentar: ");
        if (!int.TryParse(Console.ReadLine(), out int quantidade) || quantidade <= 0)
        {
            Console.WriteLine("Quantidade inválida. Deve ser um número inteiro positivo.");
            return;
        }

        int novoEstoque = produto.Estoque;

        if (tipoMovimentacao == TipoMovimentacao.Entrada)
        {
            novoEstoque += quantidade;
        }
        {
            if (produto.Estoque < quantidade)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"Atenção: Estoque insuficiente ({produto.Estoque}). Movimentação cancelada.");
                Console.ResetColor();
                return;
            }
            novoEstoque -= quantidade;
        }

        produto.Estoque = novoEstoque;

        var novaMovimentacao = new Movimentacao(
            _contadorMovimentacao++,
            produto.CodigoProduto,
            produto.DescricaoProduto,
            descricao,
            tipoMovimentacao, 
            quantidade,
            produto.Estoque
        );

        _historicoMovimentacoes.Add(novaMovimentacao);

        novaMovimentacao.ExibirDetalhes();
    }

    private static void ExibirEstoqueAtual()
    {
        Console.WriteLine("\n--- Estoque Atual ---");
        Console.WriteLine($"{"Código",-10} {"Descrição",-30} {"Estoque",-10}");
        Console.WriteLine(new string('-', 50));
        foreach (var p in _estoque.OrderBy(p => p.CodigoProduto))
        {
            Console.WriteLine($"{p.CodigoProduto,-10} {p.DescricaoProduto,-30} {p.Estoque,-10}");
        }
        Console.WriteLine(new string('-', 50));
    }

    public static void Executar()
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("--- Desafio 2: Sistema de Movimentação de Estoque ---");
        Console.ResetColor();

        CarregarEstoqueInicial();

        bool voltar = false;
        while (!voltar)
        {
            Console.WriteLine("\nMenu de Estoque:");
            Console.WriteLine("1. Realizar Movimentação (Entrada/Saída)");
            Console.WriteLine("2. Exibir Estoque Atual");
            Console.WriteLine("0. Voltar ao Menu Principal");
            Console.Write("\nDigite a opção: ");

            string? input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    RealizarMovimentacao();
                    break;
                case "2":
                    ExibirEstoqueAtual();
                    break;
                case "0":
                    voltar = true;
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Opção inválida.");
                    Console.ResetColor();
                    break;
            }
        }
    }
}