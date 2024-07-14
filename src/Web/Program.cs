using Microsoft.AspNetCore.DataProtection;
using MudBlazor.Services;
using Web.Components;

var builder = WebApplication.CreateBuilder(args);

// Manage configuration
builder.Configuration.AddEnvironmentVariables();

var apiBaseAddress = builder.Configuration.GetSection("ApiConnection:BaseAddress").Value;
var apiPort = builder.Configuration.GetSection("ApiConnection:Port").Value;
var apiUrl = $"{apiBaseAddress}:{apiPort}";

// Add services to the container.

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddMudServices();
builder.Services.AddHttpClient("myday.api", options =>
{
    options.BaseAddress = new Uri(apiUrl);
});
builder.Services.AddScoped<GoalService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
