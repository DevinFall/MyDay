using Microsoft.AspNetCore.Mvc;

namespace MyDay.API.Controllers;

public class GoalsController : ApiController
{
    private readonly GoalService _goalService;
    public GoalsController(GoalService goalService)
    {
        _goalService = goalService;
    }

    [HttpGet]
    public async Task<ActionResult<ServiceResponse<List<RequestGoal>>>> GetGoals()
    {
        var serviceResponse = await _goalService.GetGoalsAsync();

        if (serviceResponse.Success is false)
        {
            return BadRequest(serviceResponse);
        }

        return Ok(serviceResponse);
    }

    [HttpPost("New")]
    public async Task<ActionResult<ServiceResponse<bool>>> AddGoal(NewGoal newGoal)
    {
        var serviceResponse = await _goalService.AddGoalAsync(newGoal);

        return GenerateResponse(serviceResponse);
    }

    [HttpPost("Check/{goalId}")]
    public async Task<ActionResult<ServiceResponse<bool>>> CheckGoal(string goalId)
    {
        var serviceResponse = await _goalService.CheckGoalAsync(goalId);

        return GenerateResponse(serviceResponse);
    }

    [HttpPut("Update/{goalId}")]
    public async Task<ActionResult<ServiceResponse<bool>>> UpdateGoal(string goalId, UpdatedGoal updatedGoal)
    {
        var serviceResponse = await _goalService.UpdateGoalAsync(goalId, updatedGoal);

        return GenerateResponse(serviceResponse);
    }

    [HttpDelete("Delete/{goalId}")]
    public async Task<ActionResult<ServiceResponse<bool>>> DeleteGoal(string goalId)
    {
        var serviceResponse = await _goalService.DeleteGoalAsync(goalId);

        return GenerateResponse(serviceResponse);
    }
}