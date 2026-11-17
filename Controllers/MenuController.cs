using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiNewTemp.DTO;
using WebApiNewTemp.Model;

namespace WebApiNewTemp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private readonly MenuContext _context;
        private readonly SubMenuContext _subMenuContext;
        public MenuController(MenuContext context, SubMenuContext subMenuContext)
        {
            this._context = context;
            this._subMenuContext = subMenuContext;

        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            try
            {
                var deleteMenu = _context.Menus.Find(id);
                _context.Menus.Remove(deleteMenu);
                _context.SaveChanges();
                return Ok(new
                {
                    msg = "delete"
                });
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
        }


        [HttpPost]
        public IActionResult saveMenu(menuDto menu)
        {
            try
            {
                var existingMenu = _context.Menus.Find(menu.MenuId);
                if (existingMenu != null)
                {
                    existingMenu.MenuName = menu.MenuName;
                    existingMenu.Status = menu.Status;
                    existingMenu.URL = menu.URL;
                    existingMenu.MenuOrder = menu.MenuOrder;
                    existingMenu.IconClass = menu.IconClass;
                    existingMenu.UpdateBy = "Admin";
                    existingMenu.UpdatedOn = DateTime.UtcNow;

                    _context.SaveChanges();
                    return Ok(new
                    {
                        msg = "updated"
                    });
                }
                else
                {
                    var menu_New = new Menu
                    {
                        MenuName = menu.MenuName,
                        Status = menu.Status,
                        URL = menu.URL,
                        MenuOrder = menu.MenuOrder,
                        AddedBy = "Admin",
                        AddedOn = DateTime.UtcNow,
                        IconClass = menu.IconClass,
                    };

                    _context.Menus.Add(menu_New);
                    _context.SaveChanges();

                    return Ok(new
                    {
                        msg = "saved"
                    });
                }


            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public IActionResult getAllMenus()
        {
            try
            {
                var menus = _context.Menus.Where(m => m.Status == true).OrderBy(m => m.MenuOrder)
                            .Select(m => new
                            {
                                m.MenuId,
                                m.MenuName,
                                m.URL,
                                m.IconClass,
                                m.MenuOrder,
                                m.AddedBy,
                                m.AddedOn,
                                m.Status,
                                m.UpdateBy,
                                m.UpdatedOn
                            }).ToList();

                var subMenus = _subMenuContext.SubMenus.Where(s => s.Status == true).OrderBy(s => s.SubMenuOrder)
                               .Select(s => new
                               {
                                   s.SubMenuId,
                                   s.MenuId,
                                   s.SubMenuName,
                                   s.URL,
                                   s.IconClass,
                                   s.SubMenuOrder,
                                   s.AddedBy,
                                   s.AddedOn,
                                   s.UpdateBy,
                                   s.UpdatedOn
                               }).ToList();

                var result = menus
                            .Select(m => new
                            {
                                m.MenuId,
                                m.MenuName,
                                m.URL,
                                m.IconClass,
                                m.MenuOrder,
                                m.Status,
                                m.AddedBy,
                                m.AddedOn,
                                m.UpdateBy,
                                m.UpdatedOn,
                                SubMenus = subMenus.Where(sm => sm.MenuId == m.MenuId)
                                .Select(sm => new
                                {
                                    sm.SubMenuId,
                                    sm.SubMenuName,
                                    sm.URL,
                                    sm.IconClass,
                                    sm.SubMenuOrder,
                                    sm.AddedBy,
                                    sm.AddedOn,
                                    sm.UpdateBy,
                                    sm.UpdatedOn
                                }).ToList()
                            }).ToList();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
