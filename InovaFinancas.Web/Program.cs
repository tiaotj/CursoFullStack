using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using InovaFinancas.Web;
using MudBlazor.Services;
using InovaFinancas.Web.Seguranca;
using Microsoft.AspNetCore.Components.Authorization;
using InovaFinancas.Core.Handlers.Conta;
using InovaFinancas.Web.Handlers;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

Configuration.BackEndURL = builder.Configuration.GetValue<string>("BackendUrl") ?? string.Empty;

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddScoped<CookieHandler>();

builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<AuthenticationStateProvider, CookieAuthenticationStateProvider>();
builder.Services.AddScoped(x => (ICookieAuthenticationStateProvider)x.GetRequiredService<AuthenticationStateProvider>());

builder.Services.AddMudServices();

builder.Services.AddHttpClient(Configuration.HttpClientName, opt => 
		{
			opt.BaseAddress = new Uri(Configuration.BackEndURL);
		}).AddHttpMessageHandler<CookieHandler>();

builder.Services.AddTransient<IContaHandler, ContaHandler>();

await builder.Build().RunAsync();
