using Microsoft.AspNetCore.Identity;
using ServiceApp.Application;
using ServiceApp.Application.Authentication;
using ServiceApp.Infrastructure.Users;

namespace ServiceApp.Infrastructure.Authentication;
public class RegisterUserService : IRegisterUserService
{
    private readonly UserManager<User> _userManager;

    public RegisterUserService(UserManager<User> userManager)
    {
        _userManager = userManager;
    }

    public async Task<RegisterUserResponse> RegisterNewUserAsync(string userName, string email, string password)
    {
        var user = new User
        {
            UserName = userName,
            Email = email,
            EmailConfirmed = true
        };

        var result = await _userManager.CreateAsync(user, password);
        var response = new RegisterUserResponse
        {
            Succeeded = result.Succeeded,
            Errors = result.Errors.Select(e => e.Description).ToList()
        };
        return response;
    }
}
