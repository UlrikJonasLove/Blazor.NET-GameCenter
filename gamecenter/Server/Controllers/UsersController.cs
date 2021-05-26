using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using gamecenter.Server.Data;
using gamecenter.Server.Helpers;
using gamecenter.Shared.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace gamecenter.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly AppDbContext context;
        private readonly UserManager<IdentityUser> userManager;

        public UsersController(AppDbContext context, UserManager<IdentityUser> userManager)
        {
            this.context = context;
            this.userManager = userManager;
        }

        [HttpGet]
        public async Task<ActionResult<List<UserDTO>>> Get([FromQuery] PageDTO pageDto)
        {
            try
            {
                var queryable = context.Users.AsQueryable();
                await HttpContext.InsertPaginationParametersInResponse(queryable, pageDto.ItemsPerPage);
                return await queryable.Paginate(pageDto)
                    .Select(x => new UserDTO{ Email = x.Email, UserId = x.Id }).ToListAsync();
            }
            catch(Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "database failure");
            }
        }

        [HttpGet("roles")]
        public async Task<ActionResult<List<RoleDTO>>> Get()
        {
            try
            {
                return await context.Roles
                    .Select(x => new RoleDTO { RoleName = x.Name }).ToListAsync();
            }
            catch(Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "database failure");
            }

        }

        [HttpPost("assignRole")]
        public async Task<ActionResult> AssignRole(EditRoleDTO editRoleDto)
        {
            try
            {
                var user = await userManager.FindByIdAsync(editRoleDto.UserId);
                object p = await userManager.AddClaimAsync(user, new Claim(ClaimTypes.Role, editRoleDto.RoleName));
                return NoContent();
            }
            catch(Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "database failure");
            }
        }

        [HttpPost("removeRole")]
        public async Task<ActionResult> RemoveRole(EditRoleDTO editRoleDto)
        {
            try
            {
                var user = await userManager.FindByIdAsync(editRoleDto.UserId);
                object p = await userManager.RemoveClaimAsync(user, new Claim(ClaimTypes.Role, editRoleDto.RoleName));
                return NoContent();
            }
            catch(Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "database failure");
            }
        }
    }
}