using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyDay.API.Models;

public class DailyGoal
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public string Id { get; set; }
    public string Text { get; set; } = string.Empty;
    public bool IsChecked { get; set; }

    #pragma warning disable CS8618
    public DailyGoal()
    {
    }
    #pragma warning restore CS8618
}