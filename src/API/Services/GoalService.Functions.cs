namespace MyDay.API.Services;

public partial class GoalService
{
    private async Task<List<DailyGoal>> GetDbGoalsAsync()
    {
        var dbGoals = await _dbContext.Goals.ToListAsync();

        return dbGoals;
    }

    private List<RequestGoal> MapDailyGoals(List<DailyGoal> dailyGoals)
    {
        var mappedGoals = 
            from goal in dailyGoals
            select _mapper.Map<RequestGoal>(goal);

        return mappedGoals.ToList();
    }

    private DailyGoal MapNewGoal(NewGoal newGoal)
    {
        var mappedGoal = _mapper.Map<DailyGoal>(newGoal);

        return mappedGoal;
    }

    private async Task AddDbGoalAsync(DailyGoal dbGoal)
    {
        _dbContext.Goals.Add(dbGoal);

        await _dbContext.SaveChangesAsync();
    }

    private async Task<DailyGoal> GetDbGoalAsync(string goalId)
    {
        var dbGoal = await _dbContext.Goals.FirstOrDefaultAsync(g => g.Id == goalId);
        
        if (dbGoal is null)
        {
            throw new Exception($"Daily goal with id '{goalId}' not found.");
        }

        return dbGoal;
    }

    private async Task CheckDbGoalAsync(DailyGoal dbGoal)
    {
        dbGoal.IsChecked = !dbGoal.IsChecked;

        await _dbContext.SaveChangesAsync();
    }

    private async Task UpdateDbGoalAsync(DailyGoal dbGoal, UpdatedGoal updatedGoal)
    {
        dbGoal.Text = updatedGoal.Text;

        await _dbContext.SaveChangesAsync();
    }

    private async Task DeleteDbGoalAsync(DailyGoal dbGoal)
    {
        _dbContext.Goals.Remove(dbGoal);

        await _dbContext.SaveChangesAsync();
    }
}