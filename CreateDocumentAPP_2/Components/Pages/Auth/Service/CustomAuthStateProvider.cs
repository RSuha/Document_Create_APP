using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using System.Security.Claims;
using System.Text.Json;
using System.Threading.Tasks;

public class CustomAuthStateProvider : AuthenticationStateProvider
{
    private ClaimsPrincipal _currentUser = new ClaimsPrincipal(new ClaimsIdentity());
    private readonly ProtectedSessionStorage _sessionStorage;
    private const string SessionKey = "authUser";
    private bool _isAuthenticated = false;

    public CustomAuthStateProvider(ProtectedSessionStorage sessionStorage)
    {
        _sessionStorage = sessionStorage;
    }

    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        if (!_isAuthenticated)
        {
            return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity())); // Kullanıcı oturum açmamış gibi başlat
        }

        return new AuthenticationState(_currentUser);
    }

    public async Task LoadUserFromSessionAsync()
    {
        var storedUser = await _sessionStorage.GetAsync<string>(SessionKey);
        if (storedUser.Success && !string.IsNullOrEmpty(storedUser.Value))
        {
            var userData = JsonSerializer.Deserialize<UserSessionData>(storedUser.Value);
            if (userData != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, userData.Email),  // Mevcut Email
                    new Claim("FullName", userData.FullName ?? string.Empty), // FullName bilgisi
                    new Claim(ClaimTypes.Role, userData.Role)
                };

                var identity = new ClaimsIdentity(claims, "Auth");
                _currentUser = new ClaimsPrincipal(identity);
                _isAuthenticated = true;
                NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
            }

        }
    }

    public async Task SetUser(ClaimsPrincipal user)
    {
        var email = user.FindFirst(ClaimTypes.Name)?.Value; // Aynı isimde email
        var role = user.FindFirst(ClaimTypes.Role)?.Value;
        var fullName = user.FindFirst("FullName")?.Value;

        if (!string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(role))
        {
            var userData = new UserSessionData
            {
                Email = email,
                Role = role,
                FullName = fullName // FullName yeni olarak saklanacak
            };
            await _sessionStorage.SetAsync(SessionKey, JsonSerializer.Serialize(userData));
        }

        _currentUser = user;
        _isAuthenticated = true;
        NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
    }



    public async Task Logout()
    {
        _currentUser = new ClaimsPrincipal(new ClaimsIdentity());
        _isAuthenticated = false;
        await _sessionStorage.DeleteAsync(SessionKey);
        NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
    }

    private class UserSessionData
    {
        public string Email { get; set; }  // Mevcut değişkenler kalıyor
        public string Role { get; set; }
        public string FullName { get; set; }  // Yeni alan eklendi
    }


}
