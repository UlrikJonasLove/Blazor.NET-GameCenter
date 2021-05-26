using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using gamecenter.Client.Helpers.Interface;
using gamecenter.Client.Repository.Interface;
using gamecenter.Shared.DTOs;

namespace gamecenter.Client.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly IHttpService httpService;
        private readonly string url = "api/users";

        public UserRepository(IHttpService httpService)
        {
            this.httpService = httpService;
        }

        public async Task<PageResponse<List<UserDTO>>> GetUsers(PageDTO pageDto)
        {
            return await httpService.GetHelper<List<UserDTO>>(url, pageDto);
        }

        public async Task<List<RoleDTO>> GetRoles()
        {
            return await httpService.GetHelper<List<RoleDTO>>($"{url}/roles");
        }

        public async Task AssignRole(EditRoleDTO editRoleDto)
        {
            var response = await httpService.Post($"{url}/assignRole", editRoleDto);
            if(!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }
        }

        public async Task RemoveRole(EditRoleDTO editRoleDto)
        {
            var response = await httpService.Post($"{url}/removeRole", editRoleDto);
            if(!response.Success)
            {
                throw new ApplicationException(await response.GetBody());
            }
        }
    }
}