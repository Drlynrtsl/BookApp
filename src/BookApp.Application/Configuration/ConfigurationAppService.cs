using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using BookApp.Configuration.Dto;

namespace BookApp.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : BookAppAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
