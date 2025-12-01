using System.Text.Json.Serialization;
namespace DesafioTargetSistemas.Desafio2Estoque.models

{
    public class DadosDesafio2
    {
        [JsonPropertyName("estoque")]
        public List<Produto>? Estoque { get; set; }
    }
}