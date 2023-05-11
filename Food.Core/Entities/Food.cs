using System;
using Food.Core.Base;

namespace Food.Core.Entities;

public class Food : EntityBase
{
    public string Name { get; set; }

    public virtual ICollection<FoodIngredient> FoodIngredients { get; set; }
}
