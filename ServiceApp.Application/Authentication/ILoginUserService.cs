namespace ServiceApp.Application.Authentication;
public interface ILoginUserService
{
    Task<bool> LoginUserAsync(string userName, string password);
}
