namespace Web.Components.Features;

public partial class DailyGoals
{
    private void EnableEdit()
    {
        editBoxDisabled = false;
        editButtonDisabled = true;

        saveButtonDisabled = false;
    }

    private void DisableEdit()
    {
        editBoxDisabled = true;
        editButtonDisabled = false;

        saveButtonDisabled = true;
    }

    private void OpenOptions(Goal goal)
    {
        selectedGoal = goal;

        optionsVisible = true;
    }

    private void CloseOptions()
    {
        DisableEdit();

        optionsVisible = false;
    }
    private void OpenNewGoal()
    {
        newGoal = new NewGoal();
        newGoalVisible = true;
    }

    private void CloseNewGoal()
    {
        newGoalVisible = false;
    }
}