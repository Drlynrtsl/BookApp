using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace BookApp.Controllers
{
    public abstract class BookAppControllerBase: AbpController
    {
        protected BookAppControllerBase()
        {
            LocalizationSourceName = BookAppConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
