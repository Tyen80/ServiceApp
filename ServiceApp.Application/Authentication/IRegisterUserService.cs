namespace ServiceApp.Application.Authentication;
public interface IRegisterUserService
{
    Task<RegisterUserResponse> RegisterNewUserAsync(string userName, string email, string password, string familyId);
}
