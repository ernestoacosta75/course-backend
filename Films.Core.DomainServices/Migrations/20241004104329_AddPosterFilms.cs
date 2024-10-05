using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Films.Core.DomainServices.Migrations
{
    /// <inheritdoc />
    public partial class AddPosterFilms : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Poster",
                table: "Films",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Poster",
                table: "Films");
        }
    }
}
