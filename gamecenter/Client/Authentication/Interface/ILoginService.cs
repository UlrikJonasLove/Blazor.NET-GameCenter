using System.Threading.Tasks;

namespace gamecenter.Client.Authentication.Interface
{
    public interface ILoginService
    {
        Task Login(string token);
        Task Logout();
    }
}