using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace WebApiNewTemp.Model
{
    public class FileUploadContext : DbContext
    {
        public FileUploadContext(DbContextOptions<FileUploadContext> options) : base(options) { }

        public DbSet<FileUpload> Files { get; set; }
    }
}
