using System.Security.Principal;

namespace ProductsAPI.DTOs
{
    /// <summary>
    /// Modelo de dados( DTO) para retornar uma consulta
    /// de produto nos servicos da API.
    /// </summary>
    public class ProductResponseDto
    {
        public Guid? Id { get; set; }
        public string? Name { get; set; }
        public decimal? Price { get; set; }
        public int? Quantity { get; set; }
        public decimal? Total { get{ return Price * Quantity; } }
        public Guid? CategoryId { get; set; }
        public string? CategoryName { get; set; }

    }
}
