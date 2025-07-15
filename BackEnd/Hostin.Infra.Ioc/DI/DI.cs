using Hangfire;
using Hangfire.MemoryStorage;
using Hostin.Core.Interfaces.Config;
using Hostin.Infra.Data.Services;
using Hostin.Infra.Data.Services.Config;
using HostIn_Api;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Hostin.Infra.Ioc;

public static class DI
{
    public static IServiceCollection AddInfrastructureAPI(this IServiceCollection services, IConfiguration configuration, bool isOnline)
    {
        string connectionString = isOnline ? "HostinWeb" : "HostinLocal";
        services.AddDbContext<HostinContext>(options =>
        {
            options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            options.UseSqlServer(configuration.GetConnectionString(connectionString),
                b => b.MigrationsAssembly(typeof(HostinContext).Assembly.FullName));
        });

        services.AddTransient(typeof(IGenericService<>), typeof(GenericService<>));
        services.AddTransient<IEmpresaService, EmpresaService>();
        services.AddTransient<IUsuarioService, UsuarioService>();
        services.AddTransient<ITelaService, TelaService>();

        services.AddHangfire(config => config.UseMemoryStorage());

        services.AddAuthorization();
        services.AddHangfireServer();

        return services;
    }
}
