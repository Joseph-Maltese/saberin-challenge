//this file sets up services before the app runs
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using music_manager_starter.Client;
//(*NEWBYME*) Import SearchService namespace from Client/Services for use in Program.cs
using music_manager_starter.Client.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
//(*NEWBYME*) a single SearchService instance is created and shared across the whole app
builder.Services.AddSingleton<SearchService>();

await builder.Build().RunAsync();
