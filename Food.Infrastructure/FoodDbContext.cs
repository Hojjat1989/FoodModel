using System;
using Food.Core;
using Food.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Food.Infrastructure;

public class FoodDbContext : DbContext
{
    public FoodDbContext(DbContextOptions options) : base(options)
    {
        ChangeTracker.AutoDetectChangesEnabled = false;
        ChangeTracker.LazyLoadingEnabled = false;

        Database.EnsureCreated();
    }

    public DbSet<Food.Core.Entities.Food> Foods { get; set; }
    public DbSet<Ingredient> Ingredients { get; set; }
    public DbSet<FoodIngredient> FoodIngredients { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<UserAllergic> UserAllergics { get; set; }
}
