using Microsoft.Extensions.DependencyInjection;
using SK.FinalP.Application.Interfaces;
using SK.FinalP.Application.Services;

namespace SK.FinalP.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services
            .AddScoped<IUserService, UserService>()
            .AddScoped<IProposalAcquisitionService, ProposalAcquisitionService>()
            .AddScoped<IProposalHandoverService, ProposalHandoverService>()
            .AddScoped<IProposalTransferService, ProposalTransferService>()
            .AddScoped<IProposalLiquidationService, ProposalLiquidationService>();

        return services;
    }
}
