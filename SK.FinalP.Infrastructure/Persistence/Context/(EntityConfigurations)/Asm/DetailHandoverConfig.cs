using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SK.FinalP.Domain.Entities;

namespace SK.FinalP.Infrastructure.Persistence.Context;

public class DetailHandoverConfig : IEntityTypeConfiguration<Asm_DetailHandover>
{
    public void Configure(EntityTypeBuilder<Asm_DetailHandover> builder)
    {
        builder.ToTable("Asm_DetailHandover");
    }
}
