using OTAKON.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// 🔌 LIGAÇÃO À BASE DE DADOS (Entity Framework + SQL Server Express)
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// 🔧 CONFIGURAÇÃO DO PIPELINE
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
