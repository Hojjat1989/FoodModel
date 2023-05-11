using System;
using Food.Core.Base;

namespace Food.Core.Entities;

public class FoodIngredient : EntityBase
{
    public int FoodId { get; set; }
    public int IngredientId { get; set; }
    public string Value { get; set; }

    public Food Food { get; set; }
    public Ingredient Ingredient { get; set; }
}
