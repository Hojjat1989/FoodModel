using Food.Api.Models;
using Food.Application;
using Microsoft.AspNetCore.Mvc;

namespace Food.Api.Controllers;

public class FoodController : ControllerBase
{
    private readonly IFoodService _foodService;

    public FoodController(IFoodService foodService)
    {
        _foodService = foodService;
    }

    [HttpGet]
    [Route("user/{userId}")]
    public FoodModel[] GetUserSpecificFoods(int userId)
    {
        var foods = _foodService.GetUserSpecificFoods(userId);

        var result = foods.Select(x => x.ToFoodModel()).ToArray();
        return result;
    }

    [HttpGet]
    [Route("user/{userId}/similar/{foodId}")]
    public FoodModel[] GetUserSpecificFoods(int userId, int foodId)
    {
        var foods = _foodService.GetUserSpecificFoods(userId, foodId);

        var result = foods.Select(x => x.ToFoodModel()).ToArray();
        return result;
    }
}
