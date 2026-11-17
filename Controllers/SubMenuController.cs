using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using WebApiNewTemp.DTO;
using WebApiNewTemp.Model;

namespace WebApiNewTemp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubMenuController : ControllerBase
    {
        private readonly SubMenuContext _context;
        public SubMenuController(SubMenuContext context)
        {
            this._context = context;
        }
        //https://localhost:7103/api/SubMenu
        [HttpGet]
        public IActionResult getSubmenus()
        {
            try
            {
                return Ok(_context.SubMenus.ToList());
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult saveSubMenu(subMenu Submenu)
        {
            try
            {
                var newSubMenu = new SubMenu
                {
                    SubMenuName = Submenu.SubMenuName,
                    MenuId = Submenu.MenuId,
                    Status = Submenu.Status,
                    URL = Submenu.URL,
                    SubMenuOrder = Submenu.SubMenuOrder,
                    AddedBy = Submenu.AddedBy,
                    AddedOn = DateTime.Now,
                    IconClass = Submenu.IconClass
                };
                _context.SubMenus.Add(newSubMenu);
                _context.SaveChanges();
                return Ok(new { msg = "saved" });
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }

        }
    }
}
