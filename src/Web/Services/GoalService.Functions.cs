namespace Web.Services;

public partial class GoalService
{
    private async Task<ServiceResponse<List<Goal>>> GetResponseContentAsync(HttpResponseMessage httpResponse)
    {
        var responseContent = httpResponse.Content;

        var parsedContent = await responseContent.ReadFromJsonAsync<ServiceResponse<List<Goal>>>();

        if (parsedContent is null)
        {
            return new ServiceResponse<List<Goal>>();
        }

        return parsedContent;
    }

}