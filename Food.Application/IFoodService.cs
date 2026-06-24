using Food.Application.DTOs;

namespace Food.Application;

public interface IFoodService
{
    FoodDto[] GetUserSpecificFoods(int userId);
    FoodDto[] GetUserSpecificFoods(int userId, int foodId);
}