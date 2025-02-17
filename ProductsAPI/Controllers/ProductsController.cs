using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductsAPI.DTOs;
using ProductsAPI.Entities;
using ProductsAPI.Repositories;

namespace ProductsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        /// <summary>
        /// Servico para cadastro de produto da API.
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post([FromBody] ProductRequestDto request)
        {
            //criando um objeto da classe produto.
            var product = new Product
            {
                Id= Guid.NewGuid(),//Gerando o Id
                Name = request.Name,//Capturando o nome do produto
                Price = request.Price,//Capturando o preco do produto
                Quantity = request.Quantity,//Capturando a quantidade do produto
                CategoryId = request.CategoryId//Capturando o Id da categoria
            };

            //criando um objeto da classe do repositorio
            var productRepository = new ProductRepository();
            productRepository.Add(product);//Gravando o produto no banco de dados

            //Retornar o status de sucesso na API(Http - 200 OK)
            return Ok(new
            {
                Message = "Produto cadastrado com sucesso!",//mensagem de sucesso
                CreatedAt = DateTime.Now,//data e hora do cadastro
                ProductId = product.Id,//Id do produto cadastrado
            });
            }

        /// <summary>
        /// Servico para atualizacao de produto da API.
        /// </summary>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult Put(Guid id , [FromBody] ProductRequestDto request)
        {
            //Criando um objeto para a classe do repositorio
            var productRepository = new ProductRepository();
            //Consultar o produto no banco de dados atraves do Id
            var product = productRepository.GetById(id);

            //Modificando os dados do produto com as informacoes da requisicao
            product.Name = request.Name;
            product.Price = request.Price;
            product.Quantity = request.Quantity;
            product.CategoryId = request.CategoryId;

            //Atualizar o produto no banco de dados
            productRepository.Update(product);

            //Retornando os dados da resposta
            return Ok(new{
                Message = "Produto atualizado com sucesso!",//mensagem de sucesso
                UpdateAt = DateTime.Now,//data e hora da atualizacao
                ProductId = id,//Id do produto que foi atualizado
            });
        }

        /// <summary>
        /// Servico para exclusao de produto da API.
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            //Criando um objeto para a classe do repositorio
            var productRepository = new ProductRepository();
            //Consultar o produto no banco de dados atraves do Id
            var product = productRepository.GetById(id);

            //Excluir o produto no banco de dados
            productRepository.Delete(product);

            //retornando os dados da resposta
            return Ok(new
            {
                Message = "Produto excluido com sucesso!",//mensagem de sucesso
                UpdateAt = DateTime.Now,//data e hora da exclusao
                ProductId = id,//Id do produto que foi excluido

            });
        }

        /// <summary>
        /// Servico para consulta de produto da API.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            //Criando um objeto para a classe do repositorio
            var productRepository = new ProductRepository();
            //consultar todos os produtos da base de dados
            var products = productRepository.GetAll();

            //criando uma lista da classe DTO
            var response = new List<ProductResponseDto>();

            //percorrendo cada produto obtido do banco de dados
            foreach (var product in products)
            {
                //adicionando cada registro na lista como um DTO
                response.Add(new ProductResponseDto
                {
                    Id = product.Id,//preenchendo Id do produto
                    Name = product.Name,//preenchendo Nome do produto
                    Price = product.Price,//preenchendo Preco do produto
                    Quantity = product.Quantity,//preenchendo Quantidade do produto
                    CategoryId = product.Category?.Id,//preenchendo Id da categoria
                    CategoryName = product.Category?.Name//preenchendo Nome da categoria
                });

            }
                //retornar os dados
                return Ok(response);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            //Criando um objeto para a classe do repositorio
            var productRepository = new ProductRepository();
            //Consultar o produto no banco de dados atraves do Id
            var product = productRepository.GetById(id);

            //criando um objeto da classe DTO para retornar os dados do produto
            var response = new ProductResponseDto
            {
                Id = product.Id,//preenchendo Id do produto
                Name = product.Name,//preenchendo Nome do produto
                Price = product.Price,//preenchendo Preco do produto
                Quantity = product.Quantity,//preenchendo Quantidade do produto
                CategoryId = product.CategoryId,//preenchendo Id da categoria
            };

            //retornar os dados do Dto
            return Ok(response);

        }
    }
}
