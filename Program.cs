using BlazorStrap;
using DatingApp.FrontEnd.Gateway.Configuration;
using DatingApp.FrontEnd.Gateway.DotNetGateway;
using DatingApp.FrontEnd.Models.CurrentUser;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services.AddBlazorStrap();

ConfigureSettings(builder.Configuration, builder.Services);
ConfigureServices(builder.Configuration, builder.Services);

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

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();

void ConfigureServices(ConfigurationManager config, IServiceCollection services)
{
    var apiOptions = config.GetSection("DatingApp.API");
    var baseUrl = apiOptions.GetValue<string>("BaseUrl");

    services.AddHttpClient("datingapp", cl =>
    {
        cl.BaseAddress = new Uri(baseUrl);
    });
    services.AddScoped<IHttpClientService, HttpClientService>();
    services.AddScoped<GatewayAdapter>();

    services.AddSingleton<ICurrentUser, CurrentUser>();
}

void ConfigureSettings(ConfigurationManager config, IServiceCollection services)
{
    services.AddSingleton(provider =>
    {
        var apiOptions = config.GetSection("DatingApp.API");

        var baseUrl = apiOptions.GetValue<string>("BaseUrl");

        return new ApiOptions(baseUrl);
    });
}
