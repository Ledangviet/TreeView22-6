using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Excercise_2_API.Migrations
{
    /// <inheritdoc />
    public partial class addenums : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NodeType",
                table: "Nodes",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NodeType",
                table: "Nodes");
        }
    }
}
