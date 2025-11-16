using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SK.FinalP.Application.Interfaces;
using SK.FinalP.Domain.Repositories;
using SK.FinalP.Infrastructure.Persistence.Caches;
using SK.FinalP.Infrastructure.Persistence.Context;
using SK.FinalP.Infrastructure.Persistence.Repositories;

namespace SK.FinalP.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("Default");

        services.AddDbContext<AppDbContext>(options =>
        {
            options.UseNpgsql(connectionString);
        });

        services
            .AddScoped<IUserRepository, UserRepository>()
            .AddScoped<IProposalAcquisitionRepository, ProposalAcquisitionRepository>()
            .AddScoped<IProposalHandoverRepository, ProposalHandoverRepository>()
            .AddScoped<IProposalTransferRepository, ProposalTransferRepository>()
            .AddScoped<IProposalLiquidationRepository, ProposalLiquidationRepository>();

        services
            .AddSingleton<IUserCache, UserCache>();

        return services;
    }
}
