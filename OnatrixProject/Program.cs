using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using OnatrixProject.Interfaces;
using OnatrixProject.Services;
using OnatrixProject.ViewModels;
using Umbraco.Cms.Core.DependencyInjection;
using Umbraco.Extensions;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.CreateUmbracoBuilder()
    .AddBackOffice()
    .AddWebsite()
    .AddComposers()
    .Build();

builder.Services.AddScoped<FormSubmissionsService>();
builder.Services.Configure<EmailViewModel>(builder.Configuration.GetSection("Smtp"));
builder.Services.AddTransient<IEmailService, SmtpEmailService>();

WebApplication app = builder.Build();

await app.BootUmbracoAsync();

app.UseStaticFiles();


app.UseUmbraco()
    .WithMiddleware(u =>
    {
        u.UseBackOffice();
        u.UseWebsite();
    })
    .WithEndpoints(u =>
    {
        u.UseBackOfficeEndpoints();
        u.UseWebsiteEndpoints();
    });

await app.RunAsync();