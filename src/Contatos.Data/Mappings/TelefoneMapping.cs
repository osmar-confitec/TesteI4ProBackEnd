
using Contatos.Data.Extensions;
using Contatos.Dominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Contatos.Data.Mappings
{
  public  class TelefoneMapping : EntityTypeConfiguration<Telefone>
    {
        public override void Map(EntityTypeBuilder<Telefone> builder)
        {

            builder.Property(e => e.NumeroTelefone)
              .HasColumnType("varchar(20)")
              .IsRequired();

            builder.HasOne(s => s.Pessoa)
                .WithMany(g => g.Telefones)
                .HasForeignKey(s => s.PessoaId);

            builder.ToTable("TelefonesTel");
        }
    }
}
