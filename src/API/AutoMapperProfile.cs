namespace MyDay.API;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<DailyGoal, RequestGoal>();
        CreateMap<NewGoal, DailyGoal>();
    }
}