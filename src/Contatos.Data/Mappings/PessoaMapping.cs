
using Contatos.Data.Extensions;
using Contatos.Dominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Contatos.Data.Mappings
{
   public class PessoaMapping:EntityTypeConfiguration<Pessoa>
    {
        public override void Map(EntityTypeBuilder<Pessoa> builder)
        {

            builder.Property(e => e.Nome)
                .HasColumnType("varchar(300)")
                .IsRequired();

            builder.Property(e => e.Telefone)
                 .HasColumnType("varchar(20)")
                 .IsRequired();

            builder.Property(e => e.Email)
            .HasColumnType("varchar(300)")
            .IsRequired();


        

            

            builder.ToTable("PessoasT");

        }
    }
}
