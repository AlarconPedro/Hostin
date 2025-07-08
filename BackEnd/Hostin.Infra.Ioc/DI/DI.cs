using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hangfire;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Hostin.Infra.Ioc;

public static class DI
{
    //public static IServiceCollection AddInfrastructureAPI(this IServiceCollection services, IConfiguration configuration, bool isOnline)
    //{
        //string connectionString = isOnline ? "HostinWeb" : "HostinLocal";
        //services.AddDbContext<Hostin>(options =>
        //{
        //    options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        //    options.UseSqlServer(configuration.GetConnectionString(connectionString),
        //        b => b.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName));
        //});

        //services.AddAuthorization();
        //services.AddHangfireServer();

        //return services;
    //}
}
