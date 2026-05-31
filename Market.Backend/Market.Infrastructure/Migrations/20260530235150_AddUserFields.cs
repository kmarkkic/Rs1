using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Market.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddUserFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Lastname",
                table: "Users",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "Firstname",
                table: "Users",
                newName: "FirstName");

            migrationBuilder.AddColumn<string>(
                name: "Note",
                table: "VisitRequests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "CityId",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Note",
                table: "VisitRequests");

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Users",
                newName: "Lastname");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "Users",
                newName: "Firstname");
        }
    }
}
