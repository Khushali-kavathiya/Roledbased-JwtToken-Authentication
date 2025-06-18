using JwtRoleBased.Entities;
using JwtRoleBased.Model;

namespace JwtRoleBased.Interface
{
    public interface IAuth
    {
        Task<User?> Register(UserDto request);
        Task<string> Login(UserDto request);
    }

}
