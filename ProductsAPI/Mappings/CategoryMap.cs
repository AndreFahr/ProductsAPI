using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductsAPI.Entities;

namespace ProductsAPI.Mappings
{
    /// <summary>
    /// Classe de mapeamento para a entidade Category.
    /// </summary>
    public class CategoryMap : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("CATEGORIES");//Nome da tabela do banco de dados.

            builder.HasKey(c => c.Id);//Chave primária da tabela.

            builder.Property(c => c.Id)
                .HasColumnName("ID");//nome do campo na tabela  

            builder.Property(c => c.Name)
                .HasColumnName("NAME")//nome do campo na tabela
                .HasMaxLength(50)//maximo de caracteres
                .IsRequired();//campo obrigatório

            builder.HasIndex(c => c.Name)//criando um indice para o campo
                .IsUnique();//configurando como campo unico( nao pode ter valor repetido)

        }
    }
}
