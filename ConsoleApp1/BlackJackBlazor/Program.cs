using BlackJack.BLL;
using BlackJack.DAL;
using BlackJack.DAL.Contexts;
using BlackJackBlazor;
using BlackJackBlazor.Hubs;
using Microsoft.AspNetCore.Components.Web;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services.ConfigureDAL();
builder.Services.ConfigureBLL();
builder.Services.AddSignalR();

builder.Services.AddDbContext<ApplicationContext>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapHub<SessionHub>("/sessionhub");
app.MapFallbackToPage("/_Host");

app.Run();
