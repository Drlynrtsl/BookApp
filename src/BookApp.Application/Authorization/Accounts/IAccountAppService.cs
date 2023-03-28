using System.Threading.Tasks;
using Abp.Application.Services;
using BookApp.Authorization.Accounts.Dto;

namespace BookApp.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
