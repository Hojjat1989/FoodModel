using System;
using Food.Core.Base;

namespace Food.Core.Entities;

public class UserAllergic : EntityBase
{
    public int UserId { get; set; }
    public int IngredientId { get; set; }

    public virtual Ingredient Ingredient { get; set; }
}
