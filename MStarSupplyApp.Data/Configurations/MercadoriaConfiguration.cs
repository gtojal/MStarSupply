using MStarSupplyApp.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MStarSupplyApp.Data.Configurations
{
    public class MercadoriaConfiguration : IEntityTypeConfiguration<Mercadoria>
    {
        public void Configure(EntityTypeBuilder<Mercadoria> builder)
        {
            builder.ToTable("MERCADORIA");

            builder.HasKey(m => m.Id);

            builder.Property(m => m.Id)
                .HasColumnName("ID");

            builder.Property(m => m.Nome)
                .HasColumnName("NOME")
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(m => m.NumeroRegistro)
                .HasColumnName("NUMEROREGISTRO")
                .IsRequired();

            builder.Property(m => m.Fabricante)
                .HasColumnName("FABRICANTE")
                .HasMaxLength(100)
                .IsRequired();


            builder.Property(m => m.Tipo)
                .HasColumnName("TIPO")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(m => m.Descricao)
                .HasColumnName("DESCRICAO")
                .HasMaxLength(500)
                .IsRequired();

        }
    }
}
