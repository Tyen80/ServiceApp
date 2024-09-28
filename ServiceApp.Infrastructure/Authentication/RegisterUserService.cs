using Microsoft.AspNetCore.Identity;
using ServiceApp.Application;
using ServiceApp.Application.Authentication;
using ServiceApp.Infrastructure.Users;

namespace ServiceApp.Infrastructure.Authentication;
public class RegisterUserService : IRegisterUserService
{
    private readonly UserManager<User> _userManager;
    private readonly IEmailManagerService _emailManagerService;

    public RegisterUserService(UserManager<User> userManager, IEmailManagerService emailManagerService)
    {
        _userManager = userManager;
        _emailManagerService = emailManagerService;
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

        await _emailManagerService.SendConfirmationEmailAsync(user);
        return response;
    }
}
