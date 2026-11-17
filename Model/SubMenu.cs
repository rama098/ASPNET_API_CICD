using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WebApiNewTemp.Model
{
    public class SubMenu
    {
        [Key]
        public int SubMenuId { get; set; }
        public string? SubMenuName { get; set; }
        public bool Status { get; set; }
        public string URL { get; set; }
        public int SubMenuOrder { get; set; }
        public string? AddedBy { get; set; }
        public DateTime AddedOn { get; set; }
        public string? UpdateBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string? IconClass { get; set; }
        public int MenuId { get; set; }

    }
}
