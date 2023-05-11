using System;
using Food.Application.DTOs;

namespace Food.Services.Mapping;

public static class FoodExtensions
{
    public static FoodDto ToFoodDto(this Core.Entities.Food food)
    {
        return new FoodDto
        {
            Id = food.Id,
            Name = food.Name,
            // set ingredients as well
        };
    }
}
