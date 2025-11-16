using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SK.FinalP.Domain.Entities;

namespace SK.FinalP.Infrastructure.Persistence.Context;

public class BaseEntityProposalConfig<T> : IEntityTypeConfiguration<T> 
    where T : BaseEntityProposal
{
    public void Configure(EntityTypeBuilder<T> builder)
    {
        builder.HasOne(x => x.RequestedByUser)
            .WithMany()
            .HasForeignKey(x => x.RequestedBy)
            .OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(x => x.ApprovedByUser)
            .WithMany()
            .HasForeignKey(x => x.ApprovedBy)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
