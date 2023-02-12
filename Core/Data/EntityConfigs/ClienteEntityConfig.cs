using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Core.Data.EntityConfigs;

public class ClienteEntityConfig : IEntityTypeConfiguration<Cliente>
{
    public void Configure(EntityTypeBuilder<Cliente> builder)
    {
        builder.ToTable("Cliente");

        builder.HasKey(c => c.Id);

        builder.Property(c => c.NomeCompleto)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(c => c.Cpf)
            .IsRequired()
            .HasMaxLength(11);

        builder.Property(c => c.DataNascimento)
            .IsRequired();

        builder.Property(c => c.Email)
            .IsRequired()
            .HasMaxLength(100);
        
    }
}