namespace ProductsAPI.DTOs
{
    /// <summary>
    /// Modelo de dados( DTO) para retornar uma consulta
    /// de categorias nos servicos da API.
    /// </summary>
    public class CategoryResponseDto
    {
        public Guid? Id { get; set; }
        public string? Name { get; set; }
    }
}
