using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SK.FinalP.Domain.Entities;
using SK.FinalP.Shared;

namespace SK.FinalP.Infrastructure.Persistence.Context;

public class BaseEntityConfig<T> : IEntityTypeConfiguration<T> where T : BaseEntity
{
    public void Configure(EntityTypeBuilder<T> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.CreatedAt)
            .IsRequired()
            .HasDefaultValueSql("now()");
        builder.Property(x => x.Version)
            .IsRequired()
            .HasDefaultValue(Consts.InitialVersion);
        builder.Property(x => x.IsNotDeleted)
            .IsRequired(true);
    }
}
