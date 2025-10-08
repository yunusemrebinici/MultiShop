using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cargo.DataAccessLayer.Migrations
{
    public partial class add_userUdInCargoCustomer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "CargoCustomers",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "CargoCustomers");
        }
    }
}
