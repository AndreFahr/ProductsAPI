using Microsoft.EntityFrameworkCore;
using ProductsAPI.Mappings;

namespace ProductsAPI.Contexts
{
    /// <summary>
    /// Classe de contexto para o banco de dados
    /// e para configurcao do Entity Framework
    /// </summary>
    public class DataContext : DbContext
    {
        public object Products { get; internal set; }

        //configurando a conexao do banco de dados
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=BDProductsAPI;Integrated Security=True;");
        }

        //metodo para adicionar as classes de mapeamento do projeto
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoryMap());
            modelBuilder.ApplyConfiguration(new ProductMap());
        }
    }

}
