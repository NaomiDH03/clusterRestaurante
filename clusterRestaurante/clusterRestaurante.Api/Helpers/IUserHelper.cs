using clusterRestaurante.Shared.DTOs;
using clusterRestaurante.Shared.Entities;
using Microsoft.AspNetCore.Identity;

namespace clusterRestaurante.Api.Helpers
{
    public interface IUserHelper
    {
        Task<User> GetUserAsync(string email);
        Task<IdentityResult> AddUserAsync(User user, string password);
        //Checamos si existe el role
        Task CheckRoleAsync(string roleName);
        //Agregamos el role
        Task AddUserToRoleAsync(User user, string roleName);
        //Checamos si existe el usuario
        Task<bool> IsUserInRoleAsync(User user, string roleName);
        Task<SignInResult> LoginAsync(LoginDTO login);
        Task LogoutAsync();
    }
}
