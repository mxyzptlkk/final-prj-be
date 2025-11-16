using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SK.FinalP.Domain.Entities;

namespace SK.FinalP.Infrastructure.Persistence.Context;

public class DetailAcquisitionConfig : IEntityTypeConfiguration<Asm_DetailAcquisition>
{
    public void Configure(EntityTypeBuilder<Asm_DetailAcquisition> builder)
    {
        builder.ToTable("Asm_DetailAcquisition");
    }
}
