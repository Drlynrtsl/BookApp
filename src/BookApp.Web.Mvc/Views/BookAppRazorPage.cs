using Abp.AspNetCore.Mvc.Views;
using Abp.Runtime.Session;
using Microsoft.AspNetCore.Mvc.Razor.Internal;

namespace BookApp.Web.Views
{
    public abstract class BookAppRazorPage<TModel> : AbpRazorPage<TModel>
    {
        [RazorInject]
        public IAbpSession AbpSession { get; set; }

        protected BookAppRazorPage()
        {
            LocalizationSourceName = BookAppConsts.LocalizationSourceName;
        }
    }
}
