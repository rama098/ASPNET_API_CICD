using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WebApiNewTemp.Model
{
    public class Menu
    {
        [Key]
        public int MenuId { get; set; }
        public string MenuName { get; set; }
        public bool Status { get; set; }
        public string URL { get; set; }
        public int MenuOrder { get; set; }
        public string? IconClass { get; set; }
        public string AddedBy { get; set; }
        public DateTime AddedOn { get; set; }
        public string? UpdateBy { get; set; }
        public DateTime? UpdatedOn { get; set; }

        [JsonIgnore]
        public ICollection<SubMenu>? SubMenus { get; set; } = new List<SubMenu>();
    }
}
