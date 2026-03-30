using OTAKON.Data;
using OTAKode.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// 🔌 LIGAÇÃO À BASE DE DADOS (Entity Framework + SQL Server Express)
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// 🔧 CONFIGURAÇÃO DO PIPELINE
// Add services to the container.
builder.Services.AddControllersWithViews();

// Add Entity Framework Core
builder.Services.AddDbContext<OtakonDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add Authentication with Cookies
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Account/Login";
        options.LogoutPath = "/Account/Logout";
        options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
        options.SlidingExpiration = true;
    });

// Add Session
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();

// 📁 Arquivos estáticos (imagens, css, etc.)
app.MapStaticAssets();

// 🧭 ROTAS
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Loja}/{action=Index}/{id?}") // 👈 Loja como página inicial
    .WithStaticAssets();

app.Run();
app.UseStaticFiles();
app.UseRouting();

// Add Authentication middleware
app.UseAuthentication();

// Add Session middleware
app.UseSession();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.Run();

