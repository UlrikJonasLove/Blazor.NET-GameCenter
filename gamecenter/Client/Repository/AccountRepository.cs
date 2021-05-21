using System;
using System.Threading.Tasks;
using gamecenter.Client.Helpers.Interface;
using gamecenter.Client.Repository.Interface;
using gamecenter.Shared.DTOs;

namespace gamecenter.Client.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly IHttpService httpService;
        private readonly string baseUrl = "api/accounts";

        public AccountRepository(IHttpService httpService)
        {
            this.httpService = httpService;
        }

        public async Task<UserToken> Register(UserInfo userInfo)
        {
            var response = await httpService.Post<UserInfo, UserToken>($"{baseUrl}/create", userInfo);

            if(!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }

            return response.Response;
        }

        public async Task<UserToken> Login(UserInfo userInfo)
        {
            var response = await httpService.Post<UserInfo, UserToken>($"{baseUrl}/login", userInfo);

            if(!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }

            return response.Response;
        }
    }
}