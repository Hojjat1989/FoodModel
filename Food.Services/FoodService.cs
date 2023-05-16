using System;
using Food.Application;
using Food.Application.DTOs;
using Food.Core.Base;
using Food.Core.Entities;
using Food.Services.Mapping;

namespace Food.Services;

public class FoodService : IFoodService
{
    private IRepository<Core.Entities.Food> _foodRepository;
    private IRepository<UserAllergic> _userAllergicRepository;
    private IRepository<FoodIngredient> _foodIngredientsRepository;

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

        var foodIngredients = new int[10];

        var foods = _foodRepository.GetAll(x =>
            x.FoodIngredients.All(i => !userAllergicIngredients.Contains(i.Id)));

        var result = foods.Select(x => x.ToFoodDto()).ToArray();
        return result;
    }

    public FoodDto[] GetUserSpecificFoods(int userId, int foodId)
    {
        var userAllergicIngredients = _userAllergicRepository.GetAll(x => x.UserId == userId)
            .Select(x => x.IngredientId).ToArray();

        int[] foodIngredients = _foodIngredientsRepository
            .GetAll(x => x.FoodId == foodId)
            .Select(x => x.IngredientId).ToArray();
        var commonCount = 0.7 * foodIngredients.Length;

        var similarFoods = _foodRepository.GetAll(x =>
            x.FoodIngredients.Count(i => foodIngredients.Contains(i.IngredientId)) >= commonCount);

        var foods = _foodRepository.GetAll(x =>
            x.FoodIngredients.All(i => !userAllergicIngredients.Contains(i.Id)));

        var result = foods.Select(x => x.ToFoodDto()).ToArray();
        return result;
    }
}