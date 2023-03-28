using System.Threading.Tasks;
using BookApp.Configuration.Dto;

namespace BookApp.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
