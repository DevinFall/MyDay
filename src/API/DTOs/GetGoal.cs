namespace MyDay.API.DTOs;

public class RequestGoal
{
    public string Id { get; set; } = string.Empty;  
    public string Text { get; set; } = string.Empty;
    public bool IsChecked { get; set; } = false;
}