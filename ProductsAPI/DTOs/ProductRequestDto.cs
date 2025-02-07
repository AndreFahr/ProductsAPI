using System.ComponentModel.DataAnnotations;

namespace ProductsAPI.DTOs
{
    /// <summary>
    /// Modelo de dados para receber uma solicitacao/requisicao de 
    /// cadastro/atualizacao de dados de produto.
    /// </summary>
    public class ProductRequestDto
    {
        [MaxLength(100, ErrorMessage = "Por favor, informe no maximo {1} caracteres.")]
        [MinLength(8, ErrorMessage = "Por favor, informe no minimo {1} caracteres.")]
        [Required(ErrorMessage = "Por favor, informe o nome do produto.")]
        public string? Name { get; set; }

        [Range(0.01,999999, ErrorMessage = "Por favor, informe um preco entre {1} e {2}.")]
        [Required(ErrorMessage = "Por favor, informe o preco do produto.")]
        public decimal? Price { get; set; }

        [Range(1, 999999, ErrorMessage = "Por favor, informe uma quantidade entre {1} e {2}.")]
        [Required(ErrorMessage = "Por favor, informe a quantidade do produto.")]
        public int? Quantity { get; set; }

        [Required(ErrorMessage = "Por favor, informe a categoria do produto.")]
        public Guid? CategoryId { get; set; }
    }
}
