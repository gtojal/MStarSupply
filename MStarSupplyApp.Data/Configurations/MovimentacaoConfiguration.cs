using MStarSupplyApp.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MStarSupplyApp.Data.Configurations
{
    public class MovimentacaoConfiguration : IEntityTypeConfiguration<Movimentacao>
    {
        public void Configure(EntityTypeBuilder<Movimentacao> builder)
        {
            builder.ToTable("MOVIMENTACAO");

            builder.HasKey(m => m.Id);

            builder.Property(m => m.Id)
                .HasColumnName("ID");

            builder.Property(m => m.Quantidade)
                .HasColumnName("QUANTIDADE")
                .IsRequired();

            builder.Property(m => m.DataHora)
                .HasColumnName("DATAHORA")
                .IsRequired();

            builder.Property(m => m.Local)
                .HasColumnName("LOCAL")
                .IsRequired();

            builder.Property(m => m.MercadoriaId)
                .HasColumnName("MERCADORIAID")
                .IsRequired();

            builder.Property(m => m.Tipo)
                .HasColumnName("TIPO")
                .IsRequired();

            builder.HasOne(m => m.Mercadoria)
                .WithMany(m => m.Movimentacoes)
                .HasForeignKey(m => m.MercadoriaId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
