using System.Threading.Tasks;
using gamecenter.Shared.DTOs;

namespace gamecenter.Client.Authentication.Interface
{
    public interface ILoginService
    {
        Task Login(UserToken userToken);
        Task Logout();
        Task TryRenewToken();
    }
}