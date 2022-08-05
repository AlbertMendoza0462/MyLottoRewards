using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using MyLotoRewards.Auth;
using MyLotoRewards.BLL;
using MyLotoRewards.DAL;
using Radzen;
using System.Security.Claims;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddAuthorizationCore();
builder.Services.AddAuthentication("Cookies")
    .AddCookie(opt =>
    {
        opt.Cookie.Name = "MyLottoRewardsLogin";
        opt.LoginPath = "/auth/login";
    })
    .AddFacebook(opt =>
    {
        opt.AppId = builder.Configuration["Facebook:Id"];
        opt.AppSecret = builder.Configuration["Facebook:Secret"];
    })
    .AddGoogle(opt =>
    {
        opt.ClientId = builder.Configuration["Google:Id"];
        opt.ClientSecret = builder.Configuration["Google:Secret"];
        opt.Scope.Add("profile");
    });

var ConStr = builder.Configuration.GetConnectionString("ConStr");
builder.Services.AddDbContext<Context>(conn =>
        conn.UseSqlite(ConStr)
    );

builder.Services.AddScoped<UsuariosBLL>();
builder.Services.AddScoped<TicketsBLL>();
builder.Services.AddScoped<GananciasBLL>();
builder.Services.AddScoped<LoteriasBLL>();
builder.Services.AddScoped<TiposJugadasBLL>();

builder.Services.AddScoped<NotificationService>();
builder.Services.AddScoped<DialogService>();

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

app.UseAuthentication();
app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.MapControllers();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
