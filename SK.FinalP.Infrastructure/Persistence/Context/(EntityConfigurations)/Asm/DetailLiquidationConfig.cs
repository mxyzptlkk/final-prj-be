using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SK.FinalP.Domain.Entities;

namespace SK.FinalP.Infrastructure.Persistence.Context;

public class DetailLiquidationConfig : IEntityTypeConfiguration<Asm_DetailLiquidation>
{
    public void Configure(EntityTypeBuilder<Asm_DetailLiquidation> builder)
    {
        builder.ToTable("Asm_DetailLiquidation");
    }
}
