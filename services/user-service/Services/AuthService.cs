using UserService.Models;
using UserService.Repositories;

namespace UserService.Services;

public interface IAuthService
{
    Task<AuthResponse?> RegisterAsync(RegisterRequest request);
    Task<AuthResponse?> LoginAsync(LoginRequest request);
}

public class AuthService : IAuthService
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasher _passwordHasher;
    private readonly ITokenService _tokenService;

    public AuthService(
        IUserRepository userRepository,
        IPasswordHasher passwordHasher,
        ITokenService tokenService)
    {
        _userRepository = userRepository;
        _passwordHasher = passwordHasher;
        _tokenService = tokenService;
    }

    public async Task<AuthResponse?> RegisterAsync(RegisterRequest request)
    {
        // Kullanıcı zaten var mı kontrol et
        var existingUser = await _userRepository.GetByEmailAsync(request.Email);
        if (existingUser != null)
        {
            return null; // Email zaten kullanılıyor
        }

        // Yeni kullanıcı oluştur
        var user = new User
        {
            Id = Guid.NewGuid(),
            Email = request.Email,
            PasswordHash = _passwordHasher.HashPassword(request.Password),
            FirstName = request.FirstName,
            LastName = request.LastName,
            Role = "Customer",
            IsActive = true,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };

        var createdUser = await _userRepository.CreateAsync(user);

        // Token oluştur ve döndür
        var token = _tokenService.GenerateToken(createdUser);

        return new AuthResponse
        {
            UserId = createdUser.Id,
            Email = createdUser.Email,
            FirstName = createdUser.FirstName,
            LastName = createdUser.LastName,
            Role = createdUser.Role,
            Token = token
        };
    }

    public async Task<AuthResponse?> LoginAsync(LoginRequest request)
    {
        // Kullanıcıyı bul
        var user = await _userRepository.GetByEmailAsync(request.Email);
        if (user == null)
        {
            return null; // Kullanıcı bulunamadı
        }

        // Şifreyi kontrol et
        if (!_passwordHasher.VerifyPassword(request.Password, user.PasswordHash))
        {
            return null; // Şifre yanlış
        }

        // Token oluştur ve döndür
        var token = _tokenService.GenerateToken(user);

        return new AuthResponse
        {
            UserId = user.Id,
            Email = user.Email,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Role = user.Role,
            Token = token
        };
    }
}