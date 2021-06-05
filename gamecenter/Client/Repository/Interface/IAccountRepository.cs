using System.Threading.Tasks;
using gamecenter.Shared.DTOs;

namespace gamecenter.Client.Repository.Interface
{
    public interface IAccountRepository
    {
        Task<UserToken> Login(UserInfo userInfo);
        Task<UserToken> Register(UserInfo userInfo);
        Task<UserToken> RenewToken();
    }
}