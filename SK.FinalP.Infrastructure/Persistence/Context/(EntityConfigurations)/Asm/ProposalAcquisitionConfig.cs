using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SK.FinalP.Domain.Entities;

namespace SK.FinalP.Infrastructure.Persistence.Context;

public class ProposalAcquisitionConfig : IEntityTypeConfiguration<Asm_ProposalAcquisition>
{
    public void Configure(EntityTypeBuilder<Asm_ProposalAcquisition> builder)
    {
        builder.ToTable("Asm_ProposalAcquisition");

        builder.HasMany(x => x.Details)
            .WithOne()
            .HasForeignKey(x => x.ProposalId);
    }
}
