using BlazorApp1;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient 
{
    BaseAddress = new Uri("http://localhost:5000") // Development - Set the correct base address of your API here
    //BaseAddress = new Uri("http://red-desert-0234a091e.4.azurestaticapps.net") // Production - Set the correct base address of your API here
});

builder.Services.AddScoped<ProductsService>();

var host = builder.Build();


// Remove the navigation redirection
// var navigation = host.Services.GetRequiredService<NavigationManager>();
// navigation.NavigateTo("/products", forceLoad: true);

await host.RunAsync();


