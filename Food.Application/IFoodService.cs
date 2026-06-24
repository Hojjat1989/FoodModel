using Food.Application.DTOs;

namespace Food.Application;

public interface IFoodService
{
    FoodDto[] GetUserSpecificFoods(int userId);
    FoodDto[] GetUserSpecificFoods(int userId, int foodId);
    PagedResultDto<FoodDto> GetUserSpecificFoodsPaged(int userId, int pageNumber = 1, int pageSize = 10);
    PagedResultDto<FoodDto> GetUserSpecificFoodsPaged(int userId, int foodId, int pageNumber = 1, int pageSize = 10);
}