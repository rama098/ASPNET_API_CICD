using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApiNewTemp.Migrations.SubMenu
{
    /// <inheritdoc />
    public partial class addedNewColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IconClass",
                table: "SubMenus",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IconClass",
                table: "SubMenus");
        }
    }
}
