using System.ComponentModel.DataAnnotations;

namespace WebApiNewTemp.Model
{
    public class FileUpload
    {
        [Key]
        public int Id { get; set; }
        public string? FileName { get; set; }
    }
}
