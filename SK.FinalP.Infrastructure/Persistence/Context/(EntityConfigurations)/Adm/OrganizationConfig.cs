using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SK.FinalP.Domain.Entities;

namespace SK.FinalP.Infrastructure.Persistence.Context;

public class OrganizationConfig : IEntityTypeConfiguration<Adm_Organization>
{
    public void Configure(EntityTypeBuilder<Adm_Organization> builder)
    {
        builder.ToTable("Adm_Organization");
        builder.Property(x => x.Code)
            .IsRequired()
            .HasMaxLength(50);
        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(100);
        builder.Property(x => x.Level)
            .IsRequired();
    }
}
