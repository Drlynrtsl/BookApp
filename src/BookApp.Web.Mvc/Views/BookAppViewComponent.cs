using Abp.AspNetCore.Mvc.ViewComponents;

namespace BookApp.Web.Views
{
    public abstract class BookAppViewComponent : AbpViewComponent
    {
        protected BookAppViewComponent()
        {
            LocalizationSourceName = BookAppConsts.LocalizationSourceName;
        }
    }
}
