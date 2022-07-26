using Blazored.SessionStorage;
using Blazored.Toast;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using MyLotoRewards.BLL;
using MyLotoRewards.DAL;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddBlazoredToast();
builder.Services.AddBlazoredSessionStorage();

var ConStr = builder.Configuration.GetConnectionString("ConStr");
builder.Services.AddDbContext<Context>(conn =>
        conn.UseSqlite(ConStr)
    );

builder.Services.AddScoped<UsuariosBLL>();
builder.Services.AddScoped<TicketsBLL>();
builder.Services.AddScoped<GananciasBLL>();
builder.Services.AddScoped<LoteriasBLL>();
builder.Services.AddScoped<TiposJugadasBLL>();

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
