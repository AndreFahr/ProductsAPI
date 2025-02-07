using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductsAPI.DTOs;
using ProductsAPI.Repositories;

namespace ProductsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        /// <summary>
        /// Servico para consulta de categorias da API.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            //instanciando a classe de repositorio
            var categoryRepository = new CategoryRepository();

            //executando a consulta e obter uma lista de categorias
            var categories = categoryRepository.GetAll();

            //criando uma lista de objetos da classe DTO
            var response = new List<CategoryResponseDto>();

            //percorrer as categorias obtidas do banco de dados
            foreach (var category in categories)
            {
                //adicionando cada registro na lista como um DTO
                response.Add(new CategoryResponseDto
                {
                    Id = category.Id,//preenchendo Id da categoria
                    Name = category.Name//preenchendo Nome da categoria
                });
            }

            //retornando os dados
            return Ok(response);
        }
    }
}
