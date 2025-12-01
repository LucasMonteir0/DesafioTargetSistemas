using System.Text.Json.Serialization;

namespace DesafioTargetSistemas.Desafio2Estoque.models
{
    public class Produto
    {
        [JsonPropertyName("codigoProduto")]
        public int CodigoProduto { get; set; }
        [JsonPropertyName("descricaoProduto")]
        public string? DescricaoProduto { get; set; }
        [JsonPropertyName("estoque")]
        public int Estoque { get; set; }
    }
}