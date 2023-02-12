using Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Core.Data.EntityConfigs;

public class DividaEntityConfig : IEntityTypeConfiguration<Divida>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Divida> builder)
    {
        builder.ToTable("Divida");

        builder.HasKey(d => d.Id);

        builder.Property(d => d.Valor)
            .IsRequired()
            .HasPrecision(18,2);

        builder.Property(d => d.Situacao);

        builder.Property(d => d.DataPagamento);

        builder.HasOne(d => d.Cliente)
            .WithMany(c => c.Dividas)
            .HasForeignKey(d => d.ClienteId)
            .OnDelete(DeleteBehavior.Cascade);

    }
}