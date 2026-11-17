using Microsoft.EntityFrameworkCore;

namespace WebApiNewTemp.Model
{
    public class SubMenuContext : DbContext
    {
        public SubMenuContext(DbContextOptions<SubMenuContext> options) : base(options){ }

        public DbSet<SubMenu> SubMenus { get; set; }

       // protected override void OnModelCreating(ModelBuilder modelBuilder) { modelBuilder.Entity<SubMenu>().HasOne(s => s.me).WithMany(m => m.SubMenus).HasForeignKey(s => s.MenuId); }
   
    }
}
