using Microsoft.EntityFrameworkCore;
using ProductsAPI.Contexts;
using ProductsAPI.DTOs;
using ProductsAPI.Entities;

namespace ProductsAPI.Repositories
{
    public class ProductRepository
    {
        //metodo para gravar um product no banco de dados.
        public void Add(Product product)
        {
            using(var dataContext = new DataContext())
            {
                dataContext.Add(product);
                dataContext.SaveChanges();
            }
        }

        //metodo para atualizar um product no banco de dados.
        public void Update(Product product)
        {
            using (var dataContext = new DataContext())
            {
                dataContext.Update(product);
                dataContext.SaveChanges();
            }
        }

        //metodo para excluir um product no banco de dados.
        public void Delete(Product product)
        {
            using (var dataContext = new DataContext())
            {
                dataContext.Remove(product);
                dataContext.SaveChanges();
            }
        }

        //metodo para consultar todos os products cadastrados no banco de dados.
        public List<Product> GetAll()
        {
            using (var dataContext = new DataContext())
            {
                return dataContext
                    .Set<Product>()
                    .Include(p => p.Category) //JOIN
                    .OrderBy(p => p.Name)
                    .ToList();
            }
        }

        //metodo para consultar 1 product atraves do Id.
        public Product? GetById(Guid id)
        {
            using (var dataContext = new DataContext())
            {
                return dataContext
                    .Set<Product>()
                    .Find(id);
            }
        }

        //metoda para consultar o somatorio da quantidade de produtos para cada categoria.
        public List<CategoryProductsResponseDto> GroupByCategoria()
        {
            using(var dataContext = new DataContext())
            {
              return dataContext
                    .Set<Product>()//tabela de produtos
                    .Include(p => p.Category)//juncao com a tabela de categorias
                    .GroupBy(p => p.Category.Name)//agrupando pelo nome da categoria
                    .Select(g => new CategoryProductsResponseDto
                    {
                        Category = g.Key,//nome da categoria
                        Products = g.Sum(p => p.Quantity)//somatorio da quantidade de produtos
                    })
                    .ToList();//retornar uma lista do DTO

            }
        }
    }
}
