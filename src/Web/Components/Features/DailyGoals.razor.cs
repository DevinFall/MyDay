namespace Web.Components.Features;

public partial class DailyGoals
{
    private bool optionsVisible = false;
    private bool newGoalVisible = false;
    private bool editBoxDisabled = true;
    private bool saveButtonDisabled = true;
    private bool editButtonDisabled = false;
    public List<Goal> Goals { get; set; } = new List<Goal>();
    private Goal selectedGoal = new Goal();
    private NewGoal newGoal = new NewGoal();

    protected override async Task OnInitializedAsync()
    {
        await InitializeGoals();
    }

    private async Task InitializeGoals()
    {
        var serviceResponse = await _goalService.GetGoalsAsync();

        if (serviceResponse.Success is false || serviceResponse.Data is null)
        {
            return;
        }

        Goals = serviceResponse.Data;
    }

    private async Task SaveChanges()
    {
        var updatedGoal = new UpdatedGoal
        {
            Text = selectedGoal.Text
        };

        await _goalService.UpdateGoalAsync(updatedGoal, selectedGoal.Id);

        DisableEdit();

        await InitializeGoals();
    }

    private async Task ToggleCheck(string goalId)
    {
        await _goalService.ToggleCheckAsync(goalId);

        await InitializeGoals();
    }

    private async Task DeleteSelectedGoal()
    {
        await _goalService.DeleteGoalAsync(selectedGoal.Id);

        CloseOptions();

        await InitializeGoals();
    }

    private async Task AddNewGoal()
    {
        await _goalService.AddGoalAsync(newGoal);

        CloseNewGoal();

        await InitializeGoals();
    }
}