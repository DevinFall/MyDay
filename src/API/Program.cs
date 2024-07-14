using Microsoft.AspNetCore.DataProtection;

var builder = WebApplication.CreateBuilder(args);

// Manage configuration
builder.Configuration.AddEnvironmentVariables();

var defaultConnection = builder.Configuration.GetConnectionString("DefaultConnection");

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseMySql(defaultConnection, ServerVersion.AutoDetect(defaultConnection));
});
builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.AddScoped<GoalService>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
