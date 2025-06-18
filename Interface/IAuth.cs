using JwtRoleBased.Entities;
using JwtRoleBased.Model;

namespace JwtRoleBased.Interface
{
    public interface IAuth
    {
        Task<User?> Register(UserDto request);
        Task<TokenResponseDto?> RefreshTokenAsync(RefreshTokenRequestDto request);
        Task<TokenResponseDto> Login(UserDto request);
    }

}
