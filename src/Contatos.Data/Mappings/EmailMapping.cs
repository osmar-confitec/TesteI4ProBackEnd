
using Contatos.Data.Extensions;
using Contatos.Dominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Contatos.Data.Mappings
{
    public class EmailMapping : EntityTypeConfiguration<Email>
    {
        public override void Map(EntityTypeBuilder<Email> builder)
        {



            builder.Property(e => e.EnderecoEmail)
              .HasColumnType("varchar(300)")
              .IsRequired();




            builder.HasOne(s => s.Pessoa)
                .WithMany(g => g.Emails)
                .HasForeignKey(s => s.PessoaId);


            

            builder.ToTable("EmailsT");
        }
    }
}
