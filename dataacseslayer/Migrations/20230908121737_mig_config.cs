using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dataacseslayer.Migrations
{
    /// <inheritdoc />
    public partial class mig_config : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "confirmcode",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "confirmcode",
                table: "AspNetUsers");
        }
    }
}
