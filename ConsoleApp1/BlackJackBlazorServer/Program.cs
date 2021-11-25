using BlackJack.BLL;
using BlackJack.DAL;
using BlackJack.DAL.Contexts;
using BlackJackBlazorServer.Data;
using BlackJackBlazorServer.Hubs;

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.Owin;
using Owin;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services.ConfigureDAL();
builder.Services.ConfigureBLL();
builder.Services.AddSignalR(options => { options.EnableDetailedErrors = true; });

builder.Services.AddDbContext<ApplicationContext>();

builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseRouting();

app.MapControllers();
app.MapBlazorHub();
app.MapHub<BlackJackHub>("/blackjackhub");
app.MapFallbackToPage("/_Host");

app.Run();
