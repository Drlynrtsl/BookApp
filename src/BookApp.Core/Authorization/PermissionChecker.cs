using Abp.Authorization;
using BookApp.Authorization.Roles;
using BookApp.Authorization.Users;

namespace BookApp.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
