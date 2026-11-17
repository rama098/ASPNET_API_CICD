using System.ComponentModel.DataAnnotations;

namespace WebApiNewTemp.Model
{
    public class Role
    {
        [Key]
        public int RID { get; set; }
        public string? RName { get; set; }
        public string? FullRName { get; set; }
        public int ROrder { get; set; }
        public string? RStatus { get; set; }
        public string? Comment { get; set; }
        public string? AddedBy { get; set; }
        public DateTime AddedOn { get; set; }
        public string? AssignedMenuSubMenu { get; set; }

    }
}
