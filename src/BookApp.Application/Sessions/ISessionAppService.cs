using System.Threading.Tasks;
using Abp.Application.Services;
using BookApp.Sessions.Dto;

namespace BookApp.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
