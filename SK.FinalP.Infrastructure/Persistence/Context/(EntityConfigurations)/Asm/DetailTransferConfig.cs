using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SK.FinalP.Domain.Entities;

namespace SK.FinalP.Infrastructure.Persistence.Context;

public class DetailTransferConfig : IEntityTypeConfiguration<Asm_DetailTransfer>
{
    public void Configure(EntityTypeBuilder<Asm_DetailTransfer> builder)
    {
        builder.ToTable("Asm_DetailTransfer");
    }
}
