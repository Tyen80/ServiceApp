using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using ServiceApp.Application.Tasks.TaskService;
using ServiceApp.UI.Client.Features.Tasks;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddScoped<ITaskToDoService, TaskToDoClientService>();

await builder.Build().RunAsync();
