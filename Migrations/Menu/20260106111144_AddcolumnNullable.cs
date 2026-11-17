using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApiNewTemp.Migrations.Menu
{
    /// <inheritdoc />
    public partial class AddcolumnNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IconClass",
                table: "Menus",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IconClass",
                table: "Menus");
        }
    }
}
