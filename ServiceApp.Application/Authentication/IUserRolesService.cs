using ServiceApp.Domain.Users;

namespace ServiceApp.Application.Authentication;
public interface IUserRolesService
{
    Task<Result> AddRoleToTheUser(IUser user, string roleName);
}
