using System;
using Food.Application;
using Food.Core.Base;
using Food.Infrastructure;
using Food.Services;
using Microsoft.EntityFrameworkCore;

namespace Food.Api.Containers;

public static class DependencyInjector
{
    private const string Sql = "Sql";

    public static void Register(this IServiceCollection services, IConfigurationSection config)
    {
        var connectionString = config.GetValue<string>(Sql);
        services.AddDbContext<FoodDbContext>(options =>
        {
            options.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 35)));
        }, ServiceLifetime.Scoped);

        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

        services.AddScoped(typeof(IFoodService), typeof(FoodService));
    }
}
