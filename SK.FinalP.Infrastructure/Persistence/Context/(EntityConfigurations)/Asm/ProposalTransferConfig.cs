using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SK.FinalP.Domain.Entities;

namespace SK.FinalP.Infrastructure.Persistence.Context;

public class ProposalTransferConfig : IEntityTypeConfiguration<Asm_ProposalTransfer>
{
    public void Configure(EntityTypeBuilder<Asm_ProposalTransfer> builder)
    {
        builder.ToTable("Asm_ProposalTransfer");

        builder.HasMany(x => x.Details)
            .WithOne()
            .HasForeignKey(x => x.ProposalId);
    }
}
