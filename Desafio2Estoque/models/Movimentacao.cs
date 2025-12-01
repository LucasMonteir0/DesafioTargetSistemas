using DesafioTargetSistemas.Desafio2Estoque.enums;

namespace DesafioTargetSistemas.Desafio2Estoque.models
{
    public class Movimentacao(int id, int codigoProduto, string? descricaoProduto, string? descricaoMovimentacao, TipoMovimentacao tipo, int quantidade, int estoqueFinal)
    {
        public int Id { get; } = id;
        public int CodigoProduto { get; } = codigoProduto;
        public string? DescricaoProduto { get; } = descricaoProduto;
        public string? DescricaoMovimentacao { get; } = descricaoMovimentacao;
        public TipoMovimentacao Tipo { get; } = tipo;
        public int Quantidade { get; } = quantidade;
        public int EstoqueFinal { get; } = estoqueFinal;
        public DateTime DataMovimentacao { get; } = DateTime.Now;
    }

     public void ExibirDetalhes()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n=======================================================");
            Console.WriteLine($"Movimentação ID: {Id}");
            Console.WriteLine($"Data/Hora: {DataMovimentacao.ToString("dd/MM/yyyy HH:mm:ss")}");
            Console.WriteLine($"Produto: {DescricaoProduto} (Cod: {CodigoProduto})");
            // Exibe o nome do enum como string
            Console.WriteLine($"Tipo: {Tipo.ToString().ToUpper()} | Descrição: {DescricaoMovimentacao}");
            Console.WriteLine($"Quantidade Movimentada: {Quantidade}");
            Console.WriteLine($"ESTOQUE FINAL: {EstoqueFinal}");
            Console.WriteLine("=======================================================");
            Console.ResetColor();
        }
    }