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
        var user = await _dbContext.Kullanicilar
            .Include(k => k.Company)
            .FirstOrDefaultAsync(u => u.Email == email && u.SifreHash == password);

        if (user == null)
            return false;

        var claims = new List<Claim>
    {
        new Claim(ClaimTypes.Name, user.Email),
        new Claim("FullName", $"{user.Ad} {user.Soyad}"),
        new Claim(ClaimTypes.GivenName, user.Ad),
        new Claim(ClaimTypes.Surname, user.Soyad),
        new Claim(ClaimTypes.Role, user.Rol.ToString()),
        new Claim("Title", user.Title.ToString()),
        new Claim("CompanyID", user.CompanyID?.ToString() ?? ""),
        new Claim("DepartmanID", user.DepartmanID?.ToString() ?? "")
    };

        var identity = new ClaimsIdentity(claims, "Auth");
        var userPrincipal = new ClaimsPrincipal(identity);

        await _authStateProvider.SetUser(userPrincipal);

        return true;
    }


    public async Task Logout()
    {
        await _authStateProvider.Logout();
    }
}
