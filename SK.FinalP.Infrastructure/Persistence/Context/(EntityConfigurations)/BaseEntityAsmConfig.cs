using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SK.FinalP.Domain.Entities;

namespace SK.FinalP.Infrastructure.Persistence.Context;

public class BaseEntityAsmConfig<T> : IEntityTypeConfiguration<T> where T : BaseEntityAsm
{
    public void Configure(EntityTypeBuilder<T> builder)
    {
        builder.Property(x => x.CreatedBy)
            .IsRequired();

        builder.HasOne(x => x.CreatedByUser)
            .WithMany()
            .HasForeignKey(x => x.CreatedBy)
            .OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(x => x.LastUpdatedByUser)
            .WithMany()
            .HasForeignKey(x => x.LastUpdatedBy)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
