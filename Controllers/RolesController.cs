using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using WebApiNewTemp.DTO;
using WebApiNewTemp.Model;

namespace WebApiNewTemp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class RolesController : ControllerBase
    {
        private readonly RoleContext _roleContext;
        public RolesController(RoleContext roleContext)
        {
            _roleContext = roleContext;
        }

        [HttpPost]
        public async Task<IActionResult> SaveRole([FromBody] Roless dto)
        {
            if (dto.RID > 0)
            {
                var existing = await _roleContext.Roles.FindAsync(dto.RID);
                if (existing is null)
                {
                    return NotFound(new { success = false, message = "Role not found" });
                }

                existing.RName = dto.RName;
                existing.FullRName = dto.FullRName;
                existing.ROrder = dto.ROrder;
                existing.RStatus = dto.RStatus;
                existing.Comment = dto.Comment;
                existing.AssignedMenuSubMenu = dto.AssignedMenuSubMenu;

                await _roleContext.SaveChangesAsync();
                return Ok(new { success = true, message = "Role updated successfully", data = existing });
            }

            var role = new Role
            {
                RName = dto.RName,
                FullRName = dto.FullRName,
                ROrder = dto.ROrder,
                RStatus = dto.RStatus,
                Comment = dto.Comment,
                AssignedMenuSubMenu = dto.AssignedMenuSubMenu,
                AddedBy = User.Identity?.Name ?? "Unknown",
                AddedOn = DateTime.UtcNow
            };

            _roleContext.Roles.Add(role);
            await _roleContext.SaveChangesAsync();
            return Ok(new { success = true, message = "Role saved successfully", data = role });
        }


        [HttpGet]
        public async Task<IActionResult> GetRoles()
        {
            try
            {
                var userName = User.Identity?.Name;                              // "name" claim, e.g. "admin"
                var userId = User.FindFirstValue(JwtRegisteredClaimNames.Sub); // "sub" claim, e.g. "1"



                var roles = await _roleContext.Roles.AsNoTracking().OrderBy(r => r.ROrder).ToListAsync();
                return Ok(roles);
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
        }
    }
}
