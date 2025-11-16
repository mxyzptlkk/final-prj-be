using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SK.FinalP.Domain.Entities;

namespace SK.FinalP.Infrastructure.Persistence.Context;

public class BaseEntityDetailConfig<T> : IEntityTypeConfiguration<T> 
    where T : BaseEntityDetail
{
    public void Configure(EntityTypeBuilder<T> builder)
    {
        builder.Property(x => x.ProposalId)
            .IsRequired();
        builder.Property(x => x.AssetId)
            .IsRequired();

        builder.HasOne(x => x.Asset)
            .WithMany()
            .HasForeignKey(x => x.AssetId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
