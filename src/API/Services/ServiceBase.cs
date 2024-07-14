namespace MyDay.API.Services;

public abstract class ServiceBase
{
    protected readonly ApplicationDbContext _dbContext;
    protected readonly IMapper _mapper;
    public ServiceBase(ApplicationDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }
}