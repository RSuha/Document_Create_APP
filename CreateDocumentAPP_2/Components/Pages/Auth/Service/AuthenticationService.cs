using CreateDocumentAPP_2.Entities;
using CreateDocumentAPP_2.Entities.Model;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

public class AuthenticationService
{
    private readonly ProjeDbContext _dbContext;
    private readonly CustomAuthStateProvider _authStateProvider;

    public AuthenticationService(ProjeDbContext dbContext, AuthenticationStateProvider authStateProvider)
    {
        _dbContext = dbContext;
        _authStateProvider = (CustomAuthStateProvider)authStateProvider;
    }

    public async Task<bool> Login(string email, string password)
    {
        var user = await _dbContext.Kullanicilar.FirstOrDefaultAsync(u => u.Email == email && u.SifreHash == password);

        if (user == null)
            return false;

        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, user.Email),  // Email aynı kalacak
            new Claim("FullName", $"{user.Ad} {user.Soyad}"), // Yeni alan FullName
            new Claim(ClaimTypes.GivenName, user.Ad),  // Yeni eklenen Ad alanı
            new Claim(ClaimTypes.Surname, user.Soyad), // Yeni eklenen Soyad alanı
            new Claim(ClaimTypes.Role, user.Rol.ToString())
        };



        var identity = new ClaimsIdentity(claims, "Auth");
        var userPrincipal = new ClaimsPrincipal(identity);

        await _authStateProvider.SetUser(userPrincipal);  // Artık JSON'da sadece Email & Role saklanıyor

        return true;
    }

    public async Task Logout()
    {
        await _authStateProvider.Logout();
    }
}
