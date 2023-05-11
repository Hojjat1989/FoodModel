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
        services.AddDbContext<FoodDbContext>(options =>
        {
            options.UseSqlServer(config.GetValue<string>(Sql));
        }, ServiceLifetime.Scoped);

        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

        services.AddScoped(typeof(IFoodService), typeof(FoodService));
    }
}
