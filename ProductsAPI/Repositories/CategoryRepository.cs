using ProductsAPI.Contexts;
using ProductsAPI.Entities;

namespace ProductsAPI.Repositories
{
    public class CategoryRepository
    {
        //metodo para consultar todas as categorias cadastradas no banco de dados.
        public List<Category> GetAll()
        {
            using (var dataContext = new DataContext())
            {
                return dataContext
                    .Set<Category>()
                    .OrderBy(c => c.Name)
                    .ToList();
            }
        }


    }
}
