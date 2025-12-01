using System.Text.Json.Serialization;

namespace DesafioTargetSistemas.Desafio1Comissao.models

{
    public class DadosVendas
    {
        [JsonPropertyName("vendas")]
        public List<Venda>? Vendas { get; set; }
    }
}