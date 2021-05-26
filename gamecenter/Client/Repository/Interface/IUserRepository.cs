using System.Collections.Generic;
using System.Threading.Tasks;
using gamecenter.Shared.DTOs;

namespace gamecenter.Client.Repository.Interface
{
    public interface IUserRepository
    {
        Task AssignRole(EditRoleDTO editRoleDto);
        Task<List<RoleDTO>> GetRoles();
        Task<PageResponse<List<UserDTO>>> GetUsers(PageDTO pageDto);
        Task RemoveRole(EditRoleDTO editRoleDto);
    }
}