namespace ServiceApp.Application.Authentication;
public interface IUserService
{
    Task<string> GetCurrentUserByIdAsync();
    Task<string> GetCurrentUserByFamilyIdAsync();
    Task<string> GetUserId(string userId);

}
