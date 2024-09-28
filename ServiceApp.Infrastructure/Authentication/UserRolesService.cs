using Microsoft.AspNetCore.Identity;
using ServiceApp.Application.Authentication;
using ServiceApp.Domain.Abstractions;
using ServiceApp.Domain.Users;
using ServiceApp.Infrastructure.Users;

namespace ServiceApp.Infrastructure.Authentication;
public class UserRolesService : IUserRolesService
{
    private readonly UserManager<User> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public UserRolesService(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
    {
        _userManager = userManager;
        _roleManager = roleManager;
    }

    public async Task<Result> AddRoleToTheUser(IUser user, string roleName)
    {
        if (!await _roleManager.RoleExistsAsync(roleName))
        {
            await _roleManager.CreateAsync(new IdentityRole(roleName));
        }

        var userEntity = user as User;
        if (userEntity == null)
        {
            return Result.Fail("User not found");
        }

        await _userManager.AddToRoleAsync(userEntity, roleName);

        return Result.Ok();
    }
}
