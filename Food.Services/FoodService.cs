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

    public FoodService(IRepository<Core.Entities.Food> foodRepository,
        IRepository<UserAllergic> userAllergicRepository)
    {
        _foodRepository = foodRepository;
        _userAllergicRepository = userAllergicRepository;
    }

    public FoodDto[] GetUserSpecificFoods(int userId)
    {
        var userAllergicIngredients = _userAllergicRepository.GetAll(x => x.UserId == userId)
            .Select(x => x.IngredientId).ToArray();

        var foods = _foodRepository.GetAll(x =>
            x.FoodIngredients.All(i => !userAllergicIngredients.Contains(i.Id)));

        var result = foods.Select(x => x.ToFoodDto()).ToArray();
        return result;
    }
}