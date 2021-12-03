using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using SingleBlazorBlackJack;
using Test;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddSingleton<BlackJackMultSessions>();
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");


builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

await builder.Build().RunAsync();
