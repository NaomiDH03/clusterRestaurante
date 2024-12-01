using clusterRestaurante.Shared.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace clusterRestaurante.Api.Helpers
{
    public class UserHelper : IUserHelper
    {
        private readonly DataContext dataContext;
        private readonly UserManager<User> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public UserHelper(DataContext dataContext, UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            this.dataContext = dataContext;
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        public async Task<IdentityResult> AddUserAsync(User user, string password)
        { 
            return await userManager.CreateAsync(user, password);
        }

        public async Task AddUserToRoleAsync(User user, string roleName)
        {
            await userManager.AddToRoleAsync(user, roleName);
        }

        public async Task CheckRoleAsync(string roleName)
        {
            bool roleExist = await roleManager.RoleExistsAsync(roleName);
            if (!roleExist)
            {
                await roleManager.CreateAsync(
                    new IdentityRole
                    {
                        Name = roleName,
                    });
            }
        }

        public async Task<User> GetUserAsync(string email)
        {
            var user = await dataContext.Users.Include(e => e.Employee!).FirstOrDefaultAsync(x => x.Email == email);
            return user!;
        }

        public async Task<bool> IsUserInRoleAsync(User user, string roleName)
        {
            return await userManager.IsInRoleAsync(user, roleName);
        }
    }
}
