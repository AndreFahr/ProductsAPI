using ProductsAPI.Contexts;
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
    }
}
