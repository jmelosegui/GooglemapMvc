using System;
using Jmelosegui.Mvc.GoogleMap.Examples;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddEnvironmentVariables();

// Add services to the container.

builder.Services.AddMvc(options => 
{
    options.Filters.Add(new AutoPopulateSourceCodeAttribute(builder.Environment, builder.Configuration));
});

var app = builder.Build();

// Set the base path if the environment variable is set
var basePath = Environment.GetEnvironmentVariable("BASE_PATH");
if (!string.IsNullOrEmpty(basePath))
{
    app.UsePathBase(basePath);
}

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

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=FirstLook}/{id?}");
});

app.MapRazorPages();

app.Run();