using Microsoft.EntityFrameworkCore;

namespace WebApiNewTemp.Model
{
    public class LoginPageContext : DbContext
    {
        public LoginPageContext(DbContextOptions<LoginPageContext> options) : base(options)
        {

        }

        public DbSet<LoginPage> LoginPages { get; set; }
    }
}
