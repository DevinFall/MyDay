
namespace MyDay.API.Services;

public partial class GoalService : ServiceBase
{
    public GoalService(ApplicationDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
    {
    }

    public async Task<ServiceResponse<List<RequestGoal>>> GetGoalsAsync()
    {
        var serviceResponse = new ServiceResponse<List<RequestGoal>>();

        try
        {
            var dbGoals = await GetDbGoalsAsync();

            var mappedGoals = MapDailyGoals(dbGoals);

            serviceResponse.Data = mappedGoals;
        }
        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = ex.Message;
        }

        return serviceResponse;
    }

    public async Task<ServiceResponse<bool>> AddGoalAsync(NewGoal goal)
    {
        var serviceResponse = new ServiceResponse<bool>();

        try
        {
            var mappedGoal = MapNewGoal(goal);

            await AddDbGoalAsync(mappedGoal);
        }
        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = ex.Message;
        }

        return serviceResponse;
    }

    public async Task<ServiceResponse<bool>> CheckGoalAsync(string goalId)
    {
        var serviceResponse = new ServiceResponse<bool>();

        try
        {
            var dbGoal = await GetDbGoalAsync(goalId);

            await CheckDbGoalAsync(dbGoal);
        }
        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = ex.Message;
        }

        return serviceResponse;
    }

    public async Task<ServiceResponse<bool>> UpdateGoalAsync(string goalId, UpdatedGoal updatedGoal)
    {
        var serviceResponse = new ServiceResponse<bool>();

        try
        {
            var dbGoal = await GetDbGoalAsync(goalId);

            await UpdateDbGoalAsync(dbGoal, updatedGoal);
        }
        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = ex.Message;
        }

        return serviceResponse;
    }

    public async Task<ServiceResponse<bool>> DeleteGoalAsync(string goalId)
    {
        var serviceResponse = new ServiceResponse<bool>();

        try
        {
            var dbGoal = await GetDbGoalAsync(goalId);

            await DeleteDbGoalAsync(dbGoal);
        }
        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = ex.Message;
        }

        return serviceResponse;
    }
}