namespace Web.Services;

public partial class GoalService
{
    private readonly HttpClient _httpClient;
    // private readonly IConfiguration _configuration;
    public GoalService(IHttpClientFactory clientFactory)
    {
        _httpClient = clientFactory.CreateClient("myday.api");
    }

    public async Task<ServiceResponse<List<Goal>>> GetGoalsAsync()
    {
        var requestUrl = "/api/Goals";

        var apiResponse = await _httpClient.GetAsync(requestUrl);

        var responseContent = await GetResponseContentAsync(apiResponse);

        return responseContent;
    }

    public async Task UpdateGoalAsync(UpdatedGoal updatedGoal, string goalId)
    {
        var requestUrl = $"/api/Goals/Update/{goalId}";

        var apiResponse = await _httpClient.PutAsJsonAsync(requestUrl, updatedGoal);
    }

    public async Task ToggleCheckAsync(string goalId)
    {
        var requestUrl = $"/api/Goals/Check/{goalId}";

        await _httpClient.PostAsync(requestUrl, null);
    }

    public async Task DeleteGoalAsync(string goalId)
    {
        var requestUrl = $"/api/Goals/Delete/{goalId}";

        await _httpClient.DeleteAsync(requestUrl);
    }

    public async Task AddGoalAsync(NewGoal newGoal)
    {
        var requestUrl = $"/api/Goals/New";

        await _httpClient.PostAsJsonAsync(requestUrl, newGoal);
    }
}