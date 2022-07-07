using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Todolist.Migrations
{
    public partial class dropbox : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Importance",
                table: "Items",
                type: "TEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Importance",
                table: "Items");
        }
    }
}
