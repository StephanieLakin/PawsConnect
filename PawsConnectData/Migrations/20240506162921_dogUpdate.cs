using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PawsConnectData.Migrations
{
    public partial class dogUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Bio",
                table: "Dogs",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl1",
                table: "Dogs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl2",
                table: "Dogs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl3",
                table: "Dogs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Bio",
                table: "Dogs");

            migrationBuilder.DropColumn(
                name: "ImageUrl1",
                table: "Dogs");

            migrationBuilder.DropColumn(
                name: "ImageUrl2",
                table: "Dogs");

            migrationBuilder.DropColumn(
                name: "ImageUrl3",
                table: "Dogs");
        }
    }
}
