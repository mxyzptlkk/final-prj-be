using System;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using SK.FinalP.Domain.Entities;

namespace SK.FinalP.Infrastructure.Persistence.Context;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Adm_Organization> Organization { get; set; }
    public DbSet<Adm_User> User { get; set; }
    public DbSet<Asm_Asset> Asset { get; set; }
    public DbSet<Asm_ProposalAcquisition> ProposalAcquisition { get; set; }
    public DbSet<Asm_ProposalHandover> ProposalHandover { get; set; }
    public DbSet<Asm_ProposalLiquidation> ProposalLiquidation { get; set; }
    public DbSet<Asm_ProposalTransfer> ProposalTransfer { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Ignore<BaseEntity>();
        modelBuilder.Ignore<BaseEntityAsm>();
        modelBuilder.Ignore<BaseEntityProposal>();
        modelBuilder.Ignore<BaseEntityDetail>();

        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            var clrType = entityType.ClrType;

            if (typeof(BaseEntity).IsAssignableFrom(clrType))
            {
                var configuration = Activator.CreateInstance(
                    typeof(BaseEntityConfig<>).MakeGenericType(clrType));
                modelBuilder.ApplyConfiguration((dynamic)configuration!);
            }

            if (typeof(BaseEntityAsm).IsAssignableFrom(clrType))
            {
                var asmConfiguration = Activator.CreateInstance(
                    typeof(BaseEntityAsmConfig<>).MakeGenericType(clrType));
                modelBuilder.ApplyConfiguration((dynamic)asmConfiguration!);
            }

            if (typeof(BaseEntityProposal).IsAssignableFrom(clrType))
            {
                var proposalConfig = Activator.CreateInstance(
                    typeof(BaseEntityProposalConfig<>).MakeGenericType(clrType));
                modelBuilder.ApplyConfiguration((dynamic)proposalConfig!);
            }

            if (typeof(BaseEntityDetail).IsAssignableFrom(clrType))
            {
                var detailConfig = Activator.CreateInstance(
                    typeof(BaseEntityDetailConfig<>).MakeGenericType(clrType));
                modelBuilder.ApplyConfiguration((dynamic)detailConfig!);
            }
        }

        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            entityType.SetTableName(entityType.GetTableName()!.ToLower());

            foreach (var property in entityType.GetProperties())
            {
                property.SetColumnName(
                    property.GetColumnName(StoreObjectIdentifier.Table(entityType.GetTableName()!, null))!.ToLower()
                );
            }
        }
    }
}
