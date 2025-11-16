using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SK.FinalP.Domain.Entities;

namespace SK.FinalP.Infrastructure.Persistence.Context;

public class ProposalHandoverConfig : IEntityTypeConfiguration<Asm_ProposalHandover>
{
    public void Configure(EntityTypeBuilder<Asm_ProposalHandover> builder)
    {
        builder.ToTable("Asm_ProposalHandover");

        builder.HasMany(x => x.Details)
            .WithOne()
            .HasForeignKey(x => x.ProposalId);
    }
}
