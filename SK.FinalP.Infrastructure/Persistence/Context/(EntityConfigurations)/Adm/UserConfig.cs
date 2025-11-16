using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SK.FinalP.Domain.Entities;

namespace SK.FinalP.Infrastructure.Persistence.Context;

public class UserConfig : IEntityTypeConfiguration<Adm_User>
{
    public void Configure(EntityTypeBuilder<Adm_User> builder)
    {
        builder.ToTable("Adm_User");
        builder.Property(x => x.UserName)
            .IsRequired()
            .HasMaxLength(50);
        builder.Property(x => x.UserName)
            .IsRequired()
            .HasMaxLength(100);
        builder.Property(x => x.PasswordHash)
            .IsRequired()
            .HasMaxLength(500);
        builder.Property(x => x.IsActive)
            .IsRequired()
            .HasDefaultValue(true);

        builder.HasOne<Adm_Organization>()
            .WithMany()
            .HasForeignKey(x => x.OrganizationID)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
