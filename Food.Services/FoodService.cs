using Food.Application;
using Food.Application.DTOs;
using Food.Core.Base;
using Food.Core.Entities;
using Food.Services.Mapping;

namespace Food.Services;

public class FoodService : IFoodService
{
    private readonly IRepository<Core.Entities.Food> _foodRepository;
    private readonly IRepository<UserAllergic> _userAllergicRepository;
    private readonly IRepository<FoodIngredient> _foodIngredientsRepository;

    public FoodService(IRepository<Core.Entities.Food> foodRepository,
        IRepository<UserAllergic> userAllergicRepository,
        IRepository<FoodIngredient> foodIngredientsRepository)
    {
        _foodRepository = foodRepository;
        _userAllergicRepository = userAllergicRepository;
        _foodIngredientsRepository = foodIngredientsRepository;
    }

    public FoodDto[] GetUserSpecificFoods(int userId)
    {
        var userAllergicIngredients = _userAllergicRepository.GetAll(x => x.UserId == userId)
            .Select(x => x.IngredientId).ToArray();

        var foods = _foodRepository.GetAll(x =>
            x.FoodIngredients.All(i => !userAllergicIngredients.Contains(i.IngredientId)));

        return foods.Select(x => x.ToFoodDto()).ToArray();
    }

    public FoodDto[] GetUserSpecificFoods(int userId, int foodId)
    {
        var userAllergicIngredients = _userAllergicRepository.GetAll(x => x.UserId == userId)
            .Select(x => x.IngredientId).ToArray();

        var targetFoodIngredients = _foodIngredientsRepository
            .GetAll(x => x.FoodId == foodId)
            .Select(x => x.IngredientId).ToArray();

        var commonCount = (int)(0.7 * targetFoodIngredients.Length);

        var foods = _foodRepository.GetAll(x =>
            x.FoodIngredients.Count(i => targetFoodIngredients.Contains(i.IngredientId)) >= commonCount &&
            x.FoodIngredients.All(i => !userAllergicIngredients.Contains(i.IngredientId)));

        return foods.Select(x => x.ToFoodDto()).ToArray();
    }

    public PagedResultDto<FoodDto> GetUserSpecificFoodsPaged(int userId, int pageNumber = 1, int pageSize = 10)
    {
        var userAllergicIngredients = _userAllergicRepository.GetAll(x => x.UserId == userId)
            .Select(x => x.IngredientId).ToArray();

        var allFoods = _foodRepository.GetAll(x =>
            x.FoodIngredients.All(i => !userAllergicIngredients.Contains(i.IngredientId)));

        var totalCount = allFoods.Count();
        var foods = allFoods
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .Select(x => x.ToFoodDto())
            .ToArray();

        return new PagedResultDto<FoodDto>
        {
            Data = foods,
            PageNumber = pageNumber,
            PageSize = pageSize,
            TotalCount = totalCount
        };
    }

    public PagedResultDto<FoodDto> GetUserSpecificFoodsPaged(int userId, int foodId, int pageNumber = 1, int pageSize = 10)
    {
        var userAllergicIngredients = _userAllergicRepository.GetAll(x => x.UserId == userId)
            .Select(x => x.IngredientId).ToArray();

        var targetFoodIngredients = _foodIngredientsRepository
            .GetAll(x => x.FoodId == foodId)
            .Select(x => x.IngredientId).ToArray();

        var commonCount = (int)(0.7 * targetFoodIngredients.Length);

        var allFoods = _foodRepository.GetAll(x =>
            x.FoodIngredients.Count(i => targetFoodIngredients.Contains(i.IngredientId)) >= commonCount &&
            x.FoodIngredients.All(i => !userAllergicIngredients.Contains(i.IngredientId)));

        var totalCount = allFoods.Count();
        var foods = allFoods
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .Select(x => x.ToFoodDto())
            .ToArray();

        return new PagedResultDto<FoodDto>
        {
            Data = foods,
            PageNumber = pageNumber,
            PageSize = pageSize,
            TotalCount = totalCount
        };
    }
}