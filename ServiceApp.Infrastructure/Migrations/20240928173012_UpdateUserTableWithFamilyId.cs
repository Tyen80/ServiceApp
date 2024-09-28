using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServiceApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateUserTableWithFamilyId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FamilyId",
                table: "AspNetUsers",
                type: "nvarchar(456)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FamilyId",
                table: "AspNetUsers");
        }
    }
}
