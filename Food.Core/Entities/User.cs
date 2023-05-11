using System;
using Food.Core.Base;

namespace Food.Core.Entities;

public class User : EntityBase
{
    public string Username { get; set; }
    public string Password { get; set; }

    public virtual ICollection<UserAllergic> AllergicIngredients { get; set; }
}
