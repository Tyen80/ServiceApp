using Microsoft.AspNetCore.Identity;
using ServiceApp.Application;
using ServiceApp.Application.Authentication;
using ServiceApp.Infrastructure.Users;

namespace ServiceApp.Infrastructure.Authentication;
public class RegisterUserService : IRegisterUserService
{
    private readonly UserManager<User> _userManager;
    private readonly IEmailManagerService _emailManagerService;
    private readonly IUserRolesService _userRolesService;

    public RegisterUserService(UserManager<User> userManager, IEmailManagerService emailManagerService, IUserRolesService userRolesService)
    {
        _userManager = userManager;
        _emailManagerService = emailManagerService;
        _userRolesService = userRolesService;
    }

    public async Task<RegisterUserResponse> RegisterNewChildUserAsync(string userName, string email, string password, string familyId)
    {
        var user = new User
        {
            UserName = userName,
            Email = email,
            FamilyId = familyId
        };

        var result = await _userManager.CreateAsync(user, password);
        var response = new RegisterUserResponse
        {
            Succeeded = result.Succeeded,
            Errors = result.Errors.Select(e => e.Description).ToList()
        };

        await AddChildRoleAsync(user);
        await _emailManagerService.SendConfirmationEmailAsync(user);
        return response;
    }

    public async Task<RegisterUserResponse> RegisterNewUserAsync(string userName, string email, string password, string familyId)
    {
        var user = new User
        {
            UserName = userName,
            Email = email,
            FamilyId = string.IsNullOrWhiteSpace(familyId) ? Guid.NewGuid().ToString() : familyId
        };

        var result = await _userManager.CreateAsync(user, password);
        var response = new RegisterUserResponse
        {
            Succeeded = result.Succeeded,
            Errors = result.Errors.Select(e => e.Description).ToList()
        };

        await AddRoleAsync(user);
        await _emailManagerService.SendConfirmationEmailAsync(user);
        return response;
    }

    private async Task AddChildRoleAsync(User childUser)
    {
        await _userRolesService.AddRoleToTheUser(childUser, "Child");
    }

    private async Task AddRoleAsync(User familyAdmin)
    {
        await _userRolesService.AddRoleToTheUser(familyAdmin, "FamilyAdmin");
    }
}
