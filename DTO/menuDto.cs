namespace WebApiNewTemp.DTO
{
    public class menuDto
    {
        public int MenuId { get; set; }
        public string MenuName { get; set; }
        public bool Status { get; set; }
        public string URL { get; set; }
        public int MenuOrder { get; set; }
        public string? IconClass { get; set; }
        public string AddedBy { get; set; }
        public DateTime AddedOn { get; set; }
   
    }
}
