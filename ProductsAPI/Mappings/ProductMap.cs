using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductsAPI.Entities;

namespace ProductsAPI.Mappings
{
    /// <summary>
    /// Classe de mapemaento para a entidade Product
    /// </summary>
    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("PRODUCTS");//Nome da tabela do banco de dados.

            builder.HasKey(p => p.Id);//Chave primária da tabela.

            builder.Property(p => p.Id)
                .HasColumnName("ID");//nome do campo na tabela

            builder.Property(p => p.Name)
                .HasColumnName("NAME")//nome do campo na tabela
                .HasMaxLength(100)//maximo de caracteres
                .IsRequired();//campo obrigatório

            builder.Property(p => p.Price)
                .HasColumnName("PRICE")//nome do campo na tabela
                .HasColumnType("decimal(10,2)")//tipo de dado e tamanho
                .IsRequired();//campo obrigatório

            builder.Property(p => p.Quantity)
                .HasColumnName("QUANTITY")//nome do campo na tabela
                .IsRequired();//campo obrigatório

            builder.Property(p => p.CategoryId)
                .HasColumnName("CATEGORY_ID")//nome do campo na tabela
                .IsRequired();//campo obrigatório

            builder.HasOne(p => p.Category)//Product tem 1 Category
                .WithMany(c => c.Products)//Category tem muitos Products
                .HasForeignKey(p => p.CategoryId);//chave estrangeira do relacinamento
        }
    }
}
