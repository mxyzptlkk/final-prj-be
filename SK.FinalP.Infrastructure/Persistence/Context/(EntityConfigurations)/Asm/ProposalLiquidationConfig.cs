using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SK.FinalP.Domain.Entities;

namespace SK.FinalP.Infrastructure.Persistence.Context;

public class ProposalLiquidationConfig : IEntityTypeConfiguration<Asm_ProposalLiquidation>
{
    public void Configure(EntityTypeBuilder<Asm_ProposalLiquidation> builder)
    {
        builder.ToTable("Asm_ProposalLiquidation");

        builder.HasMany(x => x.Details)
            .WithOne()
            .HasForeignKey(x => x.ProposalId);
    }
}
