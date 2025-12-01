using System.Text.Json.Serialization;

namespace DesafioTargetSistemas.Desafio1Comissao.models
{
    public class Venda
    {
        [JsonPropertyName("vendedor")]
        public string? Vendedor { get; set; }

        [JsonPropertyName("valor")]
        public decimal Valor { get; set; }
    }
}