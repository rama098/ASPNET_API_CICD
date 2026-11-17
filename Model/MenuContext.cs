using Microsoft.EntityFrameworkCore;

namespace WebApiNewTemp.Model
{
    public class MenuContext : DbContext
    {
        public MenuContext(DbContextOptions<MenuContext> options) : base(options)
        {

        }
        public DbSet<Menu> Menus { get; set; }

       
    }
}
