using Food.Api.Models;
using Food.Application.DTOs;

namespace Food.Api;

public static class ConvertExtensions
{
    public static FoodModel ToFoodModel(this FoodDto food)
    {
        return new FoodModel
        {
            Id = food.Id,
            Name = food.Name,
        };
    }
}
