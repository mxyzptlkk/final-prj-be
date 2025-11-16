using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SK.FinalP.Domain.Entities;

namespace SK.FinalP.Infrastructure.Persistence.Context;

public class CategoryConfig : IEntityTypeConfiguration<Asm_Category>
{
    public void Configure(EntityTypeBuilder<Asm_Category> builder)
    {
        builder.ToTable("Asm_Category");
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
