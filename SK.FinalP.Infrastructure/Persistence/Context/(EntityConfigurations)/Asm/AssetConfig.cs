using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SK.FinalP.Domain.Entities;

namespace SK.FinalP.Infrastructure.Persistence.Context;

public class AssetConfig : IEntityTypeConfiguration<Asm_Asset>
{
    public void Configure(EntityTypeBuilder<Asm_Asset> builder)
    {
        builder.ToTable("Asm_Asset");
        builder.Property(x => x.Code)
            .IsRequired()
            .HasMaxLength(50);
        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(200);
        builder.Property(x => x.Status)
            .IsRequired();
        builder.Property(x => x.CategoryId)
            .IsRequired();
        builder.Property(x => x.OwnerId)
            .IsRequired();

        builder.HasOne(x => x.Category)
            .WithMany()
            .HasForeignKey(x => x.CategoryId)
            .OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(x => x.Owner)
            .WithMany()
            .HasForeignKey(x => x.OwnerId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
