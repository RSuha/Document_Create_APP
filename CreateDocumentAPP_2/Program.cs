using CreateDocumentAPP_2.Components;
using CreateDocumentAPP_2.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using MudBlazor.Services;
using Microsoft.AspNetCore.Components.Server;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using CreateDocumentAPP_2;
using System.Linq.Expressions;

var builder = WebApplication.CreateBuilder(args);

// 📌 JSON yapılandırmasını yükleme (optional: true olarak değiştirildi)
builder.Configuration.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

// 📌 Bağlantı dizesini kontrol et
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
if (string.IsNullOrEmpty(connectionString))
{
    throw new Exception("Bağlantı dizesi bulunamadı! Lütfen appsettings.json dosyanızı kontrol edin.");
}

// 📌 DbContext Servisini Scoped Olarak Ekle
builder.Services.AddDbContext<ProjeDbContext>(options =>
    options.UseSqlServer(connectionString),
    ServiceLifetime.Scoped);

// 📌 Blazor Authentication Servisleri
builder.Services.AddScoped<AuthenticationService>();
builder.Services.AddScoped<ProtectedSessionStorage>(); // Tarayıcıda oturumu saklamak için
builder.Services.AddScoped<CustomAuthStateProvider>();
builder.Services.AddScoped<AuthenticationStateProvider>(sp => sp.GetRequiredService<CustomAuthStateProvider>());
builder.Services.AddAuthorizationCore(); // Blazor için yetkilendirme desteği

// 📌 Dev Mode İçin Hata Yönetimi
builder.Services.Configure<CircuitOptions>(options => options.DetailedErrors = true);

// 📌 Razor & MudBlazor Servisleri
builder.Services.AddRazorComponents().AddInteractiveServerComponents();
builder.Services.AddMudServices();

var app = builder.Build();

// 📌 Hata Yönetimi
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
}

// 📌 Middleware Sırası
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.UseAntiforgery();

app.MapRazorComponents<App>().AddInteractiveServerRenderMode();

app.Run();